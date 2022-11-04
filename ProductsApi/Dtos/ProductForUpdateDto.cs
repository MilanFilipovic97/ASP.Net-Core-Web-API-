namespace ProductsApi.Dtos
{
    public class ProductForUpdateDto
    {
        public string Code { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string OnStock { get; set; }
    }
}
