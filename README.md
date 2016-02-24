# ASP.NET-MVC-Project 

# PickUp:


### Idea
PickUp in general is a system, where people can publicate trips between two locations, so the other users can share the ride and the costs with them.
The not logged users acn see the home page, where the last 10 added trips are shown, and also the top 10 drivers and top 10 passengers for the last 24 hours. The unauthorized users can also enter the trips page, where they can searxh for a preferable destination and start date of the trip.

The logged users are two types - "Passengers" and "Drivers".
The pasengers can do all of the above aqnd also see details of every trip. They can join a trip and 24 hours after the trip is made, they can rate the driver. Also the passengers can view their profile, edit it and change the profile pucture.

The drivers can do all of the above. Only "Driver"-s can create trips. When they publicate the trip they add how many seats are taken, description, start date of the trip and other details. In my trips page the drivers can rate not only the drivers of the trips that they have attended, but they can also rate the passenger of the trips they post.

The administrator can do all of the above and also he has an administration area, where he can view, edit, add, delete trips, locations, users and trips.

### Base Models
 - Location - has name;
 - Trip - has "from" destination, "to" destination, start date, available seats, description, driver and passengers;
 - User - has first name, last name, age, image and others;
 - Vehicle - has registration number, year, brand, model and color;
 - Rate - has the user that is rating, the user that is rated and value;
 - Image - has file name, file content and extension;
 
### Requirements
 - Using ASP.NET MVC and Visual Studio 2015 with Update 1;
 - Have 17 controllers;
 - Have 40 custom actions;
 - Using Razor template engine for generating the UI;
 - Using Kendo DatePicker and Grids;
 - Using sections in the Ajax requests
 - Have 5 partial views
 - Have 4 editor templates
 - Useing MS SQL Server as database back-end
 - Using Entity Framework 6 to access your database
 - Using repositories and/or service layer is a must
 - Have Administration and Driver areas
 - Have tables with data with server-side paging and sorting for every model entity
 - Sort of beautiful and responsive UI
 - Using Bootstrap
 - Not using the standard theme
 - Using the standard ASP.NET Identity System for managing users and roles
 - Using AJAX forms for editing entities and joining trips
 - Using caching in the home page
 - Using Autofac and Automapper
 - Wrote 15 unit tests for the routes.
 - Appling error handling and data validation to avoid crashes when invalid data is entered, where possible
 - Prevent from security holes (XSS, XSRF, Parameter Tampering, etc.)
 - Handle correctly the special HTML characters and tags like <script>, <br />, etc.
 - Documentation of the project and project architecture (as .md file, including screenshots)

