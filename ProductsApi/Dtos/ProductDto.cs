namespace ProductsApi.Dtos
{
    public class ProductDto
    {
        //public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string OnStock { get;  set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;    

    }
}
