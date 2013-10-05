using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace TestHorarioService
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Crear()
        {
            string horarioJson = "{\"Codigo\":1,\"Dia\":\"jueves\",\"HoraInicio\":\"08:15\",\"HoraFin\":\"15:00\"}";
            byte[] data = Encoding.UTF8.GetBytes(horarioJson);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:22057/Horarios.svc/Horarios");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";

            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string horarioObtenidoJson = reader.ReadToEnd();

            Assert.AreEqual("\"El horario del espacio deportivo registrado exitosamente\"", horarioObtenidoJson);
        }


        [TestMethod]
        public void CrearError()
        {
            try{
            string horarioJson = "{\"Codigo\":1,\"Dia\":\"jueves\",\"HoraInicio\":\"08:00\",\"HoraFin\":\"15:00\"}";
            byte[] data = Encoding.UTF8.GetBytes(horarioJson);
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:22057/Horarios.svc/Horarios");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string horarioObtenidoJson = reader.ReadToEnd();
            
            
            }catch (WebException e){
                HttpWebResponse resError=(HttpWebResponse)e.Response;//
                StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                string rpta = reader2.ReadToEnd();
                Assert.AreEqual("{\"Codigo\":\"ERR003\",\"Mensaje\":\"Horario ya registrado\"}", rpta);
            }            
        }


        [TestMethod]
        public void ObtenerError()
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:22057/Horarios.svc/Horarios/1/ABC");
                req.Method = "GET";
                req.ContentType = "application/json";
            
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string horarioObtenidoJson = reader.ReadToEnd();

            
            }catch (WebException e){
                HttpWebResponse resError=(HttpWebResponse)e.Response;//
                StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                string rpta = reader2.ReadToEnd();
                Assert.AreEqual("{\"Codigo\":\"ERR001\",\"Mensaje\":\"Horario no disponible\"}", rpta);
            }
        }
    }
}
