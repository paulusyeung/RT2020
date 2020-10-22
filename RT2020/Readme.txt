Visual WebGui - Links
====================================================
1. Home page 				- http://www.visualwebgui.com
2. Bug tracking and reporting 		- http://support.visualwebgui.com
3. Any questions can be sent to		- support@visualwebgui.com


Visual WebGui - Frequently Asked Questions
====================================================


1. When I run the application I get a directory listing instead of the application.
--------------------------------------------------------------------------------------------------------

In order to run a Visual WebGui application from visual studio you need to set the start page 
to a virtual Visual WebGui page (by default "Form1.wgx"). To do so you should open the project 
properties and go to the web tab. In the web tab you should choose "Specific Page" and enter the 
virtual page you want to start from.


2. How do I define a virtual Visual WebGui page?
--------------------------------------------------------------------------------------------------------

In the Visual WebGui configuration section there is an Applications section. Each application mapped
with in the Application section represents a virtual page. The code attribute will be the page name and
the type attribute is the class mapping that should inherit from Gizmox.WebGUI.Forms.Form class.


3. When I run the WGX page I get a message that the resource was not found.
--------------------------------------------------------------------------------------------------------

Visual WebGui uses its own script map called wgx. The wgx extension is defined in the IIS manager and should 
have the same definitions as the aspx extension but without the "check file exists". If you are getting this
message it is either you have not registered the script map or you have "check file exists" still checked in 
the wgx definition.


4. How do I create a new form?
--------------------------------------------------------------------------------------------------------

Right click your project and select add. From the add menu select a Visual WebGui form or a Visual WebGui user control.


5. How do I use a User Control?
--------------------------------------------------------------------------------------------------------

The best way to do it at this point is to drag a panel to the form and switch to the *.design.vb 
or *.design.cs file and replace the declaration of the panel to your user control and the 
initialization of the panel to the user control type.


6. When I drag controls to the Visual WebGui designer I get an "Invalid WebGUI Control" message.
--------------------------------------------------------------------------------------------------------

You are probably trying to drag a WinForms control or any non Visual WebGui controls. 
Look for the Visual WebGui section in toolbox and from there you should drag components.


