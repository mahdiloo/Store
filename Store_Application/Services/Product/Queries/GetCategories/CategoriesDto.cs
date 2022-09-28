using Store_Application.Services.Product.Queries.GetCategories;

namespace Store_Application.Services.Product.Queries.GetCategories
{
    public class CategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }

    }
}



