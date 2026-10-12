# Desktop Contact App — WPF .NET 10 + SQLite

A multi-window WPF contacts manager that persists data in a local **SQLite database**. Users can add, view, search, and edit contacts through three dedicated windows and a reusable custom control.

---

## What It Does

| Feature | Detail |
|---|---|
| **Add contact** | Opens `NewContactWindow` as a modal dialog; saves to SQLite on confirm |
| **List contacts** | `ListView` displays all contacts sorted alphabetically by name |
| **Search** | Real-time filtering by name, email, or phone (case-insensitive) |
| **View / Edit / Delete** | Selecting a contact opens `ContactDetailsWindow` with full details |
| **Persistence** | Data survives app restarts via `sqlite-net-pcl` ORM |
| **Custom control** | `ContactControl` (UserControl) renders each list item consistently |

---

## When to Use This Project

| Scenario | Reason |
|---|---|
| Learning SQLite in a WPF app | Full CRUD against a local database with the lightweight `sqlite-net-pcl` package |
| Multi-window WPF patterns | Three windows (`Main`, `NewContact`, `ContactDetails`) communicate via `ShowDialog()` |
| Custom UserControl | `ContactControl` shows how to extract reusable UI into its own XAML/code-behind pair |
| Real-time search | `TextChanged` handler filters an in-memory list without hitting the database again |
| ORM with attributes | `[PrimaryKey, AutoIncrement]` on the `Contact` model maps directly to the SQLite schema |

---

## Architecture

```
DesktopContactApp/
├── App.xaml                      # Application entry point + database path constant
├── App.xaml.cs                   # Exposes App.databasePath (static path to SQLite file)
├── AssemblyInfo.cs               # Assembly metadata
├── MainWindow.xaml               # Contact list + search box + "New contact" button
├── MainWindow.xaml.cs            # ReadDatabase(), search filter, selection handler
├── NewContactWindow.xaml         # Form to create a new contact
├── NewContactWindow.xaml.cs      # Inserts new Contact row into SQLite
├── ContactDetailsWindow.xaml     # Read/edit/delete a selected contact
├── ContactDetailsWindow.xaml.cs  # Updates or deletes the contact row in SQLite
├── Classes/
│   └── Contact.cs                # SQLite-mapped model (Id, Name, Email, Phone)
└── Controls/
    ├── ContactControl.xaml       # Custom UserControl for list item rendering
    └── ContactControl.xaml.cs    # Exposes a Contact dependency property
```

### Data model

```csharp
public class Contact
{
    [PrimaryKey, AutoIncrement]
    public int    Id    { get; set; }
    public string Name  { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
```

### Database access pattern

Every database operation opens a short-lived `SQLiteConnection`, performs the work, then disposes it in a `using` block — no connection pool, no singleton. This keeps the code simple and avoids locking the SQLite file.

```csharp
using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
{
    conn.CreateTable<Contact>();          // Creates table if it doesn't exist
    contacts = conn.Table<Contact>()
                   .ToList()
                   .OrderBy(c => c.Name)
                   .ToList();
}
```

---

## Tech Stack

| Item | Value |
|---|---|
| Framework | .NET 10 |
| UI Technology | WPF (Windows Presentation Foundation) |
| Project format | SDK-style `.csproj` |
| Language | C# (nullable enabled, implicit usings) |
| Database | SQLite (local file) |
| ORM | `sqlite-net-pcl` v1.11.285 |
| Output type | Windows executable (`.exe`) |

---

## Prerequisites

- Windows OS
- Visual Studio 2022 (17.x or later) with the **.NET desktop development** workload
- .NET 10 SDK
- NuGet package `sqlite-net-pcl` (restored automatically on build)

---

## How to Run

```powershell
dotnet run --project "DesktopContactApp.csproj"
```

Or open `WPF.slnx` in Visual Studio, set this project as startup, and press **F5**.

The SQLite database file is created automatically on first launch in the path defined by `App.databasePath`.

---

## Key Concepts Demonstrated

- **`sqlite-net-pcl` ORM** — attribute-based table mapping (`[PrimaryKey, AutoIncrement]`)
- **`ShowDialog()`** — blocking modal window that pauses the parent until the user closes it
- **`ReadDatabase()` after every mutation** — simple refresh strategy: re-query and rebind after add/edit/delete
- **`TextChanged` search filter** — `Where` LINQ on the in-memory list, no extra database hit
- **Custom `UserControl`** — `ContactControl` receives a `Contact` via a dependency property and renders it
- **`DataTemplate` + custom control** — `ListView.ItemTemplate` uses `ContactControl` for each item

---

## Possible Improvements

- Wrap database access in a `ContactRepository` service class to separate data and UI concerns.
- Add input validation (required fields, email format) before saving.
- Use `ObservableCollection<Contact>` + INotifyPropertyChanged for automatic list refresh.
- Introduce MVVM (`ContactListViewModel`, commands) to make the logic unit-testable.
- Add a confirmation dialog before deleting a contact.
