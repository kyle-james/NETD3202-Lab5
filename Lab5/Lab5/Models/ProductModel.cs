using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Lab5.Models
{
    public class ProductModel
    {
        [Key]
        public int skuId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
