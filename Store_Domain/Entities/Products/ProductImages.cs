using Store_Common;
using Store_Domain.Entities.Commons;

namespace Store_Domain.Entities.Products
{
    public class ProductImages : BaseEntity
    {
        public virtual Productt Product { get; set; }
        public long ProductId { get; set; }
        public string Src { get; set; }
    }

}
