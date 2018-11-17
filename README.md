# E-Mailer

This is the WPF application for read, write and send emails. 

## Structure

### Design

Whole app is in one window, which using WindowChrome for upgrade its appearance. 

In the window are this components:
  - PagesFrame (All pages are showed here.)
  - SideMenu (Navigation betwen pages. It is viseble after log in.)
  
This app can have one or more themes and languages. 

### Code

Main control of this app is in AppViewModel, which can be located by ViewModelLocator.

After start:
  1. In App.xaml.cs is called "setup" method in IoC (Inversion of controll), where are bind all needed view models.
  2. Window is created.
  3. In window is PagesFrame in which is loaded CurrentPage (biding from AppViewModel).
  
  If any of page view models need to show next page, it change the CurrentPage property in AppViewModel.
  All pages inherits from BasePage which takes its view model (by generics). All logic for pages are handelled here.
  
 
