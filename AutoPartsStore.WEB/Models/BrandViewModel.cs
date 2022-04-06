using AutoPartsStore.WEB.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace AutoPartsStore.WEB.Models
{
    public class BrandViewModel : BaseEntityViewModel<Guid>
    {
        public string? Name { get; set; }        
    }
}
