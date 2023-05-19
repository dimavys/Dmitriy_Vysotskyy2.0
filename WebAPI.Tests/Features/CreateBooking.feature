Feature: User can create feature
	As a user of api I want to create booking

	Scenario: User can create a booking
		Given a user has created his booking
		And he created rest request
		When he posts his data
		Then he receives 200OK status code
		And he gets valid response
	
	Scenario: User can't create a booking
		Given a user has invalid data
		And he created rest request
		When he posts his data
		Then he receives wrong status code
	