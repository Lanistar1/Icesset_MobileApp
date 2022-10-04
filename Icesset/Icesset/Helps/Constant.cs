using Icesset.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Icesset.Helps
{
    public static class Constant
    {

        public static string BaseUrl => "https://icesset.herokuapp.com";

        public static string LoginUrl => $"{BaseUrl}/api/v1/users/login/";
        public static string accessToken { get; set; }
        public static string waybillResult { get; set; }

        public static string TransactionDetailUrl => $"{BaseUrl}/api/v1/transactions/{waybillResult}";
        public static UserData CurrentUserData { get; set; }
        //public static List<string> UserList { get; set; }
        public static ObservableCollection<ItemData> SavedSelectedItems { get; set; }
        public static ObservableCollection<Response> Transact { get; set; }
        public static Response Transaction { get; set; }
        public static ObservableCollection<ItemData> GetItems { get; set; }

        public static string SelectedItems { get; set; }
        private static object transaction_id { get; set; }

        public static string  user_id { get; set; }
        public static string GetItemsUrl => $"{BaseUrl}/api/v1/inventory?offset=1&limit=100";
        public static string CollectPopupUrl => $"{BaseUrl}/api/v1/locations";
        public static string GetOneItemsUrl => $"{BaseUrl}/api/v1/inventory/";
        //public static string TransactionUrl => $"{BaseUrl}/api/v1/transactions/user/34";
        public static string TransactionUrl => $"{BaseUrl}/api/v1/transactions/user/{user_id}";
        public static string CollectUrl => $"{BaseUrl}/api/v1/transactions/collect";
        public static string StoreUrl => $"{BaseUrl}/api/v1/locations";
        public static string ProfileUrl => $"{BaseUrl}/api/v1/users/{user_id}";
        public static string ChangePasswordUrl => "https://icesset.herokuapp.com/api/v1/user/changepassword";

        public static string CreateTransactionUrl => $"{BaseUrl}/api/v1/transaction";

        public static string PasswordUrl => "https://icesset.herokuapp.com/api/v1/requestpasswordreset";
        public static string StaffUrl => "https://icesset.herokuapp.com/api/v1/users";
        public static string CreateTransactionURL => "https://icesset.herokuapp.com/api/v1/transaction";
        public static string selectedStore { get; set; }
        public static string selectedStoreId { get; set; }
        public static bool Contains(this string target, string value, StringComparison comparison)
        {
            return target.IndexOf(value, comparison) >= 0;
        }

        
    }
}
