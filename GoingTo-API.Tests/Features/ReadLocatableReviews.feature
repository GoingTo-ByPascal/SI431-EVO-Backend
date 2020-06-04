Feature: ReadLocatableReviews
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: El usuario accede a la lista de reseñas de un lugar
	Given El usuario se encuentra en la página de algún lugar
	When Cuando el usuario accede a las reseñas del lugar
	Then El sistema le muestra la página de reseñas de ese mismo lugar

Scenario: El usuario accede a la lista de reseñas de un lugar sin reseñas
	Given El usuario se encuentra en la página de algún lugar 
	When Cuando el usuario accede a las reseñas del lugar
	Then El sistema le muestra el mensaje "Este lugar no cuenta con reseñas"

Scenario: El usuario quiere demostrar afecto por una reseña
	Given El usuario se encuentra en la página de reseñas de un lugar 
	When Cuando el usuario le da al botón de like de una reseña
	Then El sistema suma +1 al numero de likes de la reseña

Scenario: El usuario quiere comentar una reseña
	Given El usuario se encuentra en la página de reseñas de un lugar 
	When Cuando el usuario ingresa texto en el espacio para ingresar texto y lo envía
	Then El sistema registra el comentario de la reseña y lo agrega

Scenario: El usuario quiere compartir una reseña
	Given El usuario se encuentra en la página de reseñas de un lugar 
	When Cuando el usuario le da click al boton de compartir
	Then El sistema le muestra la pantalla correspondiente a donde desea compartir esa reseña