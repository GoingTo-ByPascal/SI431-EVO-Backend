Feature: ReseñasDeUnServicio
As Partner Name
I want Deseo poder ver las reseñas que mis clientes hacen de mis servicios
So that puedo mejorar mi servicio y ganar visibilidad entre otros servicios de mi rubro.


@mytag
Scenario: Get reviews from EstateService
	Given I am a partner
	When I make a Get request to "/estate/{estateId}/reviews"
	Then I receive a reviews resource list
