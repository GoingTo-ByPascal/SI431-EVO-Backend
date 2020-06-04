Feature: PlaceTips
	Greta,
desea poder ver, agregar y modificar la los tips de un lugar al que quiere viajar o a viajado.
para tenerlos en cuenta al momento de seleccionar sus viajes o actividades por hacer.

@mytag
Scenario: El usuario busca los tips de un lugar al que esta viajando.
	Given Dado que el usuario escoge un lugar  
	When Cuando el usuario da click en el lugar escogido
	Then Entonces: el sistema despliega los tips del lugar escogido.
Scenario: El usuario quiere agregar un tip del lugar al que viajo.
	Given Dado que el usuario escoge un lugar al cual viajo
	When Cuando el usuario da click en agregar tip
	Then Entonces el sistema le pide que ingrese un tip con un máximo de 140 caracteres.
Scenario: El usuario quiere modificar un tip del lugar al que viajo.
	Given Dado que el usuario escoge un lugar al cual viajo
	When Cuando el usuario da click en modificar tip
	Then Entonces el sistema le pide que ingrese un tip con un máximo de 140 caracteres.
Scenario: El usuario quiere eliminar un tip del lugar al que viajo.
	Given Dado que el usuario escoge un lugar al cual viajo
	When Cuando el usuario da click en eliminar tip
	Then Entonces el sistema despliega una ventada de confirmación y elimina el tip.