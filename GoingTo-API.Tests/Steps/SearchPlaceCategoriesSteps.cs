using System;
using TechTalk.SpecFlow;

namespace GoingTo_API.Tests
{
    [Binding]
    public class SearchPlaceCategoriesSteps
    {
        [Given(@"Dado que se tiene un sitio que ofrece uno o muchos tipos de turismo\.")]
        public void GivenDadoQueSeTieneUnSitioQueOfreceUnoOMuchosTiposDeTurismo_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Dado que el usuario  se encuentra en la búsqueda de GoingTo")]
        public void GivenDadoQueElUsuarioSeEncuentraEnLaBusquedaDeGoingTo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando  ingresa a la búsqueda de GoingTo y buscan un sitio\.")]
        public void WhenCuandoIngresaALaBusquedaDeGoingToYBuscanUnSitio_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando realiza una búsqueda de las categorías de un determinado sitio que no se encuentra registrado\.")]
        public void WhenCuandoRealizaUnaBusquedaDeLasCategoriasDeUnDeterminadoSitioQueNoSeEncuentraRegistrado_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando realiza una búsqueda de las categorías de un determinado sitio pero tiene problemas de conexión")]
        public void WhenCuandoRealizaUnaBusquedaDeLasCategoriasDeUnDeterminadoSitioPeroTieneProblemasDeConexion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entonces pueden ver las diferentes categorías de turismo que ofrece este sitio")]
        public void ThenEntoncesPuedenVerLasDiferentesCategoriasDeTurismoQueOfreceEsteSitio()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entonces el sistema le mostrará un mensaje de error diciendo ""(.*)""")]
        public void ThenEntoncesElSistemaLeMostraraUnMensajeDeErrorDiciendo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entonces el sistema le mostrará un mensaje de error diciendo ""Error de conectividad, por favor inténtalo")]
        public void ThenEntoncesElSistemaLeMostraraUnMensajeDeErrorDiciendoErrorDeConectividadPorFavorIntentalo()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
