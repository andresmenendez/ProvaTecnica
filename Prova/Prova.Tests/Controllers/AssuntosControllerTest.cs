using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prova;
using Prova.Controllers;
using Prova.Models;

namespace Prova.Tests.Controllers
{
    /// <summary>
    /// Summary description for AssuntosControllerTest
    /// </summary>
    [TestClass]
    public class AssuntosControllerTest
    {
        [TestMethod]
        public void TestEnviarComunicado()
        {
            Assunto assunto = new Assunto() { IdMorador = 1, Conteudo = "Teste", TipoAssunto = 1 };
            ApiController api = new ApiController();
            ViewResult result = api.EnviarComunicado(assunto) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
            
        }
        
    }
}
