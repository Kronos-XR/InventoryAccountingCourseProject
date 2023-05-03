using System;
using System.Collections.Generic;

//#nullable disable

namespace InventoryAccountingWebApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
