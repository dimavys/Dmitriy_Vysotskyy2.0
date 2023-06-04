Feature: UpdateBooking
	As a user of api I want to update booking 

	Scenario: User can update booking
		Given valid data for post has been prepared
		And user executes post request
		And valid data for put has been prepared
		When he puts his data
		Then he receives 200 OK status code
		And he gets valid response
		
	Scenario: User cannot update booking
		Given valid data for post has been prepared
		And user executes post request
		And invalid data for put has been prepared
		When he puts his data
		Then he receives 400 Bad request status code