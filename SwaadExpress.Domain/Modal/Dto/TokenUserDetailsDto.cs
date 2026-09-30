using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Dto
{
    public class TokenUserDetailsDto
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    //public class TokenDto
    //{
    //    public string Token { get; set; }
    // public bool isNewUser { get; set; }

    //}
}
