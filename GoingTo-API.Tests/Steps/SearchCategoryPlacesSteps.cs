using System;
using TechTalk.SpecFlow;

namespace GoingTo_API.Tests
{
    [Binding]
    public class SearchCategoryPlacesSteps
    {
        [Given(@"Dado que el usuario  se encuentra en la búsqueda de GoingTo")]
        public void GivenDadoQueElUsuarioSeEncuentraEnLaBusquedaDeGoingTo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando realiza una búsqueda de un sitio por medio de su categoría\.")]
        public void WhenCuandoRealizaUnaBusquedaDeUnSitioPorMedioDeSuCategoria_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando realiza una búsqueda de los sitios por medio de una determinada categoría que no se encuentra registrada\.")]
        public void WhenCuandoRealizaUnaBusquedaDeLosSitiosPorMedioDeUnaDeterminadaCategoriaQueNoSeEncuentraRegistrada_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando realiza una búsqueda de los sitios por medio de una determinada categoría pero tiene problemas con su conexión a Internet\.")]
        public void WhenCuandoRealizaUnaBusquedaDeLosSitiosPorMedioDeUnaDeterminadaCategoriaPeroTieneProblemasConSuConexionAInternet_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entonces el sistema muestra la lista de todos los sitios que forman parte de esa categoría\.")]
        public void ThenEntoncesElSistemaMuestraLaListaDeTodosLosSitiosQueFormanParteDeEsaCategoria_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entonces el sistema muestra un mensaje de error diciendo ""(.*)""")]
        public void ThenEntoncesElSistemaMuestraUnMensajeDeErrorDiciendo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
