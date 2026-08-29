using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Entity
{
    public class UserEntity
    {

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }

        public int RoleId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool IsBlocked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } = null;

    }
}
