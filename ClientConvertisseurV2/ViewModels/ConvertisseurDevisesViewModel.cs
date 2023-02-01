using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDevisesViewModel : ConvertisseurVM
    {
        public ConvertisseurDevisesViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
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
                MontantEuros = MontantDevise / DeviseSelected.Taux;
            }
        }
    }
}
