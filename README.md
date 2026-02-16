**1. Grupo B:**
* Cheryl Robles Quesada
* Adrian Morales Robles
* Marypaz Vargas Arce
* Horacio Porras Marin

<br>**2. Repositorio:**
https://github.com/horacio-porras/PracticaProgramada1GrupoB

<br>**3. Especificación básica del proyecto:**

a) Arquitectura
* 3 capas / 3 proyectos:
  * PracticaProgramada1GrupoB: ASP.NET Core MVC (presentación: controladores, vistas, wwwroot)
  * PracticaProgramada1GrupoB-BLL: Lógica de negocio (servicios, DTOs, mapeos)
  * PracticaProgramada1GrupoB-DAL: Acceso a datos (entidades y repositorios)

b) NuGet usados
* AutoMapper (16.0.0)
* Microsoft.VisualStudio.Web.CodeGeneration.Design (10.0.2)

c) SOLID + Patrones
* SOLID: separación por responsabilidades, uso de interfaces e inyección de dependencias.
* Patrones: Repository, Service Layer, DTO, Dependency Injection, Mapper (AutoMapper), Response Wrapper (CustomResponse<T>).
