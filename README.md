# **ProyectoLambda - POS Básico para Barberías**

## **Descripción General**
ProyectoLambda es un sistema de Punto de Venta (POS) diseñado específicamente para barberías. Esta primera versión se centra en funcionalidades esenciales para la gestión operativa de estos negocios, con un enfoque en simplicidad, usabilidad y operación offline.

---

## **Estructura del Repositorio**

```plaintext
ProyectoLambda/
├── Components/               # Componentes reutilizables de la interfaz (e.g., Snackbar)
├── Data/                     # Lógica de acceso a datos y configuración de la base de datos
│   ├── Context/              # Contexto de la base de datos y configuraciones
│   ├── Migrations/           # Migraciones de Entity Framework Core
│   ├── Repositories/         # Repositorios para acceso a datos
│   ├── UnitOfWork/           # Implementación del patrón Unit of Work
├── Models/                   # Modelos de datos (e.g., User, Citas, Servicios)
├── Pages/                    # Páginas principales de la aplicación
├── Platforms/                # Configuración específica para plataformas (e.g., Windows)
├── Properties/               # Configuración de lanzamiento
├── Resources/                # Recursos como íconos y estilos
├── Services/                 # Servicios para lógica de negocio (e.g., DisplayService)
├── Shared/                   # Componentes compartidos (e.g., Layout, NavMenu)
├── Views/                    # Vistas específicas de la plataforma
├── wwwroot/                  # Archivos estáticos (CSS, imágenes, etc.)
├── App.xaml                  # Configuración principal de la aplicación
├── MauiProgram.cs            # Configuración de servicios e inyección de dependencias
├── ProyectoLambda.csproj     # Archivo de configuración del proyecto .NET
└── README.md                 # Documentación principal del proyecto
```

---

## **Requisitos del Sistema**
- **Plataforma:** Windows (aplicación de escritorio).
- **Framework:** .NET MAUI con Blazor.
- **Base de Datos:** SQLite (operación offline).
- **Lenguaje:** C#.

---

## **Funcionalidades Principales**
### **Gestión de Citas**
- Registro, edición y cancelación de citas.
- Visualización de la agenda por día y empleado.

### **Reportes Básicos**
- Ventas por período.
- Estado actual del inventario.

### **Gestión de Servicios**
- Creación, edición y eliminación de servicios ofrecidos.

### **Gestión de Inventario**
- Registro y actualización de productos e insumos.
- Identificación de insumos faltantes.
- Registro de productos vendidos.

### **Registro de Empleados**
- Información básica de empleados.
- Asociación de servicios y citas.

### **Proceso de Venta**
- Registro de ventas de servicios y productos.
- Métodos de pago (efectivo, tarjeta - solo registro).
- Generación de comprobantes simples.

### **Control de Caja**
- Registro manual de ingresos y egresos.

---

## **Configuración del Proyecto**

### **1. Clonar el Repositorio**
```bash
git clone https://github.com/usuario/ProyectoLambda.git
cd ProyectoLambda
```

### **2. Configurar Dependencias**
Asegúrate de tener instalado:
- .NET SDK 7.0 o superior.
- Visual Studio 2022 con soporte para .NET MAUI.

### **3. Configurar la Base de Datos**
El proyecto utiliza SQLite. La base de datos se inicializa automáticamente al ejecutar la aplicación gracias al archivo [`Seeding.cs`](ProyectoLambda/Data/Context/Seeding.cs).

### **4. Ejecutar el Proyecto**
Desde Visual Studio:
1. Abre el archivo [`ProyectoLambda.sln`](ProyectoLambda.sln).
2. Selecciona la configuración de depuración.
3. Ejecuta el proyecto.

---

## **Estructura de Datos**
### **Modelo [`User`](ProyectoLambda/Data/Context/ApplicationDbContext.cs)**
Archivo: [`Models/User.cs`](ProyectoLambda/Models/User.cs)
```csharp
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

### **Contexto de Base de Datos**
Archivo: [`ApplicationDbContext.cs`](ProyectoLambda/Data/Context/ApplicationDbContext.cs)
- Configuración de tablas y relaciones.
- Migraciones automáticas con Entity Framework Core.

---

## **Inyección de Dependencias**
La configuración de servicios se encuentra en [`MauiProgram.cs`](ProyectoLambda/MauiProgram.cs):
- **Base de Datos:** [`ApplicationDbContext`](ProyectoLambda/Data/Context/ApplicationDbContext.cs) con SQLite.
- **Servicios:** [`IDisplayService`](ProyectoLambda/MauiProgram.cs), [`IUnitOfWork`](ProyectoLambda/Data/UnitOfWork/Interface/IUnitOfWork.cs).

---

## **Estilos y Componentes**
- **Estilos Globales:** [`wwwroot/css/app.css`](ProyectoLambda/wwwroot/css/app.css).
- **Componentes Reutilizables:** [`Components/Snackbar.razor`](ProyectoLambda/Components/Snackbar.razor).

---

## **Próximos Pasos**
- Implementar funcionalidades avanzadas como roles de usuario, reportes personalizados y sincronización online.
- Optimizar la interfaz para mejorar la experiencia del usuario.

---

## **Contribuciones**
1. Crea un fork del repositorio.
2. Realiza tus cambios en una rama nueva.
3. Envía un pull request con una descripción detallada.

---

## **Licencia**
Este proyecto está bajo la licencia MIT. Consulta el archivo `LICENSE` para más detalles.

--- 
