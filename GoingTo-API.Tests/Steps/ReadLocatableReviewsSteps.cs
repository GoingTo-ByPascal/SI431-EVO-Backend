using System;
using TechTalk.SpecFlow;

namespace GoingTo_API.Tests
{
    [Binding]
    public class ReadLocatableReviewsSteps
    {
        [Given(@"El usuario se encuentra en la página de algún lugar")]
        public void GivenElUsuarioSeEncuentraEnLaPaginaDeAlgunLugar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"El usuario se encuentra en la página de reseñas de un lugar")]
        public void GivenElUsuarioSeEncuentraEnLaPaginaDeResenasDeUnLugar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando el usuario accede a las reseñas del lugar")]
        public void WhenCuandoElUsuarioAccedeALasResenasDelLugar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando el usuario le da al botón de like de una reseña")]
        public void WhenCuandoElUsuarioLeDaAlBotonDeLikeDeUnaResena()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando el usuario ingresa texto en el espacio para ingresar texto y lo envía")]
        public void WhenCuandoElUsuarioIngresaTextoEnElEspacioParaIngresarTextoYLoEnvia()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando el usuario le da click al boton de compartir")]
        public void WhenCuandoElUsuarioLeDaClickAlBotonDeCompartir()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"El sistema le muestra la página de reseñas de ese mismo lugar")]
        public void ThenElSistemaLeMuestraLaPaginaDeResenasDeEseMismoLugar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"El sistema le muestra el mensaje ""(.*)""")]
        public void ThenElSistemaLeMuestraElMensaje(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"El sistema suma \+(.*) al numero de likes de la reseña")]
        public void ThenElSistemaSumaAlNumeroDeLikesDeLaResena(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"El sistema registra el comentario de la reseña y lo agrega")]
        public void ThenElSistemaRegistraElComentarioDeLaResenaYLoAgrega()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"El sistema le muestra la pantalla correspondiente a donde desea compartir esa reseña")]
        public void ThenElSistemaLeMuestraLaPantallaCorrespondienteADondeDeseaCompartirEsaResena()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
