# 🧴 Perfumería P&G – E-commerce de Perfumes

Este es un proyecto de e-commerce enfocado en la venta de perfumes. Cuenta con un back-end

---

## Tecnologias utilizadas 

### Backend -ASP.NET Core
- **C# / .NET**
- **Entity Framework Core** - ORM para trabajar con la base de datos por medio de c#
- **MySQL** - Base de datos no relacional.
- **JWT (JSON Web token)**  - Para autentificacion de usuarios. 
- **Arquitectura por capas**  - Separacion en controllers DTOs, Services, y Data. 

---

## Requisitos para ejecutar proyecto 

- [.NET SDK ] (https://dotnet.microsoft.com/en-us/download)
- [MySQL] (https://www.mysql.com/downloads/)
- [node.js + npm] (https://nodejs.org/)

---

## Pasos para ejecutar el proyecto

### 1. Clona el repositorio 
### 2. configura la cadena de conexion y claves de jwt - user-secrets. Usa los siguientes      comandos para guardar tus configuraciones de forma segura

- dotnet user-secrets init
- dotnet user-secrets set "ConnectionStrings:DefaultConnection" "server=localhost;port=3306;database=PerfumeriaDB;user=root;password=SU_CONTRASEÑA;"  
- dotnet user-secrets set "Jwt:Key" "REMPLAZAR_32_CARACTERES_KEY_KWT"
- dotnet user-secrets set "Jwt:Issuer" "PerfumeriaPyG_API"
- dotnet user-secrets set "Jwt:Audience" "PerfumeriaPyG_Frontend"


 **Nota:** Reemplaza TU_CONTRASEÑA con la contraseña de tu base de datos Y REMPLAZAR_32_CARACTERES_KEY_KWT y con una clave segura para firmar los tokens JWT.
con dotnet user-secrets list puede mirar tu configuracion

### 3. Cuando tiene configurado claves pudes aplicar las migraciones y crear la base de datos atravez de comando [dotnet ef database update]

### 4. Ejecuta el servidor dotnet run y ya puedes ver la ruta en la que se esta ejecutando https://localhost: ...

### 5. Ejecuta el Front-end
[Repositorio del Front-end](https://github.com/Karojulicha/Front-PerfumeriaPyG)

---

## 📞 Contacto

Desarrollado por: Karol Chaparro y Samuel Bornacelly
