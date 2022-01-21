# PurchaseDocJE - AP_AR
This sample program demonstrates how:
* create an Accounting Received document
* generate the payment installments corresponding to a given payment method
* create the Receivable document with such installments and attach it to the accounting document
* add a payment for the receivable, posting the corresponding accounting entry

The provided code is complete and working when connected to a Mago4 (release 3.4 and above).  
Below are the comments for the most significant code fragments.

## Prerequisites

In order to use this sample application we will need:
* Visual Studio 2019 (or above)
* a working Mago4 with a sample company data set

To learn how to download and install Mago4, see: [Installing and configuring Mago4](http://www.microarea.it/MicroareaHelpCenter/RefGuide-M4-ERP-InstallationGuide.ashx).  
If you are working on a licensed copy of Mago4, you have to check for some prerequisites, see: [Deploying MagicLink-based Applications](http://www.microarea.it/MicroareaHelpCenter/RefGuide-Extensions-TBMagicPlatform-DeployingMagicLinkApplications.ashx).  
_Note: all the above links require authentication_.

## Login
The Login class encapsulates the functions needed to log in in Mago4, get the authentication token and start a ``TBLoader`` process (the Mago4 backend).  
It shows a dialog collecting the required data:
* the server where Mago4 is installed (default to ``localhost``)
* the name of the installation instance (default to ``Mago4``)
* the company to connect to
* user name and password

Moreover it is allowed to start the ``TBLoader`` server immediately, or let it automatically start at the first ``SetData`` or ``GetData`` call.

How it works:
* The ``LoginManager`` and ``TBServices`` web services are wrapped through a Visual Studio "Connected Services" wrapper class
* the ``Endpoint.Address`` of such classes is adjusted to match the actual server and instance name
* the ``LoginCompact`` method is invoked, providing company, user name and password. If successful, the returned authentication token is stored
* if requested, the ``TBLoader`` process is started, and the returned ``tbPort`` is stored

