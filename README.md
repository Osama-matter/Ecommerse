# 🛒 Simple E-Commerce API

A simple **E-Commerce API** built with **ASP.NET Core** that demonstrates the fundamentals of **CRUD operations**, **Entity relationships**, and **JWT Authentication/Authorization**.  
This project is designed for learning purposes and can be extended to more complex scenarios.

---

## 🚀 Features

- **Products Management**
  - Add, Update, Delete, View Products
- **Categories Management**
  - Add, Update, Delete, View Categories
  - Link Products to Categories
- **Authentication & Authorization**
  - User Registration & Login
  - JWT Token-based secure access
- **RESTful API** design

---

## 🛠️ Tech Stack

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server** (or any supported DB)
- **JWT (JSON Web Token)** for Authentication

---

## 📂 Project Structure

```
EcommerceAPI/
├── Controllers/       # API Controllers (Products, Categories, Auth)
├── DTOs/              # Data Transfer Objects
├── Models/            # Entity Models
├── Data/              # DbContext & Configurations
├── Services/          # Business Logic (Authentication, etc.)
└── Program.cs         # Entry point
```

---

## ⚡ Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/Osama-matter/Ecommerse.git
cd Ecommerse
```

### 2. Update Database
```bash
dotnet ef database update
```

### 3. Run the project
```bash
dotnet run
```

The API will be available at:  
👉 `https://localhost:7092/api`

---

## 🔑 Authentication

- Register/Login to get a **JWT token**  
- Use the token in the request header:

```http
Authorization: Bearer <your_token_here>
```

---

## 📌 API Endpoints

### 🔹 Auth
- `POST /api/Auth/Register`
- `POST /api/Auth/Login`

### 🔹 Products
- `GET /api/Product`
- `GET /api/Product/{id}`
- `POST /api/Product`
- `PUT /api/Product/{id}`
- `DELETE /api/Product/{id}`

### 🔹 Categories
- `GET /api/Category`
- `GET /api/Category/{id}`
- `POST /api/Category`
- `PUT /api/Category/{id}`
- `DELETE /api/Category/{id}`

---

## 📖 Example Request

```http
POST /api/Product
Authorization: Bearer <jwt_token>
Content-Type: application/json

{
  "name": "Laptop",
  "price": 1200,
  "categoryId": 1
}
```

---

## 🤝 Contributing

Pull requests are welcome!  
For major changes, please open an issue first to discuss what you would like to change.

---

## 📜 License

This project is licensed under the MIT License.

