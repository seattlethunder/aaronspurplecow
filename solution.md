# Purplecow

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 13.2.6.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

You can also open the PurpleCow.SLN solution in Visual Studio and then start the app (F5]).  A command window will open that runs the API layer.  A browser window will open to https://localhost:4200/


## Technical Approach to PurpleCow

To prepare for future growth of the PurpleCow initiative, planned to start with a framework capable of delivering production ready features quickly, while also using a framework that can scale to handle thousands of users.  I could have done this in a couple hours with a simple web api project that did everything, but I wanted a challenge.  Which was not smart because I have a 6 month release deadline on 17-March and have been working 18 hour days to hit it.   

I have never used Docker before, but have always wanted to, so I spent significant time getting up to speed and trying to get Docker to serve the IIS and SQL sites.  As with everything on Windows this was insanity.   Getting the Windows Subsystem for Linux (WSL) working and configured to run Docker containers ate up most of my spare time (but was a lot of fun!).  Unfortunately, as a result, I had to leave off a lot of framework features I would have liked to add.  These are noted below.

The reason for using this approach is due to some struggles we have had in production with my company’s massive framework and enterprise products.  We are running our application layer in Windows Containers because they use many older .Net Framework libraries.  We then host these containers in the Azure Kubernetes Service.  Because many of our clients usage of our products occurs in a 2-3 day window, we wanted to be able to spin up API nodes on demand and scale them out as demand increases.   We have worked very closely with the Windows team at Microsoft and they have made many enhancements for us, but it still can take 5-10 minutes to spin up a windows container.   This has prevented us from being able to spin up an API on demand, which means we have to leave at least 1 node online for each of our clients 24 x 7 x 365, which has significant cost associated to it.

In approaching this project, I thought it would be interesting to start a prototype that would be entirely .Net Core based, so all backend portions of the app could run in Linux in a docker container.   With the new WSL version 2 that is much lighter and faster than the previous version, we should be able to spin up the API/backend in seconds.   Scott Guthrie at Microsoft introduced me to the Mono Project, when I was working there over a decade ago, as a possible solution for my clients Oracle and Peoplesoft and have been dying to try and build a .Net application on it since then.  

The choice of the ASP.Net Core API template was simple as it is REST based and handles JSON requests and responses natively.  It also is easy to configure the API port without having to recompile code.

In researching pieces of the code for this framework, I found that they have updated NHibernate for .Net so it is now compiled in .Net Standard Libraries, so it can be used in .Net Core applications.  As if I didn’t have enough of a challenge, I decided to give this a try too.  I have used EntityFramework and NHibernate extensively and have found NHibernate to have much more extensive and flexible mapping capabilities – and the ability to better setup the queries it generates to improve performance.  

## Sample JSON For Posts

You can use these JSON strings in testing the POST API:

{"Id":"B8B63B1D-D12D-4D61-8895-BE6B3D753510","Name":"Ukraine Orphanage Assistance"}

{"Id":"44A476FA-5A58-439B-BD54-B67FAC5665A9","Name":"Poland Refugee Food and Clothing"}

## Configuring Ports

Can configure the port for the API layer without building code, but you do need to restart the PurpleCow.Web project to setup the listener to the new port.  The port is in:
Properties/Launchsettings.json
To get the UI to communicate to the new port the API is using, edit the target string in the proxy.conf.js file in the purplecow project here:  /src/app/


## Future Improvements

Create unit tests
Break NHibernate logic into better folder structure – use repository and unit of work layers for better separation of concerns
Autogenerate Nhibernate poco and mapping classes using T4 templates
Create services project to handle all business logic and abstract data access logic from the web project
Add a UI test framework like Jest 
Only used basic Angular setup, would likely add Ngrx and use it to handle data and API calls
Possibly break the application up into microservices


