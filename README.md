# Run For Glory (R4G)

Proyecto personal en ASP.NET Core MVC para llevar mis entrenamientos, carreras y próximas pruebas.

## Qué uso
- .NET 8 SDK
- SQL Server (cadena `DefaultConnection` en `appsettings.json`)

## Cómo lo arranco
```bash
dotnet restore
dotnet ef database update   # si usas migrations y DB local
dotnet run
```
Suele arrancar en `https://localhost:7263` (revisa `launchSettings.json`).

## Qué hace
- Registro/login con Identity (mensajes en español).
- Entrenamientos y carreras personales.
- Próximas carreras con “Me apunto / Cancelar” que crea o borra el borrador en mis carreras.
- Estilos propios en `wwwroot/css` apoyados en Bootstrap.

## Notas rápidas
- CSS por sección: `home.css`, `proximasCarreras.css`, `entrenamientos.css`, `carreras.css`, `mejoresMarcas.css`, etc.
- Formularios de creación usan la fecha del día por defecto.
