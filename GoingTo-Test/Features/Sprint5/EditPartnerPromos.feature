Feature: EditPartnerPromos
	As User Partner
I want añadir, editar y/o eliminar mis reseñas
So that yo puedo tener acceso a las promociones que me gustarían ofrecer

@mytag
Scenario: Get Promos by Partner ID
	Given I am a partner
	When I make a Get request to "/partners/{partnerId}/promos"
	Then I receive a promo resource list

Scenario: Post Promo by Partner ID
	Given I am a partner
	When I make a Post request to "/partners/{partnerId}/promos"
	Then I receive the promo resource I posted  
	Examples: 
	| text                  | discount| 
	| "Bienvenido Viajero"  |  0.12   |

Scenario: Delete Promo by Partner ID
	Given I am a partner
	When I make a Delete request to "/partners/{partnerId}/promos"
	Then I receive the promo resource I deleted
