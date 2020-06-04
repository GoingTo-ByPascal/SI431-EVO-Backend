Feature: SearchCountryInfo
	As Jaime and Greta
Quiero conocer el mundo, empezar por algun pais y asi seguir avanzando, Asi llenarme de nuevos paises ademas de los que ya son conocidos.

@mytag
Scenario: El usuario desea buscar un pais que sea de su interés.
	Given el usuario usa el buscador goingto 
	When encuentre de manera satisfactoria dicho pais 
	Then puede visualizar la información del pais.

Scenario: El usuario busca un pais nuevo que desea conocer
	Given que el usuario utiliza la herramienta de busqueda 
	When  encuentre de manera satisfactoria dicho pais
	Then puede visualizar información relevante de dicho pais.

Scenario: 
	Given Dado que el usuario utiliza la Itineraries 
	When Cuando encuentre de manera satisfactoria dicho pais
	Then Entonces puede agregar a favoritos ó añadirlo a su Itinerary

