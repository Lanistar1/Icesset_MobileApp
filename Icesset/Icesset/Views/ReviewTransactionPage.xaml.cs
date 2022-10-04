using Icesset.Helps;
using Icesset.Models;
using Icesset.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewTransactionPage : ContentPage
    {
        private string text;
        private string label;
        private string receive;
        private string name;
        private string contact;
        private string note;

        public ReviewTransactionPage(WaybillDetails waybillDetails, TransactionDetails transactionDetails)
        {
            InitializeComponent();
            BindingContext = new ReviewViewModel(Navigation, waybillDetails, transactionDetails);
            //MyTransaction.Text = Transaction;
            MyLabel.Text = waybillDetails.destination;
            MyReceive.Text = waybillDetails.sent_to_name;
            //MyExpected.Text = Expected;
            MyName.Text = waybillDetails.courier_name;
            MyContact.Text = waybillDetails.courier_contact;
            MyNote.Text = waybillDetails.note;
        }

        public ReviewTransactionPage(string label, string receive, string name, string contact, string note)
        {
            this.label = label;
            this.receive = receive;
            this.name = name;
            this.contact = contact;
            this.note = note;
        }

        public ReviewTransactionPage( string Label, string Receive, string Name, string Contact, string Note, string text) : this( Label, Receive, Name, Contact, Note)
        {
            this.text = text;
        }

        //private void Review(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new SuccessPage());

        //}
    }
}