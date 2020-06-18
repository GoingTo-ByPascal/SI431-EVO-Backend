Feature: EditPartnerEstates
	As User Partner
I want Poder publicar distintos paquetes u ofertas de viajes y tener control para modificar estos mismos
So that tener facilidades de viajes para los usuarios de Goingto y puedan fidelizarse con sus servicios.

@mytag
Scenario: Get Estates by Partner ID and Locatable ID
	Given I am a partner
	When I make a Get request to "/partners/{partnerId}/locatables/{locatableId}/estates"
	Then I receive a estates resource list

Scenario: Post Estate by Partner ID and Locatable ID
	Given I am a partner
	When I make a Post request to "/partners/{partnerId}/locatables/{locatableId}/estates"
	Then I receive the estate resource I posted  
	Examples: 
	| name           |        description      |
	| "Estate test"  |  Test Estate for WEB API|

Scenario: Delete Promo by Partner ID
	Given I am a partner
	When I make a Delete request to "/partners/{partnerId}/locatables/{locatableId}/estates"
	Then I receive the estate resource I deleted