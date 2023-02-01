using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.ViewModels;
using Windows.Media.Protection.PlayReady;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void WSServiceTest()
        {
            WSService service = new WSService("https://localhost:7232/api/");
            Assert.IsNotNull(service);
        }

        [TestMethod()]
        public void GetDevisesAsyncTests()
        {
            WSService service = new WSService("https://localhost:7232/api/");
            var result = service.GetDevisesAsync("devises").Result;

            Assert.IsNotNull(result, "Non nul attendu");
            var devise = result[0];
            Assert.IsInstanceOfType(devise, typeof(Devise), "Type Devise attendu");
            Assert.AreEqual(3, result.Count, "3 devises attendu");
        }
    }
}