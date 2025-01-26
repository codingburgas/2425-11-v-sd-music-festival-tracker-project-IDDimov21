# Music Festival System

## 🎵 Overview

The **Music Festival System** is a **Blazor WebAssembly** application that allows **artists** to create and manage festivals while allowing **guests** to view and purchase tickets for them. The project follows a **three-layer architecture (PL, BLL, DAL)** and integrates an **Azure SQL Database** for data storage.

---

## 🔥 Features

### **Authentication & Authorization**

- **User Registration & Login** (Guests & Artists).
- **Role-based authentication** (Artists can create festivals, guests can only view).

### **Festival Management**

- **Artists** can **create, update, and delete** festivals.
- **Guests** can **view** upcoming festivals and **buy tickets**.
- **Festivals** store **name, date, time, ticket cost, and artist information**.

### **Database Integration**

- **Azure SQL Database** stores **Users, Artists, Guests, and Festivals**.
- Uses **Entity Framework Core (EF Core)** for **database operations**.

---

## 🏗️ Tech Stack

- **Frontend**: Blazor WebAssembly
- **Backend**: ASP.NET Core Web API
- **Database**: SQLite Database (since Azure subscription was called off)
- **Development Tools**: JetBrains Rider

---

## ⚙️ Setup Instructions

### **1️⃣ Clone the Repository**

```sh
git clone https://github.com/your-repo/music-festival-system.git
cd music-festival-system
```

### **2️⃣ Configure the Database**

 Update `appsettings.json` in the **API project** with your Azure SQL connection string:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your-server.database.windows.net;Database=your-db;User Id=your-user;Password=your-password;"
   }
   ```
### **3️⃣ Run the API**

```sh
cd FestivalApp_API
 dotnet run
```

API should now be running on `http://localhost:5148`

### **4️⃣ Run the Blazor Client**

```sh
cd FestivalApp_PL
 dotnet run
```

App should now be accessible at `http://localhost:5000`

---

## 📌 API Endpoints

| Method   | Endpoint             | Description                      |
| -------- | -------------------- | -------------------------------- |
| **POST** | `/api/auth/register` | Register a new user              |
| **POST** | `/api/auth/login`    | Login a user                     |
| **GET**  | `/api/festivals`     | Get all festivals                |
| **POST** | `/api/festivals`     | Create a festival (Artists only) |

---


## 🛠️ Troubleshooting

### **Festival Not Creating?**

- Ensure your **ArtistId** is correctly assigned.
- Check API errors in **Developer Console (F12 → Network)**.
- Restart API & Blazor client if needed.

### **Button Not Showing?**

- Ensure `isArtist` is correctly set in **Home.razor**.
- Debug by adding:
  ```csharp
  Console.WriteLine($"Debug: isArtist = {isArtist}");
  ```

---
