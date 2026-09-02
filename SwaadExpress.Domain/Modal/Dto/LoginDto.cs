
using System.ComponentModel.DataAnnotations;

namespace SwaadExpress.Domain.Modal.Entity;

public class LoginDto
{
    public string Email { get; set; }
    public string Otp { get; set; }

    //Take userName First Time Only.
    public string? UserName { get; set; }

}
