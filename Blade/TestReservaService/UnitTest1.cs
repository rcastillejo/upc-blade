﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using ReservasServices.Dominio;

namespace TestReservaService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearOk()
        {
            string reservaJson = "{\"CodigoEspacio\":1,\"FechaInicio\":\"2013-10-09 09:00:00\",\"CantidadHoras\":2}";
            byte[] data = Encoding.UTF8.GetBytes(reservaJson);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/Reservas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";

            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string reservaObtenidoJson = reader.ReadToEnd();

            Assert.IsTrue(reservaObtenidoJson.Contains("La reserva registrada exitosamente "));
        }


        [TestMethod]
        public void CrearError()
        {
            try{
                string reservaJson = "{\"CodigoEspacio\":1,\"FechaInicio\":\"2013-10-14 09:00:00\",\"CantidadHoras\":2}";
                byte[] data = Encoding.UTF8.GetBytes(reservaJson);

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/Reservas");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";

                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string reservaObtenidoJson = reader.ReadToEnd();
            }
            catch (WebException e)
            {
                HttpWebResponse resError = (HttpWebResponse)e.Response;//
                StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                string resultado = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Error error = js2.Deserialize<Error>(resultado);
                Assert.AreEqual("El espacio deportivo ya ha sido reservado", error.Mensaje);
              }
        }

        [TestMethod]
        public void ListarOk()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/Reservas");
            req.Method = "GET";

            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string resultadoObtenidoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reserva> reservas = js.Deserialize<List<Reserva>>(resultadoObtenidoJson);

            Assert.IsTrue(reservas.Count > 0);
        }

        //reserva.Codigo, reserva.CodigoEspacio, reserva.Dia, reserva.CantidadHoras, reserva.FechaInicio, reserva.FechaFin, reserva.Estado
         [TestMethod]
        public void Modificar()
        {
            string reservaJson = "{\"Codigo\":1,\"CodigoEspacio\":2,\"Dia\":\"jueves\",\"FechaInicio\":\"2013-10-09 09:00:00\",\"FechaFin\":\"2013-10-09 11:00:00\",\"CantidadHoras\":2,\"Estado\":\"RESERVADO\"}";
            byte[] data = Encoding.UTF8.GetBytes(reservaJson);


            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/Reservas");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";

            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string reservaObtenidoJson = reader.ReadToEnd();

            Assert.IsTrue(reservaObtenidoJson.Contains("La reserva registrada exitosamente"));
        }
    }
}
