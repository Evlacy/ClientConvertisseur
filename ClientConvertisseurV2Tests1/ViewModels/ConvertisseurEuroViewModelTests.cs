using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }

        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary>
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Act
            convertisseurEuro.GetDataOnLoadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(convertisseurEuro.Devises);
        }

        /// <summary>
        /// Test conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionSetConversionTest()
        {
            // Arrange
            // Création d'un objet de type ConvertisseurEuroViewModel
            ConvertisseurEuroViewModel convertisseur = new ConvertisseurEuroViewModel();

            // Property MontantEuro = 100 (par exemple)
            convertisseur.MontantEuros = 100;

            // Création d'un objet Devise, dont Taux=1.07
            Devise devise = new Devise(1, "MBA", 1.07);

            // Property DeviseSelectionnee = objet Devise instancié
            convertisseur.DeviseSelected = devise;

            // Act
            // Appel de la méthode ActionSetConversion
            convertisseur.ActionSetConversion();

            // Assert
            // Assertion : MontantDevise est égal à la valeur espérée 107 
            Assert.AreEqual(convertisseur.MontantDevise, 107, "Doit etre egale à 107");
        }
    }
}