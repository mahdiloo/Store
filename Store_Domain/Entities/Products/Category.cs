using Store_Common;
using Store_Domain.Entities.Commons;
using Store_Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        [DisplayName("نام دسته")]
        [Required(ErrorMessage = PublicMessage.RequiredMessage)]
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }
        //برای نمایش زیر دسته های هر گروه
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Productt> Product { get; set; }
    }
}
