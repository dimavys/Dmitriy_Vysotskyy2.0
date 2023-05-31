@ShopTag
Feature: User can place order
    As a user
    I want to place an order after I added items to cart
    
    Scenario: Logged in users can place an order
        Given user logged in
        And user has added "Iphone 6 32gb" to cart
        When user inserts correct data and clicks place order button
        Then order has been created
