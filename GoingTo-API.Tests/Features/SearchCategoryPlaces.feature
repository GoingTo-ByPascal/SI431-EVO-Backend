Feature: SearchCategoryPlaces
	As Jaime and Greta
I want poder buscar todos los sitios que pertenezcan a una determinada categoría.
So that poder elegir cual es el sitio ideal para hospedarse.

@mytag
Scenario: El usuario realiza una búsqueda de los lugares de una determinada categoría. 
	Given Dado que el usuario  se encuentra en la búsqueda de GoingTo
	When Cuando realiza una búsqueda de un sitio por medio de su categoría.
	Then Entonces el sistema muestra la lista de todos los sitios que forman parte de esa categoría. 

Scenario: El usuario realiza una búsqueda de los lugares de una determinada categoría y ocurre un problema
	Given Dado que el usuario  se encuentra en la búsqueda de GoingTo
	When Cuando realiza una búsqueda de los sitios por medio de una determinada categoría que no se encuentra registrada.
	Then Entonces el sistema muestra un mensaje de error diciendo "Categoría no valida, por favor ingrese una categoría valida." 

Scenario:  El usuario realiza una búsqueda de los lugares de una determinada categoría y ocurre un problema de 
	Given Dado que el usuario  se encuentra en la búsqueda de GoingTo
	When Cuando realiza una búsqueda de los sitios por medio de una determinada categoría pero tiene problemas con su conexión a Internet.
	Then Entonces el sistema muestra un mensaje de error diciendo "Error de conexión, por favor intentelo más tarde." 

