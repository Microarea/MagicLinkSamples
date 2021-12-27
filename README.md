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
We will create a very sample applicatyion whose purpose is posting an accounting transaction to a specific fiscal company, among those managed in Mago.

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

Type the following address: http://localhost/Mago4/LoginManager/LoginManager.asmx, and press "Go". Please note that you may need to replace ``localhost`` with the name of the server on which Mago4 is installed, if different from the local PC, and ``Mago4`` with the instance name of your Mago4, if you changed it during installation (i.e.: "MyMago4").

![Screenshot](/screenshots/ServiceReference1.PNG)

Give a meaningful name to the reference, i.e.: "MagoLoginManager", and press "OK".

Visual Studio places your reference under a "Connected Services" node. It has also created a wrapper class around it that will help you in dealing with the web service call, so that for you it will be not different from using a normal C# class.

As stated before, we will use the LoginManager web service to authenticate and get a token to be used in subsequent calls.  
The authentication token is a string, we will store it in a class variable so that we will have it handy until the program ends.

