namespace NLayer.Core.DTO_s
{
    public class ProductFeatureDto : ProductDto
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int ProductId { get; set; }
    }
}
