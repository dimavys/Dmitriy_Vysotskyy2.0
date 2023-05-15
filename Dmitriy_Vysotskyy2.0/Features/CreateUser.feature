Feature: User can create an account
    As a user 
    I want to create an account when I insert valid data
    
    Scenario: Users with invalid data cannot create account
        Given a user has come to clicked sign up
        And a user doesn't have valid data
        When user inserts that data
        Then user gets "This user already exist." alert
        
    
    Scenario: Users with valid data can create account
        Given a user has come to clicked sign up
        And a user has valid data
        When user inserts that data
        Then user gets "Sign up successful." alert
    
    @after
    Scenario: Tear down browser
        Then close the browser

    