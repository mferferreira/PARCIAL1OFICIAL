using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcialFernandaFerreira.Controllers;

namespace UnitTestFernanda
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGet()
        {
            //Arrange
            FernandaFerreiraAPIsController controlador = new FernandaFerreiraAPIsController();
            //Act
            var listaFernandaFerreiraAPI = controlador.GetFernandaFerreiraAPIs();
            //Asser
        }
    }
}
