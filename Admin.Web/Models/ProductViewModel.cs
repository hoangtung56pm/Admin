﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Web.Models
{
    public class ProductViewModel
    {
      
        public int ID { set; get; }

       
        public string Name { set; get; }

     
        public string Alias { set; get; }

      
        public int CategoryID { set; get; }

      
        public string Image { set; get; }

       
        public string MoreImages { set; get; }

        public decimal Price { set; get; }

        public decimal? PromotionPrice { set; get; }

        public int? Warranty { set; get; }

      
        public string Description { set; get; }
        public string Content { set; get; }

        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        public string Tags { set; get; }

        public int Quantity { set; get; }

        public decimal OriginalPrice { set; get; }

       
        public virtual ProductCategoryViewModel ProductCategoryViewModel { set; get; }

        //public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}