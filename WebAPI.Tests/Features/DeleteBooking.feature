Feature: DeleteBooking
	As a user of api I want to delete booking

	Scenario: User can delete booking
		Given valid data for post has been prepared
		And user executes post request
		And a user has specified id
		When user executes delete request
		Then he receives 201 Created status code
		And Booking Id must not be present among the others
		
	Scenario: User cannot delete booking
		Given a user has specified invalid id
		When user executes delete request
		Then he receives 405 Method not allowed status code