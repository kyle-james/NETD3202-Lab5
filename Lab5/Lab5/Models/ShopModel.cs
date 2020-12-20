using System;
using System.ComponentModel.DataAnnotations;
using Lab5.Models;

namespace Lab5.Models
{
    public class ShopModel
    {
        [Key]
        public int skuId { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public ShopModel()

        {

        }
        public ShopModel(int skuId, string name, double price)
        {
            this.skuId = skuId;
            this.name = name;
            this.price = price;
        }
            
    }
}
