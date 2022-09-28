using Store_Common;
using Store_Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Domain.Entities.Products;

namespace Store_Domain.Entities.Products
{
    public class Productt : BaseEntity
    {
        [DisplayName("نام محصول")]
        [Required(ErrorMessage = PublicMessage.RequiredMessage)]
        public string Name { get; set; }

        public string Brand { get; set; }
        public string Description { get; set; }
        [DisplayName("قیمت")]
        [Required(ErrorMessage = PublicMessage.RequiredMessage)]
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public int ViewCount { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }
    }

}
