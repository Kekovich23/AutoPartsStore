using AutoPartsStore.AN.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AutoPartsStore.AN.Entities {
    public class Brand : BaseEntity<Guid> {
        public string Name { get; set; }
    }
}
