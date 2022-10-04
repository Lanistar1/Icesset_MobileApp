using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public MyFlyoutPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MyFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MyFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public MyFlyoutPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MyFlyoutPageFlyoutMenuItem>(new[]
                {
                    new MyFlyoutPageFlyoutMenuItem { Id = 0, Title = "DashBoard", IconSource="dashboarddd.png", TargetType=typeof(DashBoardPage) },
                    new MyFlyoutPageFlyoutMenuItem { Id = 1, Title = "Transaction", IconSource="transaction.png", TargetType=typeof(TransactionPage) },
                    new MyFlyoutPageFlyoutMenuItem { Id = 2, Title = "Items", IconSource="inventory.png", TargetType=typeof(ItemsPage) },
                    new MyFlyoutPageFlyoutMenuItem { Id = 3, Title = "Staff", IconSource="staff.png", TargetType=typeof(StaffPage) },
                    new MyFlyoutPageFlyoutMenuItem { Id = 5, Title = "Profile", IconSource="profile.png", TargetType=typeof(ProfilePage) },
                    new MyFlyoutPageFlyoutMenuItem { Id = 4, Title = "Report", IconSource="reportss.png", TargetType=typeof(ReportPage) },
                    new MyFlyoutPageFlyoutMenuItem { Id = 6, Title = "Scanner", IconSource="scanner.png", TargetType=typeof(ScannerPage) },
                    new MyFlyoutPageFlyoutMenuItem { Id = 7, Title = "Logout", IconSource="logout.png", TargetType=typeof(LoginPage) },

                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}