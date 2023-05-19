Feature: UpdateBooking
	As a user of api I want to update booking 


	Scenario: User can update booking
		Given a user has created his new booking
		And he created rest request
		When he puts his data
		Then he receives 200OK status code
		And he gets valid response