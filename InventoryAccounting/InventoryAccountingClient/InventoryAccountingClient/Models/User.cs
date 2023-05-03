using System;
using System.Collections.Generic;

//#nullable disable

namespace InventoryAccountingWebApi.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
    }
}
