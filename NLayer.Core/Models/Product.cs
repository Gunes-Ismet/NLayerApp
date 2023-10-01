namespace NLayer.Core.Models
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }

        //// Not
        //public int Category_Id { get; set; } //Category Id tutacak tabloya custom isim verecek olursak bunun forignkey olduğunu bildirmemiz gerekiyor.
        //[ForeignKey("Category_Id")]
        //public Category Category { get; set; }
    }
}
