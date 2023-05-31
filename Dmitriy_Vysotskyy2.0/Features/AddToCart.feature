@ShopTag
Feature: User can add to cart item
    As a logged in user 
    I want to add selected item to cart
    
    Scenario: Logged in user can add item to cart
        Given a user has logged in
        And the user has opened the item "Iphone 6 32gb"
        When the user has clicks Add to cart "Iphone 6 32gb" button
        Then the user gets "Product added." alert