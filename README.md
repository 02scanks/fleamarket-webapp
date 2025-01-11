# Flea Market Web App 🛍️

Welcome to **Flea Market**, a *pretend* online vintage clothing marketplace designed to showcase my development skills in building modern web applications. This project leverages ASP.NET MVC, ASP.NET Identity for authentication, Firebase for image storage and retrieval, and SQLite for database management.

---

## 🌟 Features

- **User Authentication**  
  Secure login and registration using **ASP.NET Identity**.  

- **Image Management**  
  Store and retrieve images seamlessly with **Firebase Storage**.  

- **Vintage Clothing Listings**  
  Browse, upload, and manage vintage clothing items in a user-friendly interface.  

- **Responsive Design**  
  A clean and responsive UI to ensure an excellent user experience across devices.  

- **Lightweight Database**  
  Uses **SQLite** as the database, ideal for this showcase project.  

---

## 🛠️ Technologies Used

- **Frontend**: Razor Views, HTML5, CSS3, Bootstrap  
- **Backend**: ASP.NET MVC, C#  
- **Authentication**: ASP.NET Identity  
- **Database**: SQLite (not intended for production use)  
- **Image Storage**: Firebase Storage  
- **Hosting**: Run locally using IIS or Visual Studio Development Server  

---

## 🚀 Getting Started

### Prerequisites  
- [Visual Studio](https://visualstudio.microsoft.com/) (2022 or later)  
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)  
- A Firebase account with a configured project  
- Git  

### Clone the Repository  
```bash
git clone https://github.com/02scanks/fleamarket-webapp.git
cd fleamarket-webapp
```

### 🔧 Configure Firebase  

1. **Create a Firebase Project**:  
   - Go to the [Firebase Console](https://console.firebase.google.com/) and create a new project.  

2. **Enable Firebase Storage**:  
   - In your Firebase project, navigate to **Build > Storage**, and enable Firebase Storage.  
   - Set your storage rules to allow read and write access for development purposes.  
     **Example Rules**:  
     ```json
     service firebase.storage {
     match /b/{bucket}/o {
     match /{allPaths=**} {
      allow read, write: if true;
          }
        }
      } 
     ```  
    - **Important**: The Firebase Storage rules used above are for testing purposes only, as they allow unrestricted read, write, and edit access to anyone. Avoid using these rules in production to ensure data security and privacy.:  


3. **Add Firebase Configuration**:  
   - Obtain your Firebase configuration details from **Project Settings > General > Your Apps**.  
   - Save the Firebase configuration JSON to the project directory (`wwwroot` or another suitable location).  
   - Update your application code to load and use the Firebase configuration.  

---

### 🗄️ Set Up the Database  

This project uses **SQLite**, which is lightweight and requires minimal configuration:  

1. **Database Creation**:  
   - The SQLite database file will be automatically generated when the application runs for the first time.  

2. **Entity Framework Migrations**:  
   - If required, you can apply migrations manually by running the following commands in the **Package Manager Console**:  
     ```bash
     Add-Migration InitialCreate
     Update-Database
     ```  

---

### ▶️ Run the Application  

1. **Open the Project**:  
   - Launch the `FleaMarket-WebApp` project in **Visual Studio**.  

2. **Restore Dependencies**:  
   - Build the project (`Ctrl + Shift + B`) to automatically restore all NuGet dependencies.  

3. **Start the Application**:  
   - Run the application using IIS Express or the Visual Studio Development Server (`Ctrl + F5`).  

4. **Explore Locally**:  
   - The app will launch in your default browser at `https://localhost:xxxx/`.  

---

### 🎯 Purpose  

The **Flea Market Web App** was developed as a showcase of my ability to:  

- Build a modern, scalable web application using **ASP.NET MVC**.  
- Implement robust and secure user authentication with **ASP.NET Identity**.  
- Integrate **Firebase Storage** for seamless image management.  
- Leverage **SQLite** for lightweight database operations in a development environment.  
- Apply best practices in software development, architecture, and UI/UX design.  

This project is not intended for production but serves as a demonstration of my skills and knowledge in web application development.  

---
