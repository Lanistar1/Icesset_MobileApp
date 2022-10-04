using Icesset.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class ScannedWaybillViewModel : BaseViewModel
    {
        private List<ScannedData> scannedtransacts;
        public List<ScannedData> Scannedtransacts
        {
            get => scannedtransacts;
            set
            {
                scannedtransacts = value;
                OnPropertyChanged(nameof(Scannedtransacts));
            }
        }
        
        private List<ScannedData> scannedWaybill;
        public List<ScannedData> ScannedWaybill
        {
            get => scannedWaybill;
            set
            {
                scannedWaybill = value;
                OnPropertyChanged(nameof(ScannedWaybill));
            }
        }


        public ScannedWaybillViewModel(INavigation navigation, List<ScannedData> scannedtransacts)
        {
            Navigation = navigation;
            Scannedtransacts = scannedtransacts;

            var test = Scannedtransacts;
            Console.WriteLine(test);

            ScannedWaybill = new List<ScannedData>(Scannedtransacts);

            foreach(var item in Scannedtransacts)
            {
                Console.WriteLine(item);
                item.data = new List<ScannedItemData>(item.data);
            }
        }

    }
}
