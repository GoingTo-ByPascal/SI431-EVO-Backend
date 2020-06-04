Feature: EditUserReviews
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: El usuario visualiza su lista de comentarios
	Given que  el usuario se encuentra en su perfil 
	When ingresa  a la parte de reseñas
	Then el sistema  muestra la lista de todas las reseñas redactadas por el usuario

Scenario: El usuario no cuenta con reseñas
	Given que  el usuario se encuentra en su perfil 
	When intenta  ingresar a la parte de reseñas
	Then el sistema  le mostrará un mensaje de diciendo: "No cuenta con reseñas"

Scenario: El usuario actualiza una reseña 
	Given que  el usuario  se encuentra en su lista de reseñas 
	When ingresa  la nueva reseña con su nueva valoración
	Then el sistema  actualizará su reseña

Scenario: El usuario  borra una de sus reseñas
	Given que el  usuario  se encuentra en su lista de reseñas 
	When decide  eliminar una de sus reseñas
	Then el  sistema elimina su reseña
