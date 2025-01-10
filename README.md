# Sistema de Gestión de Reclamos Municipales

Este sistema permite a los ciudadanos realizar y dar seguimiento a reclamos municipales, y a los administradores gestionarlos de manera eficiente.

## Características

- Sistema de autenticación y autorización
- Gestión de reclamos (crear, ver, actualizar estado)
- Sistema de notificaciones en tiempo real
- Panel de administración para gestionar usuarios y reclamos
- Interfaz responsiva y modo oscuro
- Carga de archivos (imágenes/videos) para documentar reclamos

## Tecnologías Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5
- jQuery
- Bootstrap Icons

## Requisitos Previos

- .NET 6.0 SDK o superior
- SQL Server
- Visual Studio 2022 o VS Code

## Configuración del Proyecto

1. Clonar el repositorio:
```bash
git clone [URL_DEL_REPOSITORIO]
```

2. Restaurar los paquetes NuGet:
```bash
dotnet restore
```

3. Actualizar la cadena de conexión en `appsettings.json`

4. Aplicar las migraciones:
```bash
dotnet ef database update
```

5. Ejecutar el proyecto:
```bash
dotnet run
```

## Estructura del Proyecto

- `Controllers/`: Controladores MVC
- `Models/`: Modelos de datos
- `Views/`: Vistas Razor
- `ViewModels/`: Modelos de vista
- `Data/`: Contexto de base de datos y migraciones
- `wwwroot/`: Archivos estáticos (CSS, JS, imágenes)

## Roles de Usuario

- **Usuario**: Puede crear y ver sus propios reclamos
- **Administrador**: Puede gestionar todos los reclamos y usuarios

## Contribuir

1. Hacer fork del repositorio
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit de tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.
