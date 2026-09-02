using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Dto
{
    public class ResponseDto
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}
