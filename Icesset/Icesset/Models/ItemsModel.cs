using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;


namespace Icesset.Models
{
    public class ItemsModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public ICommand TouchCommand { get; set; }
    }
}
