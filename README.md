# CodingChallengeRapidPay
Coding Challenge

# How to start this application?
Right click on RapidPayChallenge solution and Set start up projects. 
Here you need to select multiple start up projects and than select RapidPay.Service.Identity and RapidPay.Service.PaymentApi should have the action "Start"

There is no need to execute any SQL code once it was made with Entity Framework in memory. All the data that this application uses is lost when you close it.

# Application ready to start
Once this application is up and running, you will come across two api's (Identity and Payment).

In order to use any functionality on Payment, you need to create na authentication. 

Identity Api has two endpoints (Create User and Sign In). 
Createuser - as its name says, you can create an user. 
SignIn - you can validate your credentials and also access you token.

If your credentials are valid, your token will be in the response body, there is a attribue RESULT where you can find it.

After having this token, you can go to Payment api and authenticate. A single click on the Authorization button will open a modal where you can insert you token.

Payment Api has three endpoints. 
CreateCard - Here you can create a card. It will return a 15 lenght number,which is your card number, and add R$ 100 to your balance (just to play around). 
Payment - Where you can make a payment. You need to inform a valid card number and the amount to be paid. 
GetBalance - Where you can retrieve you card information. Your balance is here. 

About fee price.
There is a BackgroundService in Payment Api where fee is calculated. The requirementes say it should be applied every hour. however, my purpors here is to show it working and it was set to run every 30s.


