namespace NLayer.Core.DTO_s
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
