Feature: EditPartnerProfile
	As User Partner
I want Poder llenar datos relevantes de mi perfil de partner
So that tener información para los usuarios de Goingto y puedan saber más de sus servicios.

@mytag
Scenario: Get Partner Profile by Partner ID 
	Given I am a partner
	When I make a Get request to "/partners/ {partnerId}/promos"
	Then I receive a profile resource list

Scenario: Post Partner Profile by Partner ID
	Given I am a partner
	When I make a Post request to "/partners/{partnerId}/locatables/{locatableId}/estates"
	Then I receive the profile resource I posted  
	Examples: 
	| name     | telephone | email               | address               |
	| "Airbnb" | 8101011   | "airbnb@example.com | "calle alcanfores 343"|

Scenario: Delete Promo by Partner ID
	Given I am a partner
	When I make a Delete request to "/partners/{partnerId}/locatables/{locatableId}/estates"
	Then I receive the estate resource I deleted