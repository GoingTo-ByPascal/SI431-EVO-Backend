using GoingTo_API.Domain.Models;
using GoingTo_API.Tests.Steps;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace GoingTo_API.Tests
{
    [Binding]
    public class EditUserReviewsSteps
    {
        private IRestResponse _restResponse;
        private HttpStatusCode _statusCode;
        private List<Review> _reviews;
        private List<User> _user;

        [Given(@"que el usuario se encuentra en su perfil")]
        public void GivenQueElUsuarioSeEncuentraEnSuPerfil()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que el usuario  se encuentra en su lista de reseñas")]
        public void GivenQueElUsuarioSeEncuentraEnSuListaDeResenas()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"ingresa a la parte de reseñas")]
        public void WhenIngresaALaParteDeResenas()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"intenta ingresar a la parte de reseñas")]
        public void WhenIntentaIngresarALaParteDeResenas()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"ingresa la nueva reseña con su nueva valoración")]
        public void WhenIngresaLaNuevaResenaConSuNuevaValoracion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"decide eliminar una de sus reseñas")]
        public void WhenDecideEliminarUnaDeSusResenas()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"el sistema muestra la lista de todas las reseñas redactadas por el usuario")]
        public void ThenElSistemaMuestraLaListaDeTodasLasResenasRedactadasPorElUsuario()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"el sistema le mostrará un mensaje de diciendo: ""(.*)""")]
        public void ThenElSistemaLeMostraraUnMensajeDeDiciendo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"el sistema actualizará su reseña")]
        public void ThenElSistemaActualizaraSuResena()
        {
            ScenarioContext.Current.Pending();
        }
       
        [Then(@"el sistema elimina su reseña")]
        public void ThenElSistemaEliminaSuResena()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
