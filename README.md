# Markdown Note-taking App

A powerful ASP.NET Core 9 Web API for creating, managing, and processing markdown notes with built-in grammar checking and HTML rendering capabilities.

## 🚀 Features

### Core Features

- **Markdown Processing**: Create and manage notes written in Markdown format
- **Grammar Checking**: Integrated LanguageTool API for real-time grammar and spell checking
- **HTML Rendering**: Convert Markdown to HTML using Markdig library with advanced extensions
- **File Upload Support**: RESTful API with file upload capabilities for markdown files
- **Persistent Storage**: Entity Framework Core with SQL Server backend

### Advanced Features

- **Repository Pattern**: Clean separation of data access logic from business logic
- **Dependency Injection**: Built-in DI container for better testability and maintainability
- **DTO Pattern**: Data Transfer Objects for clean API contracts and data validation
- **Comprehensive Error Handling**: Try-catch blocks with specific exception handling in all methods
- **Swagger Documentation**: Auto-generated interactive API documentation
- **Multi-Environment Support**: Separate configurations for Development and Production
- **Advanced Markdown Extensions**: Support for tables, footnotes, emphasis, and more via Markdig
- **HTTP Client Integration**: Robust HTTP communication with external APIs

## 🛠️ Technologies Used

### Backend Framework

- **Framework**: ASP.NET Core 9
- **Database**: SQL Server with Entity Framework Core
- **ORM**: Entity Framework Core with Code-First approach

### Libraries & Tools

- **Markdown Processing**: [Markdig](https://github.com/xoofx/markdig) - Advanced Markdown processor
- **Grammar Checking**: [LanguageTool API](https://languagetool.org/) - Grammar and spell checking service
- **Documentation**: Swagger/OpenAPI 3.0 for interactive API documentation
- **JSON Processing**: System.Text.Json for high-performance JSON serialization

### Architecture Patterns

- **Repository Pattern**: For data access abstraction
- **Dependency Injection**: Native ASP.NET Core DI container
- **DTO Pattern**: For clean API contracts
- **RESTful Architecture**: Following REST principles and conventions
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

5. **Configure LanguageTool API (Optional)**

   Add your LanguageTool configuration in `appsettings.json`:

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

2. **Access the API**

   The API will be available at:

   - HTTPS: `https://localhost:7172`
   - HTTP: `http://localhost:5144`

3. **API Documentation**

   Visit `https://localhost:7172/swagger` to access the interactive API documentation.

## 📚 API Endpoints

### Notes Management

- `GET /Note/all` - Get all notes
- `GET /Note/{id}` - Get a specific note
- `POST /Note` - Create a new note
- `PUT /Note/{id}` - Update an existing note
- `DELETE /Note/{id}` - Delete a note

### Text Processing

- `GET /Note/markdown/{id}` - Get HTML rendered version of a note
- `GET /Note/checker/{id}` - Check grammar of a note
- `POST /Note/Upload-file-Markdown` - Upload markdown file and convert to HTML
- `POST /Note/Upload-file-Checker` - Upload file and check grammar

### Example Request Body

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

### Example Response Bodies

**Get All Notes Response:**

```json
[
  {
    "id": 1,
    "title": "My First Note"
  },
  {
    "id": 2,
    "title": "My Second Note"
  }
]
```

**Get Note by ID Response:**

```json
{
  "id": 1,
  "title": "My Note",
  "content": "# Hello World\n\nThis is my **markdown** note with *emphasis*."
}
```

**Markdown to HTML Response:**

```json
{
  "html": "<h1>Hello World</h1>\n<p>This is my <strong>markdown</strong> note with <em>emphasis</em>.</p>"
}
```

**Grammar Check Response:**

```json
{
  "matches": [
    {
      "message": "Possible spelling mistake found.",
      "offset": 15,
      "length": 4,
      "replacements": [{ "value": "correct" }]
    }
  ]
}
```

## 🏗️ Project Structure

```
NotesApi/
<<<<<<< HEAD
├── Controllers/           # API Controllers
│   └── NoteController.cs     # Main REST API endpoints
├── Dto/                  # Data Transfer Objects
│   ├── CreateNoteDto.cs     # DTO for creating notes
│   ├── UpdateNote.cs        # DTO for updating notes
│   ├── ViewAllNotesDto.cs   # DTO for listing notes
│   └── ViewNoteDto.cs       # DTO for single note view
├── Interface/            # Repository interfaces
│   └── INoteRepository.cs   # Repository contract
├── Mapping/              # Extension methods for mapping
│   └── NoteMapping.cs       # DTO to Entity mapping
├── Migrations/           # EF Core database migrations
├── Models/               # Entity models
│   ├── Note.cs             # Note entity model
│   └── NotesContext.cs     # EF Core DbContext
├── Repository/           # Data access layer
│   └── NoteRepository.cs   # Repository implementation
├── Properties/
│   └── launchSettings.json # Development server settings
├── appsettings.json      # Production configuration
├── appsettings.Development.json # Development configuration
├── NotesApi.csproj       # Project file
├── Program.cs            # Application entry point
└── README.md            # Project documentation
```

### Architecture Overview

The project follows a **layered architecture** with clear separation of concerns:

- **Controllers**: Handle HTTP requests and responses
- **DTOs**: Define data contracts for API communication
- **Repository**: Abstract data access operations
- **Models**: Define database entities and DbContext
- **Mapping**: Handle object-to-object transformations

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

## 🔍 Error Handling

The application implements comprehensive error handling:

### Exception Types Handled

- **HttpRequestException**: Network and HTTP communication errors
- **JsonException**: JSON parsing and serialization errors
- **EntityFrameworkException**: Database operation errors
- **GeneralException**: All other unexpected errors

### Error Response Format

```json
{
  "error": "Error description",
  "statusCode": 500,
  "timestamp": "2025-09-02T10:30:00Z"
}
```

### Logging

- Console logging for development environment
- Structured error messages with context information
- Exception details preserved for debugging

## 🧪 Testing

Run the test suite using:

```bash
dotnet test
```

## 📦 NuGet Packages

### Core Dependencies

- `Microsoft.EntityFrameworkCore.SqlServer` - SQL Server database provider
- `Microsoft.EntityFrameworkCore.Tools` - EF Core command-line tools
- `Microsoft.AspNetCore.OpenApi` - OpenAPI/Swagger support
- `Swashbuckle.AspNetCore` - Swagger UI generation

### External Libraries

- `Markdig` - Advanced Markdown processor with extensions support
- `Azure.Core` - Azure SDK core functionality
- `Azure.Identity` - Azure identity and authentication
- `System.Text.Json` - High-performance JSON serialization

### Development Tools

- `Microsoft.EntityFrameworkCore.Design` - EF Core design-time services
- `Microsoft.Build.Locator` - MSBuild API support
- `Microsoft.CodeAnalysis.*` - Roslyn compiler platform integration
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
