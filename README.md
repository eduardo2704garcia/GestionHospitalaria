# GestionHospitalaria
El sistema de gestión hospitalaria permitirá administrar pacientes, médicos, citas médicas, tratamientos y facturación. Se implementará utilizando ASP.NET Core MVC y una arquitectura por capas para facilitar la escalabilidad y mantenimiento del proyecto.

Descripción del Proyecto: Sistema de Gestión Hospitalaria
1. Resumen
El Sistema de Gestión Hospitalaria es una aplicación desarrollada en Visual Studio 2022 Community utilizando el patrón MVC (Model-View-Controller) y una arquitectura de 4 capas: Datos (DAL), Negocio (BL), Entidad (CLS) y Presentación. La finalidad de esta aplicación es optimizar y simplificar los procesos administrativos de los hospitales, permitiendo gestionar pacientes, tratamientos, especialidades, y accesos de usuarios de manera eficiente y segura.

2. Objetivos del Proyecto
Facilitar la gestión hospitalaria: Automatizar el registro y administración de pacientes, tratamientos y especialidades.
Optimizar el tiempo de atención: Minimizar tareas manuales y mejorar la accesibilidad a la información médica.
Garantizar la seguridad: Implementar un sistema de autenticación y autorización para proteger la información sensible.
Mejorar la experiencia de usuario: Proporcionar una interfaz intuitiva y rápida.
3. Tecnologías Utilizadas
Frontend: HTML5, CSS3, JavaScript (AJAX y Fetch API), Bootstrap 5.
Backend: ASP.NET Core MVC, C#.
Base de Datos: Microsoft SQL Server, procedimientos almacenados, y Entity Framework Core para el mapeo objeto-relacional.
IDE: Visual Studio 2022 Community.
4. Arquitectura del Proyecto
Capa de Presentación:
Gestiona la interfaz gráfica y las interacciones del usuario mediante controladores (Controller) y vistas (View).
Capa de Negocio (BL):
Implementa la lógica de negocio y valida las reglas antes de acceder a la capa de datos.
Capa de Entidad (CLS):
Define las clases y propiedades que representan los datos (Ejemplo: TratamientosCLS, PacienteCLS).
Capa de Datos (DAL):
Maneja el acceso a la base de datos utilizando Entity Framework y procedimientos almacenados (AccesoDAL).
5. Módulos Principales
Gestión de Pacientes: Registro, consulta y actualización de información de pacientes.
Gestión de Tratamientos: Administración de tratamientos mediante formularios modales y validación.
Gestión de Especialidades: Registro y consulta de especialidades médicas.
Sistema de Autenticación: Inicio de sesión y registro utilizando la tabla Administrador.
Reportes: Generación de informes básicos para el control administrativo.
6. Conclusión
El sistema busca ser una herramienta integral para la administración hospitalaria, garantizando seguridad, eficiencia y una interfaz amigable. La implementación modular facilita futuras expansiones y actualizaciones según los requerimientos del hospital.
