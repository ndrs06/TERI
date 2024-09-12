using System.ComponentModel.DataAnnotations;

namespace TERI_api.Model.Authentication;

public record RegistrationRequest(
[Required]string Email, 
[Required]string Username, 
[Required]string Password);