using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Application.Contracts.Service
{
    public interface ISendEmailService
    {
         Task SendOtp(string emailAddress, string otp);
    }
}
