using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Entity
{
    public class EmailSettings
    {
        public string ResendApiKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string OtpEmailSubject { get; set; }
        public string OtpEmailBodyTemplate { get; set; }
        public int OtpExpiryTime { get; set; }
    }
}
