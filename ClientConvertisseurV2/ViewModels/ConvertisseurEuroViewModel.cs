using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel : ObservableObject
    {

        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        // Public pour tests
        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7232/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
                MessageAsync("Erreur", "API non disponible !");
            else
                Devises = new ObservableCollection<Devise>(result);
            Devises = new ObservableCollection<Devise>(result);
        }

        public IRelayCommand BtnSetConversion { get; }

        // Public pour tests
        public void ActionSetConversion()
        {
            if (DeviseSelected == null)
            {
                MessageAsync("Erreur", "Sélectionner une devise !");
            }
            else
            {
                MontantDevise = MontantEuros * DeviseSelected.Taux;
            }
        }

        private async void MessageAsync(string title, string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "Ok"
            };

            dialog.XamlRoot = App.MainRoot.XamlRoot; // Erreurs
            await dialog.ShowAsync();
        }

        private ObservableCollection<Devise> devises;

        public ObservableCollection<Devise> Devises
        {
            get { return devises; }
            set
            {
                devises = value;
                OnPropertyChanged();
            }
        }

        private Devise deviseSelected;

        public Devise DeviseSelected
        {
            get { return deviseSelected; }
            set
            {
                deviseSelected = value;
                OnPropertyChanged();
            }
        }

        private Double montantEuros;

        public Double MontantEuros
        {
            get { return montantEuros; }
            set
            {
                montantEuros = value;
            }
        }

        private double montantDevise;

        public double MontantDevise
        {
            get { return montantDevise; }
            set
            {
                montantDevise = value;
                OnPropertyChanged();
            }
        }
    }
}
