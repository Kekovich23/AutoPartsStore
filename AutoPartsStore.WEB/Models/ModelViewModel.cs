﻿namespace AutoPartsStore.WEB.Models
{
    public class ModelViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }
        public Guid TypeTransportId { get; set; }
        public string? TypeTransportName { get; set; }
    }
}
