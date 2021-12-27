# MagicLinkSample-CGM
The CGM module allows to manage multiple fiscal companies in the same Mago subscription/database.  
This imply that some of the data are shared among companies (defined as "public" data), and some other are specific of the individual company ("private" data).  
To learn more about the CGM features, see: [Guide to use Corporate Group Management](http://www.microarea.it/MicroareaHelpCenter/Walkthrough-M4-CGM.ashx) (requires authentication).

When transferring data via MagicLink it is then needed to take care about the fiscal company targeted by the transfer, especially when dealing with "private" data, as most of the documents are (i.e.: sales document, journal entries).

This repository contains a sample about using the CGM via MagicLink, and below there is a step-by-step guide to create it.

## Prerequisites

In order to create this sample application you will need:
* Visual Studio 2019 (or above)
* a working Mago4 with a sample company data set and the CGM module configured and activated

To learn how to download and install Mago4, see: [Installing and configuring Mago4](http://www.microarea.it/MicroareaHelpCenter/RefGuide-M4-ERP-InstallationGuide.ashx).  
To learn about configuring and using the CGM feature, see: [Guide to use Corporate Group Management](http://www.microarea.it/MicroareaHelpCenter/Walkthrough-M4-CGM.ashx).  
If you are working on a licensed copy of Mago4, you have to check for some prerequisites, see: [Deploying MagicLink-based Applications](http://www.microarea.it/MicroareaHelpCenter/RefGuide-Extensions-TBMagicPlatform-DeployingMagicLinkApplications.ashx).  
_Note: all the above links require authentication_.

## Step 1: Creating the Sample Application
We will create a very sample application whose purpose is posting an accounting transaction to a specific fiscal company, among those managed in Mago.

Open Visual Studio 2019 and crea a new Windows Form C# project, name it as you prefer (i.e.: MagicLinkCGM).

The example is divide basically in three parts:
1. logging into Mago4 and creating the TBLoader instance (Mago4 back-end service)
1. setting the desired fiscal company by invoking the specific web method
1. posting the data

Suppose you want to provide a form in which the user select the fiscal company to target some transactions; then, pressing a button, having them posted to the right fiscal company.

For this purpose you have to include the following controls to the form:

* a button to connect to Mago4
* a textbox for the fiscal company to select
* a button to set the fiscal company
* a button to post the transaction data

Your form should look like this:

![Screenshot](/screenshots/SampleApp.png)


## Step 2: Connecting to Mago4 through LoginManager
To take any action through the web services exposed via MagicLink, we need to be authenticated by the Mago4 security system, and for that we must provide a valid user name and password  to the authentication web service, that is called LoginManager.  
We will receive from it an authentication token that we will need to provide to any subsequent call to the MagicLink web services.

The first thing to do, in order to make a call to the LoginManager web service, is to add a reference to it. From the Solution Explorer of VS2019, right-click on the project node and select "Add > Service Reference".

Type the following address:
```
http://localhost/Mago4/LoginManager/LoginManager.asmx
```
and press "Go". Please note that you may need to replace ``localhost`` with the name of the server on which Mago4 is installed, if different from the local PC, and ``Mago4`` with the instance name of your Mago4, if you changed it during installation (i.e.: "MyMago4").

![Screenshot](/screenshots/ServiceReference1.PNG)

Give a meaningful name to the reference, i.e.: "MagoLoginManager", and press "OK".

Visual Studio places your reference under a "Connected Services" node. It has also created a wrapper class around it that will help you in dealing with the web service call, so that for you it will be not different from using a normal C# class.

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
You need to define and set the following variables in your code:
``` C#
string server = ""; // the server where Mago is installed: "localhost" or some PC in the LAN
string instance = "Mago4"; // Mago4 is the default instance name, but it can be changed
string loginName = ""; // a valid user name
string password = ""; // its password
string companyName = ""; // name of the company (this is the company owning of the DB, containing the "fiscal" ones)
```
You may hard-code these values in your source code, or collect them from the UI.

Please note that you have to declare ``authenticationToken`` as string variable of your form class.  
The ``askingProcess`` parameter (here shown as ``"Your code here"`` placeholder) has to be replaced with the Producer Key assigned to you. The Producer Key univokely identify your company as the producer of your solution among all the Microarea partner. It is mainly used for license authentication. To learn more, please see: [What is the Producer Key?](http://www.microarea.it/MicroareaHelpCenter/Misc-Extensions-TBMagicPlatform-WhatIsTheProducerKey.ashx) (requires authentication).

As you can see, the login method call (``LoginCompact``) returns a code if not succesfull. The error code explains the reasons of the failure. To see a complete list of error codes, please see: [MagicLink Error Codes](http://www.microarea.it/MicroareaHelpCenter/RefGuide-Extensions-TBMagicPlatform-MagicLinkErrorCodes.ashx) (requires authentication).  
The Web Service call may also cause a number of exceptions, which are catched by the ``try .. catch`` block. Such exceptions may occur due to communication infrastructure problems, please refer to Microsoft documentation for details about them.

To complete our implementation, we also need to ensure the program will log off from ``LoginManager`` system, to avoid the CAL be set as in use by a process that is no more active.  
While the total number of available CALs for MagicLink is not limited in a Mago4 licensed copy, it is a good practice disposing them when no more useful.
For doing this, we will add an event hanlder to the ``FormClosing`` event of the form (from the design view, in the "Properties" pane, switch to the event list and double click on the ``FormClosing`` event, this automatically declare and creates an event handler).  
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
To invoke the web method that set the fiscal company, you must load a Mago4 backend, by starting a ``TbLoader`` process. This is done through the ``TBServices`` Web Service.

Now in order to make a call to the ``TBServices`` web service we need to add a web reference to it in our application.

To do it, follow the same procedure described in Step 2, the URL of the service is:
```
http://localhost/Mago4/TbServices/TbServices.asmx
```
Again, you may need to change the values for ``localhost`` and ``Mago4``.

To start a ``TBLoader`` perocess on the server in silent mode we will use the method ``CreateTB`` of the ``TBServices`` service.  
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
Store the ``tbPort`` value returned from the call in a class variable, as you will need it later.  

We can now compile and run our application. By clicking on the "Connect" button, we should see the success message. The very first call may require some time due to the initial service startup.

The authentication token has no timeout, so it will not expire until we explicitly log off (in this case, by closing the application).
To check for the currently logged users, open the Microarea Administration Console without closing the sample application.

![Screenshot](/screenshots/Console.png)

From the tree menu, select System Information, Web Services, then click on the LoginManager Web Service. On the bottom pane the currently logged user status is displayed.  
As you can see, the login made through the sample application is shown.  
If you close the application and come back to the Console, right-click anywhere on the users list, Refresh, you will see that the CAL was cleared by the logout action.

In case an user remains logged in due to an application failure, this screen give you the possibility to remove it: right-click on it, and then select Disconnect.

## Step 4: Change the Current Fiscal Company via the ``TBGenlibUI`` library
To change the current fiscal company used by Mago, you have to use a specific method exposed by the ``TBGenlibUI`` library.  
Such library exposes a series of web methods, including the one you need: ``SetFiscalCompany``.

For this purpose, you will add to your solution a Web Reference to the Mago4 ``TBGenlibUI`` library.

In order to add a reference to the Web Methods of one of the Mago4 library, you have first to start a ``TbLoader`` process, which will be listening on a specific port: this was done in the previous step.  
This is required as such Web Services are not permanently registered (i.e.: as it is for LoginManager), but instead support "dynamic discovery" only.  
As you run your application and logged in for the previous step, the TBLoader process is already started and will remain there until a default timeout of 20 min.  
For troubles in starting the TBLoader, see [Troubleshooting](http://www.microarea.it/MicroareaHelpCenter/RefGuide-Extensions-TBMagicPlatform-Troubleshooting.ashx) (requires authentication).

Right-click on your Visual Studio 2019 solution, select "Add > Service Reference", "Advanced...", "Add Web Reference".  
Insert the following URL:
```
http://localhost:[port number]/Framework.TbGenlibUI.TbGenlibUI
```
(change ``localhost`` to your Mago server; please note that the firewall, if any, must have this port opened).  
Click the "GO" button, and insert the Web reference name (i.e.: ``TBGenlibUI``).

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
The fiscal compmay id is an ``int`` value, ``0`` being normally the HQ.

## Step 5: Post Some Data to the Selected Fiscal Company
The sole purpose of this step is to check that any subsequent call to the MagicLink's basic ``SetData`` or ``GetData`` methods will target the selected fiscal company.



