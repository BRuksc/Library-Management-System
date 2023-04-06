# Library-Management-System
Complete system for management libraries
Library management system v.1.0 – technical documentation

1. Assumptions

	This application is going to help managment libraries. This system will be allow user to save books available in library, library users, designate and monitor leasing process for many libraries.

2. Technologies

	This project will be create in WPF using C#, .NET, MVVM, MS SQL Server, and Entity Framework Core for mapping database’s objects.

3. Start window

	First window, which is showing after start app will contains a logging system. User can write a NIP of an existing library, login and password, but a library worker cannot create own account, all of accounts are created by admins of library, and all permissions are granted by him. Under these two textboxes are buttons ‘Register your library’, and button for recovery account if user do not remember password (system send email to a library account with a request about reset password).

4. Registering library

	After click the button in a start window, start window is closed, and Registration window is open. The window contains the following textboxes in three columns (requiered for filling in are not marked with “*” symbol):
-Address
-Telephone number
-Website address*

-Email address
-NIP number
-REGON number

-DUNS number
-Name
-Date of commencement of activities

-Voivodeship
-City
-ZIP code

-Admin account login
-Password
-Repeat a password

	In the right bottom corner of form is button with content “register”. After click that, programme check, does the library can be registered. If exists any library with the same DUNS number, email address, address, NIP number or REGON number, throw an exception and do not create a library. If password and repeat a password are not the same, throw an exception and do not create a database. If everything is correct send email on received email address. After confirmation user can confirm everything using email and auto-generated 4 digits code, and then he is redirected to login window.

5. Database structure

	Tables:
*libraries – contains all of information about libraries, which programm has got in registration
*Admins – contains all of admins (primary key, Login, Password, relation with one library)
*Workers – contains all of workers (primary key, Login, Password, relation with one library)
*Users – contains all of normal users (primary key, email, password, PESEL, living address, relation with one library)
*Books – contains all of books (primary key, title, author, date_of_published, is_borrowed, LibraryId)
