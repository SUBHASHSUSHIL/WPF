# CRUD — WPF .NET 10

A WPF application demonstrating the fundamental **Create, Read, Update, Delete** pattern for a list of users. The data lives in an in-memory `List<User>` — no database involved — making it a focused example of WPF data binding and list management.

---

## What It Does

| Operation | Status | Detail |
|---|---|---|
| **Create** | ✅ Implemented | Reads Name / Email / Phone from text boxes and appends a new `User` to the list |
| **Read** | ✅ Implemented | `ListView` renders all users via a `DataTemplate`; populated on `SelectionChanged` |
| **Update** | 🚧 Stub | Button wired — shows a `MessageBox` placeholder |
| **Delete** | 🚧 Stub | Button wired — shows a `MessageBox` placeholder |

---

## When to Use This Project

| Scenario | Reason |
|---|---|
| Learning WPF data binding | `ListView` bound to a `List<User>` via `ItemsSource` — the simplest binding pattern |
| Understanding `DataTemplate` | Custom item rendering (Name + Email + Phone columns) defined entirely in XAML |
| Practicing CRUD UI structure | Two-column split layout: form on the left, list on the right |
| Exploring the Model layer | Clean `User` POCO in a dedicated `Models/` folder |
| Starting a CRUD feature | Fork this project and replace the in-memory list with a database or API |

---

## Architecture

The app uses a **code-behind** pattern with a thin Model layer. No ViewModel yet — the `ViewModels/` folder exists as a placeholder for a future MVVM refactor.

```
CRUD/
├── App.xaml                  # Application entry point
├── App.xaml.cs               # Application code-behind
├── AssemblyInfo.cs           # Assembly metadata
├── MainWindow.xaml           # Two-column layout: input form + contacts ListView
├── MainWindow.xaml.cs        # Create / Update / Delete button handlers + list refresh
├── Models/
│   └── User.cs               # User POCO (Username, Email, Phone)
└── ViewModels/               # Empty — reserved for MVVM refactor
```

### Data model

```csharp
public class User
{
    public string Username { get; set; }
    public string Email    { get; set; }
    public string Phone    { get; set; }
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
| Storage | In-memory `List<User>` |
| Dependencies | None (no NuGet packages) |

---

## Prerequisites

- Windows OS
- Visual Studio 2022 (17.x or later) with the **.NET desktop development** workload
- .NET 10 SDK

---

## How to Run

```powershell
dotnet run --project "CRUD.csproj"
```

Or open `WPF.slnx` in Visual Studio, set this project as startup, and press **F5**.

---

## Key Concepts Demonstrated

- **`ListView` + `ItemsSource`** — binding a list control to a `List<T>` in code-behind
- **`DataTemplate`** — custom item layout with multiple `TextBlock` columns inside a `StackPanel`
- **`SelectionChanged` event** — detecting user selection to trigger list refresh
- **Two-column `Grid` layout** — `ColumnDefinitions="400,*"` splits form and list
- **Model / UI separation** — `User.cs` in `Models/` keeps data concerns out of the window class

---

## Next Steps (completing the stubs)

1. **Update** — on `SelectionChanged`, populate the text boxes with the selected user's data; on `UpdateButton_Click`, find the matching user in the list and overwrite its properties, then refresh.
2. **Delete** — on `DeleteButton_Click`, remove `contactsListView.SelectedItem` from the list and refresh.
3. **`ObservableCollection<User>`** — replace `List<User>` so the `ListView` refreshes automatically without manually reassigning `ItemsSource`.
4. **MVVM** — move state and commands into a `UserViewModel` in the `ViewModels/` folder.
