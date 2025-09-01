# Markdown Note-taking App

A powerful ASP.NET Core 9 Web API for creating, managing, and processing markdown notes with built-in grammar checking and HTML rendering capabilities.

## 🚀 Features

- **Markdown Processing**: Create and manage notes written in Markdown format
- **Grammar Checking**: Integrated LanguageTool API for real-time grammar and spell checking
- **HTML Rendering**: Convert Markdown to HTML using Markdig library
- **Persistent Storage**: Entity Framework Core with SQL Server backend
- **RESTful Architecture**: Clean API design following REST principles

## 🛠️ Technologies Used

- **Framework**: ASP.NET Core 9
- **Database**: SQL Server with Entity Framework Core
- **Markdown Processing**: [Markdig](https://github.com/xoofx/markdig)
- **Grammar Checking**: [LanguageTool API](https://languagetool.org/)
- **Architecture**: RESTful Web API

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or full installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## 🔧 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/King-MRG1/Notes-Api.git
   cd Notes-Api
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update database connection string**
   
   Edit `appsettings.json` and update the connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NotesApiDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

4. **Configure LanguageTool API (Optional)**
   
   Add your LanguageTool configuration in `appsettings.json`:
   ```json
   {
     "LanguageTool": {
       "ApiUrl": "https://languagetool.org/api/v2/check",
       "Language": "en-US"
     }
   }
   ```

## 🚀 Running the Application

1. **Start the application**
   ```bash
   dotnet run
   ```

## 📚 API Endpoints

### Notes Management
- `GET /Note/all` - Get all notes
- `GET /Note/{id}` - Get a specific note
- `POST /Note` - Create a new note
- `PUT Note/{id}` - Update an existing note
- `DELETE Note/{id}` - Delete a note

### Text Processing
- `Get /Note/{id}/checker` - Check grammar of a note
- `GET /Note/{id}/render` - Get HTML rendered version of a note

### Example Request Body
```json
{
  "title": "My Note",
  "content": "# Hello World\n\nThis is my **markdown** note with *emphasis*."
}
```

## 🏗️ Project Structure

```
NotesApi/
├── bin/
├── Controllers/
│   └── NoteController.cs
├── Dto/
│   ├── CreateNoteDto.cs
│   ├── UpdateNote.cs
│   ├── ViewAllNotesDto.cs
│   └── ViewNoteDto.cs
├── Interface/
│   └── INoteRepository.cs
├── Mapping/
│   └── NoteMapping.cs
├── Migrations/
├── Models/
│   ├── Notes.cs
│   └── NotesContext.cs
├── obj/
├── Properties/
├── Repository/
│   └── NoteRepository.cs
├── appsettings.Development.json
├── appsettings.json
├── NotesApi.csproj
├── NotesApi.http
├── NotesApi.sln
└── Program.cs
```

## 🔧 Configuration

### Database Configuration
The application uses Entity Framework Core with SQL Server. Configure your connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your SQL Server connection string here"
  }
}
```

### LanguageTool Configuration
```json
{
  "LanguageTool": {
    "ApiUrl": "https://languagetool.org/api/v2/check",
    "Language": "en-US",
    "ApiKey": "your-api-key-if-required"
  }
}
```

## 🧪 Testing

Run the test suite using:

```bash
dotnet test
```

## 📦 NuGet Packages

Key dependencies include:
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Markdig`
- `Swashbuckle.AspNetCore`
- `Microsoft.AspNetCore.OpenApi`

## 🚀 Deployment

### Local/Production Deployment

1. **Publish the application**
   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Run the published application**
   ```bash
   cd publish
   dotnet NotesApi.dll
   ```

### IIS Deployment (Windows)

1. Install the .NET Core Hosting Bundle on the target server
2. Publish the application to a folder
3. Create a new IIS site pointing to the published folder
4. Ensure the Application Pool is set to "No Managed Code"

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request
