using Icesset.Models;
using Icesset.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Transactions;
using Xamarin.Forms;

namespace Icesset.ViewModels
{
    public class TransferWayBillViewModel : BaseViewModel
    {
        private ObservableCollection<Response> transact;
        public ObservableCollection<Response> Transact
        {
            get => transact;
            set
            {
                transact = value;
                OnPropertyChanged(nameof(Transact));
            }
        }

        public ObservableCollection<Response> selectedItems;
        public ObservableCollection<Response> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        private string transactionDate;
        public string TransactionDate
        {
            get => transactionDate;
            set
            {
                transactionDate = value;
                OnPropertyChanged(nameof(TransactionDate));
            }
        }
        
        private string transaction_status;
        public string Transaction_status
        {
            get => transaction_status;
            set
            {
                transaction_status = value;
                OnPropertyChanged(nameof(Transaction_status));
            }
        } 
        
        private string created_by_name;
        public string Created_by_name
        {
            get => created_by_name;
            set
            {
                created_by_name = value;
                OnPropertyChanged(nameof(Created_by_name));
            }
        }
        
        private string sent_to_name;
        public string Sent_to_name
        {
            get => sent_to_name;
            set
            {
                sent_to_name = value;
                OnPropertyChanged(nameof(Sent_to_name));
            }
        }
        
        private string destination;
        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }
        
        private string newTransact;
        public string NewTransact
        {
            get => newTransact;
            set
            {
                newTransact = value;
                OnPropertyChanged(nameof(NewTransact));
            }
        }
        
        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        
        private string item_name;
        public string Item_name
        {
            get => item_name;
            set
            {
                item_name = value;
                OnPropertyChanged(nameof(Item_name));
            }
        }
        
        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        
        private string store_name;
        public string Store_name
        {
            get => store_name;
            set
            {
                store_name = value;
                OnPropertyChanged(nameof(Store_name));
            }
        }
        
        private string courier_name;
        public string Courier_name
        {
            get => courier_name;
            set
            {
                courier_name = value;
                OnPropertyChanged(nameof(Courier_name));
            }
        }
        
        private long courier_contact;
        public long Courier_contact
        {
            get => courier_contact;
            set
            {
                courier_contact = value;
                OnPropertyChanged(nameof(Courier_contact));
            }
        }
        
        private string waybill_id;
        public string Waybill_id
        {
            get => waybill_id;
            set
            {
                waybill_id = value;
                OnPropertyChanged(nameof(Waybill_id));
            }
        } 
        
        private string note;
        public string Note
        {
            get => note;
            set
            {
                note = value;
                OnPropertyChanged(nameof(Note));
            }
        }


        public TransferWayBillViewModel(INavigation navigation, ObservableCollection<Response> selectedItems)
        {

            Navigation = navigation;

            SelectedItems = selectedItems;
            //LotBill = newLotDetail;
            //BatchDetails = batchInfo;
            Transact = new ObservableCollection<Response>(SelectedItems);
            foreach (var item in Transact)
            {
                Console.WriteLine(item);

                TransactionDate = item.transactionDate;
                Transaction_status = item.transaction_status;
                Created_by_name = item.created_by_name;
                Sent_to_name = item.sent_to_name;
                Destination = item.destination;
                Courier_name = item.courier_name;
                Courier_contact = item.courier_contact;
                Waybill_id = item.waybill_id;
                Note = item.note;   

                item.data = new ObservableCollection<TransactItemData>(item.data);
                var newItems = item.data;
                foreach(var items in newItems)
                {
                    Item_name = items.item_name;
                    Description = items.description;
                    Quantity = items.quantity;
                    Store_name = items.store_name;
                }
            }
            Console.WriteLine(Transact);

            //Task _task = GetCollectExecute( );

            //CollectCommand = new Command(async () => await GetCollectExecute());
        }
    }
}
