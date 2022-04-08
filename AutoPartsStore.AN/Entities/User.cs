using AutoPartsStore.AN.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.AN.Entities
{
    public class User : IdentityUser, IBaseEntity<string> {
    }
}
