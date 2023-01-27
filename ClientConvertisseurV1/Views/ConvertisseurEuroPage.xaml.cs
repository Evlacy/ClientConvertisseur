// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Portable;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }

        private ObservableCollection<Devise> devises;

        public ObservableCollection<Devise> Devises
        {
            get { return devises; }
            set { devises = value;
                OnPropertyChanged(nameof(Devises));
            }
        }

        private Devise deviseSelected;

        public Devise DeviseSelected
        {
            get { return deviseSelected; }
            set
            {
                deviseSelected = value;
                OnPropertyChanged(nameof(DeviseSelected));
            }
        }

        private Double montantEuros;

        public Double MontantEuros
        {
            get { return montantEuros; }
            set { montantEuros = value;
            }
        }

        private double montantDevise;

        public double MontantDevise
        {
            get { return montantDevise; }
            set
            {
                montantDevise = value;
                OnPropertyChanged(nameof(MontantDevise));
            }
        }

        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7232/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
                MessageAsync("Erreur", "API non disponible !");
            else
                Devises = new ObservableCollection<Devise>(result);
        }

        private async void MessageAsync(string title, string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "Ok"
            };

            dialog.XamlRoot = this.Content.XamlRoot;
            await dialog.ShowAsync();
        }

        private void Bouton_Click(object sender, RoutedEventArgs e)
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
    }
}
