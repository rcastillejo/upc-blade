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
        public void TestObtener()
        {
            EspacioDeportivoWS.EspacioDeportivoServiceClient proxy = new EspacioDeportivoWS.EspacioDeportivoServiceClient();
            EspacioDeportivoWS.EspacioDeportivo espacio = proxy.obtener(1);
            Assert.IsNotNull(espacio);
        }
    }
}
