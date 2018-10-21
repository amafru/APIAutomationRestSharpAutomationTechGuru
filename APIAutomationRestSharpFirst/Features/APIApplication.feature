Feature: APIApplication
	

@GetTests
Scenario: Get API response using given endpoint
Given I have an endpoint /endpoint/
When I call GET method of API
Then I should get the correct API response in json format 

#Commented out my own scenario before as it'll be implemented in another project 
#Scenario: Implement GET method as above using reqres endpoint
#Given I have a reqres endpoint /api/users?page=2/
#When  I call the GET http method of API
#Then I should get back the correct response in json format

@GetTests
#http://mydomain.com/userinformation/userid
Scenario Outline: Get user information using userId
Given I have an endpoint /userinformation/
When I call the GET method to get user information using <userid>
Then I will get the user information

Examples: User Info
| UserId    |
| user10001 |

@GetTests
#http://mydomain.com/userinformation/userid/AccountInformation?account={accountNumber}
Scenario Outline: Get user information using userId and accountNumber
Given I have an endpoint /userinformation/
When I call GET method using <userId> and <accountNumber>
Then I will get user account information

Examples: User Info
| userId    | accountNumber |
| user10001 | 123456789     |

@PostTests
Scenario: User registration for given endpoint
Given I have an endpoint /user/
When I call a POST method to register a user 
Then I will be registered successfully 




