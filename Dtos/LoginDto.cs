/// <summary>
/// Dtos: Data Transfer Objects, transportan los datos entre el cliente y el 
/// servidor, sin exponer las entidades del modelo de base de datos, permite 
/// modificar los datos que se usan, y permite mantener la arquitectura  
///  desacoplada y mas limpia. 
/// <summary>

namespace Perfumeria.Dtos
{
    public class LoginDto 
    {
        public required string Email {get; set;}
        public required string Password {get; set;}
    }
}