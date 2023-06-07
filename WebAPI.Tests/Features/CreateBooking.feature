Feature: User can create feature
	As a user of api I want to create booking

	Scenario: User can create a booking
		Given valid data for post has been prepared
		When user executes post request
		Then he receives 200 OK status code
		And he gets valid response
		And bookingId must be present among others
		And get booking by id data must be equal to created post data
	
	Scenario: User can't create a booking
		Given invalid data for post has been prepared
		When user executes post request
		Then he receives 500 Internal server error code
	