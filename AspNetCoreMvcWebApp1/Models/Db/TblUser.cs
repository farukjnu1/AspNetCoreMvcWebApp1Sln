using System;
using System.Collections.Generic;

#nullable disable

namespace AspNetCoreMvcWebApp1.Models.Db
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPass { get; set; }
        public string UserType { get; set; }
    }
}
