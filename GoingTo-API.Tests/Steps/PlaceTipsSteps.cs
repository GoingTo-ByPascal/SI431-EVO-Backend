using System;
using TechTalk.SpecFlow;

namespace GoingTo_API.Tests
{
    [Binding]
    public class PlaceTipsSteps
    {
        [Given(@"Dado que el usuario escoge un lugar")]
        public void GivenDadoQueElUsuarioEscogeUnLugar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Dado que el usuario escoge un lugar al cual viajo")]
        public void GivenDadoQueElUsuarioEscogeUnLugarAlCualViajo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando el usuario da click en el lugar escogido")]
        public void WhenCuandoElUsuarioDaClickEnElLugarEscogido()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando el usuario da click en agregar tip")]
        public void WhenCuandoElUsuarioDaClickEnAgregarTip()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando el usuario da click en modificar tip")]
        public void WhenCuandoElUsuarioDaClickEnModificarTip()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Cuando el usuario da click en eliminar tip")]
        public void WhenCuandoElUsuarioDaClickEnEliminarTip()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entonces: el sistema despliega los tips del lugar escogido\.")]
        public void ThenEntoncesElSistemaDespliegaLosTipsDelLugarEscogido_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entonces el sistema le pide que ingrese un tip con un máximo de (.*) caracteres\.")]
        public void ThenEntoncesElSistemaLePideQueIngreseUnTipConUnMaximoDeCaracteres_(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entonces el sistema despliega una ventada de confirmación y elimina el tip\.")]
        public void ThenEntoncesElSistemaDespliegaUnaVentadaDeConfirmacionYEliminaElTip_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
