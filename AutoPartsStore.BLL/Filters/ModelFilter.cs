using AutoPartsStore.AN.Entities;

namespace AutoPartsStore.BLL.Filters
{
    public class ModelFilter
    {
        public string? Name { get; set; }
        public Brand? Brand { get; set; }
        public TypeTransport? TypeTransport { get; set; }
    }
}
