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

## Step 1: Creating the Sample Application

## Step 2: Connecting to Mago4 through LoginManager
![Screenshot](screenshots/ServiceReference1.png)