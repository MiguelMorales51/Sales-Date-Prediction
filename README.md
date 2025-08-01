# Sales Date Prediction

Aplicación compuesta por:

- **Frontend**: Angular 17
- **Backend**: .NET 8 Web API

Este repositorio contiene ambos proyectos dentro de una misma estructura de carpetas.

---

## 📁 Estructura del proyecto

Sales-Date-Prediction/
│
├── frontend/ → Aplicación Angular (Angular 17)
└── backend/ → API REST en .NET 8

---

## 🚀 Requisitos previos

### 🔧 Backend (.NET 8)

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### 🌐 Frontend (Angular)

- [Node.js (v18+ recomendado)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

```bash
npm install -g @angular/cli

🛠️ Instrucciones para desarrollo
1️⃣ Clona el repositorio

git clone https://github.com/MiguelMorales51/Sales-Date-Prediction.git
cd Sales-Date-Prediction

2️⃣ Levantar el Backend (.NET 8)
cd backend
dotnet restore
dotnet run

verificar archivo launchSettings.json para el puerto en modo desarrollo. Ej:  
profiles
 "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5016",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }

3️⃣ Levantar el Frontend (Angular 17)
cd frontend
npm install
ng serve

NOTA Aclaratoria:
-Revisar conexion de la base de datos del archivo appsettings.json en el backend
-Tener una instancia de SQL Server para usar el script base de datos: BDSetup.sql
  

