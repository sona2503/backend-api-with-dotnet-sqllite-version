# 🛒 Store & Item Management API 

A lightweight **RESTful API** built with **ASP.NET Core** and **SQLite** for managing stores and their inventory items. Perfect for quick prototyping, learning, or building small-scale applications without complex database setup!

---

## ✨ Features

- ✅ Full CRUD operations for **Stores (Toko)** and **Items**
- 🗄️ **SQLite** database (no installation required!)
- 🔗 One-to-Many relationship (Store → Items)
- 🚀 Clean and minimal API design
- 🧪 Easy testing with Postman, Insomnia, or any REST client
- 🔌 Ready for frontend integration (React, Vue, Angular, etc.)
- 💾 Portable database (single file)

---

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- [Postman](https://www.postman.com/downloads/) or [Insomnia](https://insomnia.rest/download) (for API testing)
- Git

**Note:** SQLite is included with .NET - no separate database installation needed! 🎉

---

## 🛠️ Installation & Setup

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/yourusername/store-item-api-sqlite.git
cd store-item-api-sqlite
```

### 2️⃣ Configure Database Connection

Open `appsettings.json` - SQLite connection is already configured:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=store.db"
  }
}
```

The database file `store.db` will be created automatically in your project root.

### 3️⃣ Install Dependencies
```bash
dotnet restore
```

### 4️⃣ Apply Database Migrations
```bash
dotnet ef database update
```

*If you don't have `dotnet-ef` tool installed:*
```bash
dotnet tool install --global dotnet-ef
```

### 5️⃣ Run the Application
```bash
dotnet run
```

The API will be available at: **`http://localhost:5019`**

---

## 🧪 API Testing Guide

Use **Postman**, **Insomnia**, or **Thunder Client** to test the endpoints below.

---

## 🛍️ Item Endpoints

### 🟢 Create a New Item
**POST** `http://localhost:5019/items`

**Request Headers:**
```
Content-Type: application/json
```

**Request Body:**
```json
{
  "name": "MacBook Pro",
  "price": 25000000
}
```

**Response:** `201 Created`
```json
{
  "id": 1,
  "name": "MacBook Pro",
  "price": 25000000
}
```

---

### 🔵 Get All Items
**GET** `http://localhost:5019/items`

**Response:** `200 OK`
```json
[
  {
    "id": 1,
    "name": "MacBook Pro",
    "price": 25000000
  },
  {
    "id": 2,
    "name": "MacBook Air",
    "price": 18000000
  }
]
```

---

### 🔵 Get Item by ID
**GET** `http://localhost:5019/items/{id}`

Example: `http://localhost:5019/items/1`

**Response:** `200 OK`
```json
{
  "id": 1,
  "name": "MacBook Pro",
  "price": 25000000
}
```

---

### 🟡 Update Item
**PUT** `http://localhost:5019/items/{id}`

Example: `http://localhost:5019/items/1`

**Request Body:**
```json
{
  "name": "MacBook Cherry",
  "price": 14000000
}
```

**Response:** `200 OK` or `204 No Content`

---

### 🔴 Delete Item
**DELETE** `http://localhost:5019/items/{id}`

Example: `http://localhost:5019/items/1`

**Response:** `204 No Content`

---

## 📦 Store (Toko) Endpoints

### 🟢 Create a New Store
**POST** `http://localhost:5019/toko`

**Request Headers:**
```
Content-Type: application/json
```

**Request Body:**
```json
{
  "nama": "Toko JAYA",
  "alamat": "Jalan Merdeka No 12"
}
```

**Response:** `201 Created`
```json
{
  "id": 1,
  "nama": "Toko JAYA",
  "alamat": "Jalan Merdeka No 12"
}
```

---

### 🔵 Get All Stores
**GET** `http://localhost:5019/toko`

**Response:** `200 OK`
```json
[
  {
    "id": 1,
    "nama": "Toko JAYA",
    "alamat": "Jalan Merdeka No 12"
  },
  {
    "id": 2,
    "nama": "Toko Makmur",
    "alamat": "Jalan Sudirman No 45"
  }
]
```

---

### 🔵 Get Store by ID
**GET** `http://localhost:5019/toko/{id}`

Example: `http://localhost:5019/toko/1`

**Response:** `200 OK`
```json
{
  "id": 1,
  "nama": "Toko JAYA",
  "alamat": "Jalan Merdeka No 12"
}
```

---

### 🟡 Update Store
**PUT** `http://localhost:5019/toko/{id}`

Example: `http://localhost:5019/toko/1`

**Request Body:**
```json
{
  "nama": "Toko JAYA ABADI",
  "alamat": "Jalan Merdeka No 12A"
}
```

**Response:** `200 OK` or `204 No Content`

---

### 🔴 Delete Store
**DELETE** `http://localhost:5019/toko/{id}`

Example: `http://localhost:5019/toko/1`

**Response:** `204 No Content`

---

## 📊 Database Schema

### Toko (Store)
| Column  | Type         | Description      |
|---------|-------------|------------------|
| Id      | int (PK)    | Primary Key      |
| Nama    | string      | Store Name       |
| Alamat  | string      | Store Address    |

### Items
| Column  | Type         | Description      |
|---------|-------------|------------------|
| Id      | int (PK)    | Primary Key      |
| Name    | string      | Item Name        |
| Price   | decimal     | Item Price       |

---

## 🧩 Project Structure
```
├── Controllers/
│   ├── TokoController.cs
│   └── ItemsController.cs
├── Models/
│   ├── Toko.cs
│   └── Item.cs
├── Data/
│   └── AppDbContext.cs
├── Migrations/
├── store.db                    # SQLite database file
├── appsettings.json
└── Program.cs
```

---

## 🚀 Quick Test with Insomnia/Postman

### Complete Testing Flow:

#### Step 1: Create Stores
```
POST http://localhost:5019/toko
Content-Type: application/json

{
  "nama": "Toko JAYA",
  "alamat": "Jalan Merdeka No 12"
}
```

#### Step 2: Get All Stores
```
GET http://localhost:5019/toko
```

#### Step 3: Create Items
```
POST http://localhost:5019/items
Content-Type: application/json

{
  "name": "MacBook Cherry",
  "price": 14000000
}
```

#### Step 4: Get All Items
```
GET http://localhost:5019/items
```

#### Step 5: Update an Item
```
PUT http://localhost:5019/items/1
Content-Type: application/json

{
  "name": "MacBook Pro M3",
  "price": 28000000
}
```

#### Step 6: Get Item by ID
```
GET http://localhost:5019/items/1
```

#### Step 7: Delete an Item
```
DELETE http://localhost:5019/items/1
```

---

## 🐛 Troubleshooting

### Port Already in Use
If port 5019 is occupied, change it in `Properties/launchSettings.json`:
```json
"applicationUrl": "http://localhost:5020"
```

### Database File Not Found
The `store.db` file will be created automatically when you run migrations. If you encounter issues:
```bash
# Delete existing migrations
rm -rf Migrations/

# Create new migration
dotnet ef migrations add InitialCreate

# Apply migration
dotnet ef database update
```

### Migration Errors
```bash
# Remove database and start fresh
rm store.db

# Recreate database
dotnet ef database update
```

### View SQLite Database
You can view and edit the SQLite database using:
- [DB Browser for SQLite](https://sqlitebrowser.org/) (Desktop App)
- [SQLite Viewer](https://marketplace.visualstudio.com/items?itemName=alexcvzz.vscode-sqlite) (VS Code Extension)

---

## 💡 SQLite Advantages

- ✅ **Zero Configuration** - No database server installation
- ✅ **Portable** - Single file database (easy backup & sharing)
- ✅ **Fast** - Great for development and small applications
- ✅ **Cross-platform** - Works on Windows, Mac, and Linux
- ✅ **Perfect for Learning** - Simple and easy to understand

---

## 🔄 Migrating to Other Databases

This project can easily be migrated to MySQL, PostgreSQL, or SQL Server by:
1. Changing the connection string in `appsettings.json`
2. Installing the appropriate NuGet package
3. Running migrations again

---

## 📝 API Response Codes

| Code | Description              |
|------|-------------------------|
| 200  | OK - Request successful |
| 201  | Created - Resource created successfully |
| 204  | No Content - Successful deletion |
| 400  | Bad Request - Invalid data |
| 404  | Not Found - Resource doesn't exist |
| 500  | Internal Server Error |

---

## 🤝 Contributing

Contributions are welcome! Feel free to:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

## 🙋 Support

If you encounter any issues or have questions:
- Open an issue on GitHub
- Contact: your.email@example.com

---

## 🌟 Show Your Support

Give a ⭐️ if this project helped you!

---

## 📚 Additional Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [SQLite Documentation](https://www.sqlite.org/docs.html)
- [RESTful API Best Practices](https://restfulapi.net/)

---

**Happy Coding! 🚀**
