Feature: SearchPlaceCategories
	As Jaime and Greta
Quiero poder buscar un sitio y saber qué categoría de turismo ofrece para determinar cuál es el más ideal para mí.

@mytag
Scenario: El usuario realiza una búsqueda de las categorías por medio de los sitios.
	Given Dado que se tiene un sitio que ofrece uno o muchos tipos de turismo. 
	When Cuando  ingresa a la búsqueda de GoingTo y buscan un sitio.
	Then Entonces pueden ver las diferentes categorías de turismo que ofrece este sitio

Scenario: El usuario realiza una búsqueda de las categorías por medio de los sitios y ocurre un problema.
	Given Dado que el usuario  se encuentra en la búsqueda de GoingTo
	When Cuando realiza una búsqueda de las categorías de un determinado sitio que no se encuentra registrado.
	Then Entonces el sistema le mostrará un mensaje de error diciendo "Sitio no encontrado, por favor ingrese un sitio valido"
	
Scenario: El usuario realiza una búsqueda de las categorías por medio de los sitios y tiene problemas de conexión
	Given Dado que el usuario  se encuentra en la búsqueda de GoingTo
	When Cuando realiza una búsqueda de las categorías de un determinado sitio pero tiene problemas de conexión
	Then Entonces el sistema le mostrará un mensaje de error diciendo "Error de conectividad, por favor inténtalo 