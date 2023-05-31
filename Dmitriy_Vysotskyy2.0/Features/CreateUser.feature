@ShopTag
Feature: User can create an account
    As a user 
    I want to create an account when I insert valid data
    
    Scenario: Users with invalid data cannot create account
        Given invalid data for login has been prepared
        When user fills signup popup with data
        Then user gets "This user already exist." alert
        
    Scenario: Users with valid data can create account
        Given valid data for login has been prepared
        When user fills signup popup with data
        Then user gets "Sign up successful." alert
  

    