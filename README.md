# 📧 Epam.MailApplicationDemo

## 🚀 Overview
**Epam.MailApplicationDemo** is an ASP.NET Core MVC application that allows users to compose and send emails to all registered email addresses stored in the database using **Google SMTP**.

---

## 📂 Project Structure
The project follows the **Onion Architecture**, ensuring separation of concerns:

```
Epam.MailApplicationDemo/
│— Epam.MailApplicationDemo.Presentation/         # Presentation Layer (Controllers, Views)
│— Epam.MailApplicationDemo.Application/ # Business Logic (Services, Interfaces)
│— Epam.MailApplicationDemo.Domain/      # Entities, Repositories
│— Epam.MailApplicationDemo.Infrastructure/ # Database, EF Core, SMTP Configurations
│— Epam.MailApplicationDemo.sln          # Solution File
```

---

## ⚙️ **Setup & Configuration**

### **1️⃣ Clone the Repository**
```sh
git clone <your-repo-url>
cd Epam.MailApplicationDemo
```

### **2️⃣ Configure Database Connection**
Modify **appsettings.json** in `Epam.MailApplicationDemo.Presentation`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=Your_database_name;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```

### **3️⃣ Configure Google SMTP**
In **appsettings.json**, add:

```json
"EmailSettings": {
  "SMTPHost": "smtp.gmail.com",
  "SMTPPort": 587,
  "SenderEmail": "your-email@gmail.com",
  "SenderPassword": "your-app-password"
}
```

🛠 **Note**: Enable *Less Secure Apps* or use an **App Password** in Google.

---

## 🛠️ **Build & Run the Application**
### **1️⃣ Install Dependencies**
```sh
dotnet restore
```

### **2️⃣ Apply Database Migrations**
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### **3️⃣ Run the Application**
```sh
dotnet run
```
Then open: **http://localhost:5000**

---

## 📩 **Using the Email Feature**
1️⃣ Open `http://localhost:7156/Email/Compose`  
2️⃣ Enter the **subject** and **message**  
3️⃣ Click **Send Email** – All registered users will receive the email!  

---

## 🏗 **Technology Stack**
- **ASP.NET Core MVC**  
- **Entity Framework Core (EF Core)**
- **SQL Server**
- **Google SMTP**  
- **Dependency Injection**  
- **Onion Architecture**  

---

## 🤝 **Contributing**
Feel free to submit pull requests or report issues! 🎯

---

## 🐝 **License**
MIT License

---

🚀 **Happy Coding!** 🎉

