using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Entity
{
    public class RoleEntity
    {
         public Guid Id { get; set; }
         public string RoleName { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //Navigation
        public virtual ICollection<UserEntity> Users { get; set; } // One Role can be assigned to multiple users.


    }
}
