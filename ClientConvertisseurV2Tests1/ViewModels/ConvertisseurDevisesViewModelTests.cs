using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurDevisesViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurDevisesViewModelTest()
        {
            ConvertisseurDevisesViewModel convertisseurDevise = new ConvertisseurDevisesViewModel();
            Assert.IsNotNull(convertisseurDevise);
        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurDevisesViewModel convertisseurDevise = new ConvertisseurDevisesViewModel();
            //Act
            convertisseurDevise.GetDataOnLoadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(convertisseurDevise.Devises);
        }

        /// <summary>
        /// Test conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionSetConversionTest()
        {
            // Arrange
            // Création d'un objet de type ConvertisseurEuroViewModel
            ConvertisseurDevisesViewModel convertisseur = new ConvertisseurDevisesViewModel();

            // Property MontantEuro = 100 (par exemple)
            convertisseur.MontantDevise = 100;

            // Création d'un objet Devise, dont Taux=0.5
            Devise devise = new Devise(1, "MBA", 0.5);

            // Property DeviseSelectionnee = objet Devise instancié
            convertisseur.DeviseSelected = devise;

            // Act
            // Appel de la méthode ActionSetConversion
            convertisseur.ActionSetConversion();

            // Assert
            // Assertion : MontantDevise est égal à la valeur espérée 107 
            Assert.AreEqual(convertisseur.MontantEuros, 200, "Doit etre egale à 150");
        }
    }
}