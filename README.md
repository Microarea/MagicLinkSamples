# MagicLinkSample-CGM
The CGM module allows to manage multiple fiscal companies in the same Mago subscription/database.  
This imply that some of the data are shared among companies (defined as "public" data), and some other are specific of the individual company ("private" data).  
To learn more about the CGM features, see: [Guide to use Corporate Group Management](http://www.microarea.it/MicroareaHelpCenter/Walkthrough-M4-CGM.ashx) (requires authentication).

When transferring data via MagicLink, it is then needed to take care about the fiscal company targeted by the transfer, especially when dealing with "private" data, as most of the documents are (i.e.: sales document, journal entries).

This repository contains a sample about using the CGM via MagicLink, and below there is a step-by-step guide to create it.

## Prerequisites

In order to create this sample application we will need:
* Visual Studio 2019 (or above)
* a working Mago4 with a sample company data set and the CGM module configured and activated

To learn how to download and install Mago4, see: [Installing and configuring Mago4](http://www.microarea.it/MicroareaHelpCenter/RefGuide-M4-ERP-InstallationGuide.ashx).  
To learn about configuring and using the CGM feature, see: [Guide to use Corporate Group Management](http://www.microarea.it/MicroareaHelpCenter/Walkthrough-M4-CGM.ashx).  
If you are working on a licensed copy of Mago4, you have to check for some prerequisites, see: [Deploying MagicLink-based Applications](http://www.microarea.it/MicroareaHelpCenter/RefGuide-Extensions-TBMagicPlatform-DeployingMagicLinkApplications.ashx).  
_Note: all the above links require authentication_.

## Step 1: Creating the Sample Application
We will create a very simple application whose purpose is posting an accounting transaction to a specific fiscal company, among those managed in Mago.

Open Visual Studio 2019 and create a new Windows Form C# project, naming it as you prefer (i.e.: MagicLinkCGM).

The example is divided basically in three parts:
1. logging into Mago4 and creating the TBLoader instance (Mago4 back-end service)
1. setting the desired fiscal company by invoking the specific web method
1. posting the data

We imagine we want to provide a form in which the user selects the fiscal company target for some transactions; then, pressing a button, having them posted to the right fiscal company.

For this purpose we have to include the following controls to the form:

* a button to connect to Mago4
* a textbox for the fiscal company to select
* a button to set the fiscal company
* a button to post the transaction data

Our form should look like this:

![Screenshot](/screenshots/SampleApp.png)

## Step 2: Connecting to Mago4 through LoginManager
To take any action through the web services exposed via MagicLink, we need to be authenticated by the Mago4 security system, and for that we must provide a valid user name and password to the authentication web service, that is called LoginManager.  
We will receive from it an authentication token that we will need to provide to any subsequent call to the MagicLink web services.

The first thing to do, in order to make a call to the LoginManager web service, is to add a reference to it. From the Solution Explorer of VS2019, right-click on the project node and select "Add > Service Reference".

Type the following address:
```
http://localhost/Mago4/LoginManager/LoginManager.asmx
```
and press "Go". Please note that you may need to replace ``localhost`` with the name of the server on which Mago4 is installed, if different from the local PC, and ``Mago4`` with the instance name of your Mago4, if you changed it during installation (i.e.: "MyMago4").

![Screenshot](/screenshots/ServiceReference1.PNG)

Give a meaningful name to the reference, i.e.: "MagoLoginManager", and press "OK".

Visual Studio places your reference under a "Connected Services" node. It has also created a wrapper class around it that will help us in dealing with the web service call, so that it will be not different from using a normal C# class.

As stated before, we will use the LoginManager web service to authenticate and get a token to be used in subsequent calls.  
The authentication token is a string, we will store it in a class variable so that we will have it handy until the program ends.

We will implement the call to LoginManager inside the handler of the "Connect" button, double-click on it to have Visual Studio creating automatically the handler.
Insert the following code lines:
``` C#
using (MagoLoginManager.MicroareaLoginManagerSoapClient aLogMng = new MagoLoginManager.MicroareaLoginManagerSoapClient())
{
    aLogMng.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/LoginManager/LoginManager.asmx", server, instance));

    try
    {
        int aRes = aLogMng.LoginCompact(ref loginName, ref companyName, password, "Your code here", true, out authenticationToken);

        if (aRes != 0) // 0 means no errors
            MessageBox.Show(string.Format("Error occurred, code: {0}", aRes));
        else
            MessageBox.Show("Connected!");
    }
    catch (Exception logExc)
    {
        MessageBox.Show(string.Format("Exception occurred: {0}", logExc.Message));
    }
}
```
We need to define and set the following variables in your code:
``` C#
string server = ""; // the server where Mago is installed: "localhost" or some PC in the LAN
string instance = "Mago4"; // Mago4 is the default instance name, but it can be changed
string loginName = ""; // a valid user name
string password = ""; // its password
string companyName = ""; // name of the company (this is the company owning of the DB, containing the "fiscal" ones)
```
We can hard-code these values in the source code, or collect them from the UI.

Please note that we have to declare ``authenticationToken`` as string variable in the form class.  
The ``askingProcess`` parameter (here shown as ``"Your code here"`` placeholder) has to be replaced with the Producer Key assigned to you. The Producer Key univokely identify your company as the producer of your solution among all the Mago partner. It is mainly used for license authentication. To learn more, please see: [What is the Producer Key?](http://www.microarea.it/MicroareaHelpCenter/Misc-Extensions-TBMagicPlatform-WhatIsTheProducerKey.ashx) (requires authentication).

As you can see, the login method call (``LoginCompact``) returns a code if not succesfull. The error code explains the reasons of the failure. To see a complete list of error codes, please see: [MagicLink Error Codes](http://www.microarea.it/MicroareaHelpCenter/RefGuide-Extensions-TBMagicPlatform-MagicLinkErrorCodes.ashx) (requires authentication).  
The web service call may also cause a number of exceptions, which are catched by the ``try .. catch`` block. Such exceptions may occur due to communication infrastructure problems, please refer to Microsoft documentation for details about them.

To complete our implementation, we also need to ensure the program will log off from ``LoginManager`` system, to avoid the CAL be set as in use by a process that is no more active.  
While the total number of available CALs for MagicLink is not limited in a Mago4 licensed copy, it is a good practice disposing them when no more useful.  
For doing this, we will add an event handler to the ``FormClosing`` event of the form.  
In its body, write the following code lines:
```C#
if (authenticationToken != string.Empty)
{
    using (MagoLoginManager.MicroareaLoginManagerSoapClient aLog = new MagoLoginManager.MicroareaLoginManagerSoapClient())
    {
        aLog.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/LoginManager/LoginManager.asmx", server, instance));
        aLog.LogOff(authenticationToken);
    }
}
```

## Step 3: Create a TBLoader Instance
To invoke the web method that set the fiscal company, we must load a Mago4 backend, by starting a ``TbLoader`` process. This is done through the ``TBServices`` web service.

Now in order to make a call to the ``TBServices`` web service we need to add a reference to it in our application.

To do it, follow the same procedure described in Step 2, the URL of the service is:
```
http://localhost/Mago4/TbServices/TbServices.asmx
```
Again, you may need to change the values for ``localhost`` and ``Mago4``.

To start a ``TBLoader`` process on the server in silent mode we will use the method ``CreateTB`` of the ``TBServices`` service.  
Just add the following code to the handler of the "Connect" button:
```C#
using (MagoTBServices.TbServicesSoapClient aTbService = new MagoTBServices.TbServicesSoapClient())
{
    aTbService.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/TBServices/TBServices.asmx", server, instance));
    string easyLookToken = string.Empty;

    try
    {
        tbPort = aTbService.CreateTB(authenticationToken, DateTime.Today, true, out easyLookToken);

        if (tbPort > 0)
            MessageBox.Show(string.Format("Connected! Port: {0}", tbPort));
        else
            MessageBox.Show(string.Format("CreateTB: some error occurred, returned value: {0}", tbPort));
    }
    catch (Exception exc)
    {
        MessageBox.Show(string.Format("CreateTB: Exception occurred: {0}", exc.Message));
    }
}
```
Store the ``tbPort`` value returned from the call in a class variable, as we will need it later.  

We can now compile and run our application. By clicking on the "Connect" button, you should see the success message. The very first call may require some time due to the initial service startup.

The authentication token has no timeout, so it will not expire until we explicitly log off (in this case, by closing the application).
To check for the currently logged users, open the Microarea Administration Console without closing the sample application.

![Screenshot](/screenshots/Console.png)

From the tree menu, select System Information, Web Services, then click on the LoginManager Web Service. On the bottom pane the currently logged user status is displayed.  
As you can see, the login made through the sample application is shown.  
If you close the application and come back to the Console, right-click anywhere on the users list, Refresh, you will see that the CAL was cleared by the logout action.

In case an user remains logged in due to an application failure, this screen give you the possibility to remove it: right-click on it, and then select Disconnect.

## Step 4: Change the Current Fiscal Company via the ``TBGenlibUI`` library
To change the current fiscal company used by Mago, we will use a specific method exposed by the ``TBGenlibUI`` library.  
Such library exposes a series of web methods, including the one we need: ``SetFiscalCompany``.

For this purpose, we will add to your solution a web reference to the Mago4 ``TBGenlibUI`` library.

In order to add a reference to the web methods of one of the Mago4 library, we have first to start a ``TbLoader`` process, which will be listening on a specific port: this was done in the previous step.  
This is required as such web services are not permanently registered (i.e.: as it is for LoginManager), but instead support "dynamic discovery" only.  
As you run your application and logged in for the previous step, the ``TBLoader`` process is already started and will remain there until a default timeout of 20 min.  
For troubles in starting the TBLoader, see [Troubleshooting](http://www.microarea.it/MicroareaHelpCenter/RefGuide-Extensions-TBMagicPlatform-Troubleshooting.ashx) (requires authentication).

Right-click on your Visual Studio 2019 solution, select "Add > Service Reference", "Advanced...", "Add Web Reference".  

Insert the following URL:
```
http://localhost:[port number]/Framework.TbGenlibUI.TbGenlibUI
```
(change ``localhost`` to your Mago server; please note that the firewall, if any, must have this port opened).  
The ``port number`` is those returned by the call to the ``CreateTB`` method.  

![Screenshot](/screenshots/ServiceReference2.png)

Click the "GO" button, and insert the web reference name (i.e.: ``TBGenlibUI``).

_IMPORTANT NOTE: Please be sure to insert a "Web Reference"" and not a "Service Reference", otherwise the suggested code will not work._

We will implement the switch of the fiscal company in the handler of the "Set" button, double-click on it to have Visual Studio creating automatically the handler and insert the following code lines:
```C#
try
{
    int aFiscalCompany = int.Parse(tbxFiscalCompany.Text);

    TbGenlibUI.TbGenlibUI tbGenlib = new TbGenlibUI.TbGenlibUI();
    tbGenlib.Url = string.Format("http://{0}:{1}/Framework.TbGenlibUI.TbGenlibUI/TbGenlibUI", server, tbPort);

    tbGenlib.HeaderInfo = new TbGenlibUI.TBHeaderInfo();
    tbGenlib.HeaderInfo.AuthToken = authenticationToken;

    tbGenlib.SetFiscalCompany(aFiscalCompany, "");

    MessageBox.Show(string.Format("Fiscal company now is {0}", aFiscalCompany));
}
catch (FormatException fmt)
{
    MessageBox.Show(string.Format("Invalid Fiscal Company number: {0}", fmt.Message));
}
catch (Exception exc)
{
    MessageBox.Show(string.Format("Set Fiscal Company: Exception occurred: {0}", exc.Message));
}
```
The fiscal company id is an ``int`` value, ``0`` being normally the HQ.

## Step 5: Post Some Data to the Selected Fiscal Company
The sole purpose of this step is to check that any subsequent call to the MagicLink's basic ``SetData`` or ``GetData`` methods will target the selected fiscal company.

In this example we will post an accounting transaction to a specific fiscal company (i.e.: "1") by sending a sample XML via ``SetData``.  
There is a sample XML in the root of the repository, or you can choose one of your own.

Double-click the "SetData" button to create the handler and insert the following code:
```C#
using (MagoTBServices.TbServicesSoapClient aTbService = new MagoTBServices.TbServicesSoapClient())
{
    aTbService.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/TBServices/TBServices.asmx", server, instance));

    // insert the right path to your sample file, or let the user choose it in the UI
    string aXMLData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\sample.xml"));
    string aResult = string.Empty;

    try
    {
        if (aTbService.SetData(authenticationToken, aXMLData, System.DateTime.Now, 0, false, out aResult))
            MessageBox.Show("Posted!");
        else
            MessageBox.Show("Not posted, some error occurred!");
    }
    catch (Exception tbExc)
    {
        MessageBox.Show(string.Format("Exception occurred: {0}", tbExc.Message));
    }
}
```
## Testing the result
Now our program is ready to be used, let's compile and run it.  
To test it:
* click on the "connect" button to connect to Mago4 and start the TBLoader process
* set a value for the fiscal company (i.e.: "1") and click on the "Set" button
* click on the "SetData" to post data to Mago4
* open Mago4, switch to the selected fiscal company and check that the transaction was correctly posted to it

## Bonus Step: Listing the Fiscal Companies
The fiscal company id is an ``int`` value, starting from 0. The fiscal companies are numbered sequentially as they are created, the HQ has usually id=0.

Knowing the fiscal company id may be tricky because it is never shown in the Mago interface. This is not really a problem with few fiscal companies, but in some scenarios they are many, and they are often created and deleted (id changes).

To get the list of the available fiscal companies in our external progam we will use a report, extecuting it via a web service call.  
The report content is returned in XML, that we can use, i.e., to populate a combobox once extracting data from it.

The web service we need is the ``EasyLookService``: it is the Reporting Studio execution engine, exposed as a web service.  
Add a reference in the solution as described in Step 2, with the following URL:
```
http://localhost/Mago4/EasyLook/EasyLookService.asmx
```
(adjust ``localhost`` and ``Mago4`` to your environment if needed).  
Name the refecence as you like, i.e.: ``MagoEasyLookService``.

The report we are gonna using is named "Companies", and it is located in the CGM application (_Note: the report is available starting from Mago4 release 3.5_).

Add a button in the UI of the applicaiton and double-click it to generate the handler.  
Insert the following code:
```C#
using (MagoEasyLookService.EasyLookServiceSoapClient aEasyLookSvc = new MagoEasyLookService.EasyLookServiceSoapClient())
{
    aEasyLookSvc.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/EasyLook/EasyLookService.asmx", server, instance));

    try
    {

        string XMLParameters =
        $@"<?xml version='1.0' encoding='utf-16'?>
                <maxs:Companies tbNamespace='Report.CGM.Core.Companies' xmlns:maxs='http://www.microarea.it/Schema/2004/Smart/CGM/Core/Companies.xsd'>
                    <maxs:Parameters>
                    </maxs:Parameters>
                </maxs:Companies>";
        MagoEasyLookService.ArrayOfString xmlResult = aEasyLookSvc.XmlExecuteReport(authenticationToken, XMLParameters, DateTime.Now, "MicroareaAdmin", true);
        MessageBox.Show(xmlResult[0]);

    }
    catch (Exception exc)
    {
        MessageBox.Show(string.Format("GetData: Exception occurred: {0}", exc.Message));
        return;
    }
}
```
As you can see, the report is invoked by its namespace (``Report.CGM.Core.Companies``), and returns an array of results, one per page (hard coded page breaks). As this particular report has no page breaks, all we need is in the first page.

We can then use some simple XPath instructions to get the desired list of companies:
```c#
var xmlDoc = new XmlDocument();
xmlDoc.LoadXml(xmlResult[0]);
XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
nsmgr.AddNamespace("maxs", xmlDoc.DocumentElement.NamespaceURI);

XmlNodeList itemNodes = xmlDoc.SelectNodes("//maxs:Row", nsmgr);

string companyList = string.Empty;
foreach (XmlNode node in itemNodes)
{
    companyList += $"id {node.SelectSingleNode("maxs:CompanyId", nsmgr).InnerText} : {node.SelectSingleNode("maxs:CompanyName", nsmgr).InnerText}\n";
}
MessageBox.Show(companyList);
```


