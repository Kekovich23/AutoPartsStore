using AutoPartsStore.AN.Entities.Base;
using AutoPartsStore.AN.Entities.Complex;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.AN.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity<Guid> {
        public virtual ICollection<Detail> Details { get; set; }
        public virtual ICollection<Order> Orders { get; set; }        
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
