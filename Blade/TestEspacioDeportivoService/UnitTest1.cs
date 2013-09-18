using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEspacioDeportivoService
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestCrear()
        {
            EspacioDeportivoWS.EspacioDeportivoServiceClient proxy = new EspacioDeportivoWS.EspacioDeportivoServiceClient();
            EspacioDeportivoWS.EspacioDeportivo espacio = proxy.crear("prueba", 1);

            Assert.AreEqual("prueba", espacio.Nombre);
            Assert.AreEqual(1, espacio.Sede.Codigo);
        }

        [TestMethod]
        public void TestObtener()
        {
            EspacioDeportivoWS.EspacioDeportivoServiceClient proxy = new EspacioDeportivoWS.EspacioDeportivoServiceClient();
            EspacioDeportivoWS.EspacioDeportivo espacio = proxy.obtener(1);
            Assert.IsNotNull(espacio);
        }
        [TestMethod]
        public void TestListar()
        {
            EspacioDeportivoWS.EspacioDeportivoServiceClient proxy = new EspacioDeportivoWS.EspacioDeportivoServiceClient();
            List<EspacioDeportivoWS.EspacioDeportivo> espacios = proxy.lista().ToList();
            Assert.IsNotNull(espacios);
        }
        [TestMethod]
        public void TestListarSede()
        {
            SedeWS.SedeServiceClient proxy = new SedeWS.SedeServiceClient();
            List<SedeWS.Sede> sedes = proxy.listar().ToList();
            Assert.IsNotNull(sedes);
        }
    }
}
