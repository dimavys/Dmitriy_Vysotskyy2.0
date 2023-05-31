@ShopTag
Feature: User can remove added item from cart
	As a user
	I want to remove an item added to cart 
	
	Scenario: Logged in user can add item to cart
		Given an existing user has logged in
		And user added "Samsung galaxy s6" to cart
		When user clicks delete "Samsung galaxy s6" button
		Then "Samsung galaxy s6" must be deleted