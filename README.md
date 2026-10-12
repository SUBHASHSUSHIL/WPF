# WPF Learning Projects

A collection of Windows Presentation Foundation (WPF) projects that progressively introduce desktop development concepts — from a blank "Hello, World!" window to a fully persistent multi-window contact manager packaged as MSIX.

---

## Projects

| Project | Framework | Key Concept | README |
|---|---|---|---|
| [Hello-world-.net-framework-app](#hello-world--net-framework-app) | .NET Framework 4.7.2 | Minimal WPF; classic project format | [→](Hello-world-.net-framework-app/hello-world-dotnet-framework-app.md) |
| [Calculator](#calculator) | .NET 10 | Empty scaffold / SDK project format | [→](Calculator/README.md) |
| [Calculator-.NET-Core-App](#calculator-net-core-app) | .NET 10 | Events, Grid layout, StaticResource styles | [→](Calculator-.NET-Core-App/calculator-dotnet-core-app.md) |
| [CRUD](#crud) | .NET 10 | Data binding, ListView, in-memory CRUD | [→](CRUD/crud.md) |
| [DesktopContactApp](#desktopcontactapp) | .NET 10 | SQLite, multi-window, custom UserControl | [→](DesktopContactApp/DesktopContactApp.md) |
| [Packaging Project](#windows-application-packaging-project) | MSIX / wapproj | MSIX packaging, app manifest | [→](test-windows-application-packaging-project/test-windows-aaplication-packaging-project.md) |

---

## Project Descriptions

### Hello World — .NET Framework App

The absolute minimum: a single label that prints "Hello, World!" on screen. Targets **.NET Framework 4.7.2** using the classic XML project format. Use this to verify your toolchain or as a reference when working on legacy desktop apps that cannot migrate to modern .NET.

---

### Calculator

A blank `.NET 10` WPF window with an empty `Grid` — no buttons, no logic. This is the starting scaffold created before building the full calculator. Reference it to see the smallest valid SDK-style WPF project.

---

### Calculator .NET Core App

A fully working calculator on **.NET 10**. Implements addition, subtraction, multiplication, division, percentage, sign-toggle, and decimal input. Demonstrates:

- XAML `Grid` layout with named rows and columns
- `StaticResource` button styles
- Code-behind event handlers with `sender` comparison
- A static `SimpleMath` helper class
- Division-by-zero guard with `MessageBox`

---

### CRUD

A two-panel WPF form for managing a list of users (name, email, phone). Data lives in an **in-memory `List<User>`** — no database. Create is fully implemented; Update and Delete are wired stubs ready to complete. Demonstrates:

- `ListView` with `DataTemplate` for custom item rendering
- Binding `ItemsSource` to a `List<T>`
- Separating the model (`Models/User.cs`) from the UI
- The `ViewModels/` folder as a placeholder for a future MVVM refactor

---

### DesktopContactApp

A production-style multi-window contact manager backed by a **local SQLite database** (`sqlite-net-pcl`). Features add, list, search, and edit/delete across three windows and a reusable `ContactControl`. Demonstrates:

- `sqlite-net-pcl` ORM with `[PrimaryKey, AutoIncrement]` attributes
- `ShowDialog()` for modal windows
- Real-time `TextChanged` search filtering
- Custom `UserControl` used inside a `ListView.DataTemplate`
- Alphabetical sorting via LINQ at the read layer

---

### Windows Application Packaging Project

A `.wapproj` that wraps any WPF app into an **MSIX installer**. Defines the app's identity, display names, tile images, and capabilities in `Package.appxmanifest`. Use this when you need to distribute a WPF app through the Microsoft Store, enable clean installs/uninstalls, or access WinRT APIs that require package identity.

---

## Learning Path

If you are working through these projects in order:

```
Hello World (Framework)  →  Calculator (scaffold)  →  Calculator Core (full impl)
                                                              ↓
                                              CRUD (data binding + list)
                                                              ↓
                                       DesktopContactApp (SQLite + multi-window)
                                                              ↓
                                          Packaging Project (MSIX distribution)
```

---

## Solution

All projects are part of **`WPF.slnx`** and can be opened together in Visual Studio 2022.

---

## Requirements

| Requirement | Minimum version |
|---|---|
| OS | Windows 10 (build 14393+) |
| IDE | Visual Studio 2022 17.x |
| Workload | .NET desktop development |
| SDK (.NET 10 projects) | .NET 10 SDK |
| SDK (Framework project) | .NET Framework 4.7.2 targeting pack |
