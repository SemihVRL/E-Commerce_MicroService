﻿namespace E_Commerce.Catalog.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }
    }
}
