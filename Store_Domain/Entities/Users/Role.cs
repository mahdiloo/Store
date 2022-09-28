using Store_Domain.Entities.Commons;

namespace Store_Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserInRole> UserIRoles { get; set; }
    }

}
