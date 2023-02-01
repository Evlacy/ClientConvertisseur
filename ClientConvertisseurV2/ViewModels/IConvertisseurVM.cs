using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public interface IConvertisseurVM
    {
        void GetDataOnLoadAsync();
        void MessageAsync(string title, string message);
    }
}
