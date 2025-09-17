using System;
using System.Collections.Generic;

#nullable disable

namespace AspNetCoreMvcWebApp1.Models.Db
{
    public partial class TblProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Qty { get; set; }
    }
}
