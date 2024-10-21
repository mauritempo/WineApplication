
# Wine Inventory Management System

## Descripción

El **Wine Inventory Management System** es una aplicación basada en ASP.NET Core que permite la gestión y control de un inventario de vinos. Además, ofrece funcionalidades de autenticación mediante JWT (JSON Web Token), manejo de usuarios y consulta de inventarios.

El sistema incluye las siguientes características:

- Creación, lectura y actualización de vinos.
- Autenticación de usuarios mediante JWT.
- Gestión de catas, permitiendo asignar listas de invitados y asociar varios vinos a una cata.
- Búsqueda de vinos por variedad o región.
- Gestión de stock de los vinos.

## Tecnologías

Este proyecto utiliza las siguientes tecnologías:

- **ASP.NET Core 6.0**
- **Entity Framework Core**
- **SQLite** para la base de datos.
- **JWT (JSON Web Token)** para autenticación.
- **AutoMapper** para simplificar el mapeo entre entidades y DTOs.

## Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

- Visual Studio o cualquier IDE compatible con .NET
- SQLite (se utiliza Entity Framework Core para gestionar la base de datos)

## Instalación y configuración

1. **Clonar el repositorio**:

   ```bash
   git clone https://github.com/usuario/wine-inventory.git
   cd wine-inventory
   ```

4. **Aplicar las migraciones**:

   Ejecuta el siguiente comando para aplicar las migraciones y crear la base de datos:

   
database update

   Esto actualizara el archivo de base de datos SQLite en el directorio raíz del proyecto.

## Endpoints principales

1. **Autenticación de Usuarios**

- **Ruta**: `/authenticate`
- **Método**: `POST`
- **Descripción**: Autentica a un usuario y genera un token JWT.
- **Cuerpo de la solicitud (request body)**:


   {
     "username": "tuUsername",
     "password": "tuPassword"
   }
2. **Gestión de Usuarios**
Crear un usuario
•	Ruta: /user
•	Método: POST
•	Descripción: Crea un nuevo usuario en el sistema.
•	Cuerpo de la solicitud (request body):
json
Copiar código
{
  "username": "nombreUsuario",
  "password": "passwordUsuario"
}
3.**Obtener todos los usuarios**
•	Ruta: /user
•	Método: GET
•	Descripción: Obtiene la lista de todos los usuarios registrados en el sistema.


4. **Gestión de Vinos**

#### Crear un vino

- **Ruta**: `/wine`
- **Método**: `POST`
- **Descripción**: Crea un nuevo vino en el inventario.
- **Cuerpo de la solicitud (request body)**:

   ```json
   {
     "name": "Nombre del vino",
     "variety": "Variedad del vino",
     "year": 2020,
     "region": "RegionVIno",
     "stock": 100
   }
   ```

5. **Obtener todos los vinos**

- **Ruta**: `/wine`
- **Método**: `GET`
- **Descripción**: Obtiene todos los vinos en el inventario.

6. **Actualizar Stock por Id**

- **Ruta**: `/wine/{id}/updatestock`
- **Método**: `PUT`
- **Descripción**: Pimero ingresamos el Id luego en el body cargamos la cantidad de vinos en INT sino dará error.

  
7. **Consulta de Vinos por Variedad**

- **Ruta**: `/wine/variety/{variety}`
- **Método**: `GET`
- **Descripción**: Busca y devuelve los vinos que coincidan con una variedad específica.



## Contribuciones

Las contribuciones son bienvenidas. Si encuentras algún error o tienes sugerencias, no dudes en crear un issue o enviar un pull request.

## Licencia

Este proyecto está bajo la [MIT License](LICENSE).

---

Este README proporciona una guía detallada para que otros desarrolladores puedan entender, ejecutar y contribuir al proyecto fácilmente.
