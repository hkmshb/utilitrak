UtiliTrak
=========

UtiliTrak is a lightweight electric infrastructure management (EIM) web based
application for maintaining comprehensive records on principal network facilities,
network assets, faults and maintenance activities for an electricity distribution
company. 


## Database Setup
Create database by running migration. For a binary deployment, in the bin directory 
issues:

    $ dotnet ef database update

However, for the development machine issues the command below assuming the current
directly is the `src` directory.

    $ cd UtiliTrak.Data
    $ dotnet ef --startup-project ../UtiliTrak.Web.Api/ database update

To create the database manually issue the commands below. However you'd still have
to run the update command above to have the tables created.

Replace username and database name accordingly. 

    $ sudo su postgres -c "psql -c "\CREATE USER utrak WITH PASSWORD '****';\""
    $ sudo su postgres -c "psql -c "\CREATE DATABASE utilitrak OWNER utrak;\""
