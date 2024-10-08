# Blazor Web App Authentication

Este proyecto implementa un sistema de autenticación utilizando **Blazor Server** con roles de usuario, que permite acceso restringido a ciertas páginas según el rol del usuario (Administrator o User).

## Características

- **Inicio de sesión**: Los usuarios pueden autenticarse con credenciales almacenadas en la base de datos.
- **Autorización basada en roles**: Diferentes roles de usuario pueden acceder a diferentes partes de la aplicación (por ejemplo, solo los administradores pueden acceder a la página "Weather").
- **Páginas protegidas**: Las rutas están protegidas con `AuthorizeRouteView` para restringir el acceso.
- **Gestión de cookies de autenticación**: Al iniciar sesión, se emite una cookie que mantiene la sesión activa hasta que se cierra.

## Requisitos

- **.NET 6.0** o superior
- **SQL Server**
- **Visual Studio 2022** o superior

## Instalación

### 1. Clonar el repositorio

bash
git clone https://github.com/tu-usuario/BlazorWebAppAuthentication.git

# Restaurar paquetes

dotnet restore

# Configuración de la base de datos

Crea una base de datos en SQL Server llamada LoginBlazor.
Configura la cadena de conexión en el archivo appsettings.json. Ejemplo:

{
  "ConnectionStrings": {
    "MyAppDbContext": "Server=IGNACIOFONTE\\SQLEXPRESS;Database=LoginBlazor;user id=Administrador;password=TuContraseña;MultipleActiveResultSets=true;trustservercertificate=true"
  }
}

Aplica las migraciones para crear las tablas en la base de datos:

Add-Migration InitialCreate
Update-Database

#  Ejecutar la aplicación
dotnet run

## Uso del Proyecto

### Inicio de Sesión

Ve a la ruta `/login` para iniciar sesión. Las credenciales almacenadas en la base de datos son las siguientes:

- **Administrador**: 
  - Usuario: `admin`
  - Contraseña: `admin123`
- **Usuario estándar**: 
  - Usuario: `user`
  - Contraseña: `user123`

### Roles de Acceso

- **Administrator**: Tiene acceso a todas las páginas, incluida la página "Weather".
- **User**: Tiene acceso a las páginas públicas, como la página "Counter".

## Explicación del Proyecto

### 1. **NavMenu.razor**

Este archivo define el menú de navegación y utiliza el componente `AuthorizeView` para mostrar las opciones del menú según el rol del usuario.

```razor
<AuthorizeView Roles="Administrator,User">
    <Authorized>
        <NavLink class="nav-link" href="counter">Counter</NavLink>
    </Authorized>
</AuthorizeView>

<AuthorizeView Roles="Administrator">
    <Authorized>
        <NavLink class="nav-link" href="weather">Weather</NavLink>
    </Authorized>
</AuthorizeView>

###  2. **Login.razor**

Este componente gestiona el inicio de sesión del usuario. Utiliza el contexto de la base de datos para validar las credenciales ingresadas.

<EditForm Model="@Model" OnValidSubmit="Authenticate">
    <InputText @bind-Value="Model.Username" placeholder="Username" />
    <InputText @bind-Value="Model.Password" type="password" placeholder="Password" />
</EditForm>

###  3. **Logout.razor**

Este componente permite al usuario cerrar sesión y elimina la cookie de autenticación.

###  4. **Counter.razor**

Ejemplo de página protegida que puede ser accesible tanto por administradores como por usuarios con rol 'User'. Aquí se puede ver el uso de Authorize para proteger el componente.

@attribute [Authorize(Roles = "Administrator,User")]

### 5. **Routes.razor**

Este archivo define las rutas de la aplicación y se asegura de que solo los usuarios autorizados puedan acceder a las páginas protegidas.

<AuthorizeRouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" />

## Recursos

https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-6.0

https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-8.0

## Comandos utilizados

Add-Migration: Genera una nueva migración basada en los cambios del modelo.
Update-Database: Aplica las migraciones pendientes a la base de datos.
dotnet restore: Restaura los paquetes NuGet necesarios.
dotnet run: Compila y ejecuta la aplicación.

## How to Install

Clonar el repositorio.
Restaurar los paquetes.
Configurar la cadena de conexión en appsettings.json.
Aplicar migraciones para crear las tablas necesarias en la base de datos.
Ejecutar la aplicación con dotnet run.

## Video del Proyecto
Para una demostración detallada del proyecto, puedes seguir este video de Youtube:

https://youtu.be/72PgEWywQZE


