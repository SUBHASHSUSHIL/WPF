# Calculator — WPF .NET 10 (Scaffold)

A blank WPF calculator scaffold targeting **.NET 10**. The window and grid are defined in XAML but the layout and logic have not been implemented yet — this project represents the starting point before the full implementation found in **Calculator-.NET-Core-App**.

---

## What It Does

- Opens an empty `MainWindow` (800 × 450) with a blank `Grid`.
- No buttons, no logic, no styles — a clean slate.

---

## When to Use This Project

| Scenario | Reason |
|---|---|
| Starting a new WPF project from scratch | Use it as the initial scaffold before adding UI and logic |
| Practicing XAML layout | Add buttons, grids, and styles in isolation without breaking working code |
| Learning the SDK-style project format | Minimal `.csproj` that shows just what is needed for a WPF app |

> **Note:** For a fully working calculator implementation, see the [`Calculator-.NET-Core-App`](../Calculator-.NET-Core-App/calculator-dotnet-core-app.md) project in this solution.

---

## Project Structure

```
Calculator/
├── App.xaml              # Application entry point
├── App.xaml.cs           # Application code-behind
├── AssemblyInfo.cs       # Assembly metadata
├── MainWindow.xaml       # Empty main window (Grid placeholder)
└── MainWindow.xaml.cs    # Empty code-behind
```

---

## Tech Stack

| Item | Value |
|---|---|
| Framework | .NET 10 |
| UI Technology | WPF (Windows Presentation Foundation) |
| Project format | SDK-style `.csproj` |
| Language | C# |
| Output type | Windows executable (`.exe`) |

---

## Prerequisites

- Windows OS
- Visual Studio 2022 (17.x or later) with the **.NET desktop development** workload
- .NET 10 SDK

---

## How to Run

```powershell
dotnet run --project "Calculator-.NET-Core.csproj"
```

Or open `WPF.slnx` in Visual Studio, set this project as startup, and press **F5**.
