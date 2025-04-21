using Microsoft.EntityFrameworkCore.Internal;

public class RegisterDto {
    public string Email {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
    public string FullName {get; set;} = string.Empty;
    public int Role {get; set;}
}

public class ResponseUserDto 
{
    public string? Email { get; set; }
    public string? Role { get; set; } 
    public string? FullName { get; set; } 
}