using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Entity
{
    public class UserOtpEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Otp { get; set; }
        public string? Email { get; set; }
        public DateTime ExpiryTime { get; set; }
        public int TryCount { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //Navigation
        public virtual UserEntity User { get; set; }

    }
}
