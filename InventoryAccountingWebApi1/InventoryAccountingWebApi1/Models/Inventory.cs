using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryAccountingWebApi1.Models
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
    }
}
