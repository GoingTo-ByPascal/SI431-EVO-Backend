Feature: AddNewServicesToEstate
As User Partner
I want Poder llenar una lista con todos los tipos de servicios que brindamos a nuestros clientes.
So that Poder brindar información clara y detallada de los servicios al cliente.

@mytag
Scenario: Get Services from Estate ID
	Given I am a partner
	When I make a Get request to "/estate/{estateId}/services"
	Then I receive a services resource list

Scenario: Assign Service to Estate
	Given I am a partner
	When I make a Post request to "/estate/{estateId}/services/{servicesId}"
	Then I receive the service resource I posted  
	Examples: 
	| serviceId | estateId | text	 |
	|   2       |   1      |"Hospedaje"|

Scenario: Unassign Service to Estate
	Given I am a partner
	When I make a Delete request to "/estate/{estateId}/services/{servicesId}"
	Then I receive the service resource I deleted

Scenario: Post service by Estate Id and Service Id
	Given I am a partner
	When I make a Post request to "/estate/{estateId}/services/"
	Then I receive the service resource I posted  
	Examples: 
	| name	 |
	| "Web Hotel"|