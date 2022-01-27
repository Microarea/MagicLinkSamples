# PurchaseDocJE - AP_AR
This sample program demonstrates how:
* create an Accounting Received document
* create the Payable document and attach it to the accounting document
* post in accounting the payment of one installment of the purchase invoice
* close the installment in the Payable document, and attach it to the accounting entry

The installments of the Payable document can be created:
* according to the standard payment method associated to the Supplier
* according to a given payment method 
* custom defined

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

## Step 1 - Posting the accounting Purchase Document 
The first step is posting the accounting Purchase Document to Mago4.

In the first tab, the program allows to load an XML: some are provided in the ``sample`` subfolder, but it is possible to use custom ones.  
The included samples are:
* ``PurchaseDocJESample.xml`` a sample, based on the ``Basic`` export profile, providing the most common data for such a document
* ``PurchaseDocJESample-minimal.xml`` the bare minimum data required to create a coherent and valid document. All the possible defaults are left for Mago4 to determine.

*Note: the `Basic` profiles are defined starting from release 3.5. To use this sample with previous versions of Mago4, see [Installing the custom profiles](#installing-the-custom-profiles)*

After the document is posted via ``SetData``, the complete XML of the new accounting document is returned (if successful). The value of some fields, such as the ``JournalEntryId``, is extracted from the XML. They are needed for the next step.

## Step 2 - Creating the Payable document and connecting it to the accounting one
The second step is create the Payable document, which contains the payment due dates and amounts, and connect it to the previously created accounting document. This will allow to correctly manage the further accounting operations (i.e: paying the supplier).

This is done by posting the Payable document, using the ``Basic`` profile, by filling all the required data equal to those of the Accounting Purchase invoice just posted.  
It is important to set the ``JournalEntryID`` (primary key of the Accounting Purchase invoice), so that the Payable will be connected to the accounting entry.

Some remarks:
* ``DocumentDate`` is considered to be the starting date for calculate the installments. If you want them to start from a different date, set the ``InstallmStartDate`` field.
* ``TotalAmount`` and ``TaxAmount`` are the basis for the installments calculation. ``TaxAmount`` is required as some payment terms require to pay the VAT on the first installment. 
* ``CRRefType`` is set to ``27066420`` (accounting received document) and ``CRRefID`` to the accounting entry ID: this will populate the Cross References to easy the navigation between the documents.

Please note that the installments can be generated in different ways:
* setting the ``Payment`` node with a valid payment term code will automatically create the corresponding installments in the payable. 
* omitting the ``Payment`` node will let Mago4 use the standard payment method of the supplier, and create the corresponding installments.
* the installments body can be competely overriden, by creating the installments manually (i.e.: agreed with the supplier).  
To do this, there is a commented section in the ``btnCreatePayable_Click`` function, showing how to manually fill the ``Detail`` section of the Payable document.

Whatever method is chosen, keep track, from the returned XML, of the ``PymtSchedId`` value, and of the ``InstallmentDate`` of the various installments: they will be needed to post the payments, in the next steps.

## Step 3 - Posting the accouting payment entry
At the right moment, it will be necessary to pay the Supplier. This involves both posting the payment entry to the accounting (i.e.: picking data from the bank) and closing the Payable, even partially (i.e.: pay the first installment).

In this step, the accounting part of the payment is posted. The program allows to load an XML: the provided sample ``PureJEPaymentSample.xml`` is constructed to pay the first installment of the ``PurchaseDocJESample.xml`` sample, but it is possible to use custom XML.  
The sample is based on the ``Tcpos_PureJe_Collections``, a lightweight standard profile suitable for this kind of operations.

After the document is posted via ``SetData``, the complete XML of the new accounting document is returned (if successful). The value of some fields, such as the ``JournalEntryId``, are extracted from the XML. They are needed for the next step.

## Step 4 - Closing one installment of the Payable document
In this step the Payable document created in Step 2 is updated by adding the closing line corresponding to the payment made.  
The code is in the ``btnClosePayable_Click`` function.

To add the line the Payable Document is retrieved by its ID (``PymtSchedId``) and a line is added to its ``Detail`` section. Please note the use of the attribute ``updateType='OnlyInsert'`` in the ``Detail`` node: this instructs MagicLink to add lines to the existing ones, otherwise the entire body would be overwritten.

Some data come from the Journal Entry just posted: the date, the amount, and most of all the ``JournalEntryID`` that will connect the closing line with the accounting entry.  
Some other have to be retained from the original invoice posting: the Payable Document ID and the original due date of the installment to close (required, as it is used in several reports).

Some remarks:
* the ``InstallmentNo`` has to be set to the number of the installment to close. It is not required to close the instalments in any order.
* the ``InstallmentDate`` can be any date, it doesn't have to match the original due date.
* the ``PaymentTerm`` can be any suitable value, and do not have to match those of the installment to close. It is allowed to have an installment expecting, say, Bank Payment and close it with cash. In the example the value ``2686976`` means "Cash".
* the ``Amount`` can be equal or smaller of the installment amount. If the closing lines matches the amount of the original installment, it will be considered closed. 

## Installing the custom profiles
The `Basic` profiles are included in version 3.5 and above. If you want to use this sample with a Mago4 release 3.4, you must install them as custom ones.    
Copy the ``Applications`` folder inside the ``profiles`` in the following folder:
```sh
    [Mago installation folder]Custom\Companies\[company name] 
```
The Mago installation folder usually is ``C:\Program Files (x86)\Mago4``.

Adjust all the XML files provided in the sample, and the XML fragments included in the code, changing all the occurrences of ``/Standard/`` with ``/AllUsers/``
