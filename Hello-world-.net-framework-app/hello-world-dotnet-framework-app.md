# Hello World — .NET Framework WPF App

A minimal Windows Presentation Foundation (WPF) application built on the classic **.NET Framework 4.7.2**. It renders a single "Hello, World!" label centered on the window — the smallest possible starting point for a WPF project.

---

## What It Does

- Displays a `Hello, World!` label (`FontSize="24"`) centered both horizontally and vertically inside the main window.
- No logic, no data binding, no event handlers — pure XAML layout.

---

## When to Use This Project

| Scenario | Reason |
|---|---|
| Learning WPF for the first time | Smallest possible surface area — zero noise, just XAML structure |
| Verifying your .NET Framework toolchain | Confirms that Visual Studio, MSBuild, and the WPF SDK are wired up correctly |
| Starting a legacy desktop app | Use as a scaffold when the target machine cannot run .NET Core / .NET 5+ |
| Comparing .NET Framework vs .NET Core WPF | Side-by-side baseline against the Core calculator projects |

---

## Why .NET Framework 4.7.2

.NET Framework 4.7.2 ships with Windows and requires no separate runtime installation. It is the right choice when:

- You are maintaining an existing enterprise application that already targets it.
- Your deployment environment restricts runtime installations.
- You depend on COM interop, `System.Web`, or other APIs that were never ported to .NET Core.

For **new** desktop projects, prefer .NET 6+ (or .NET 10 as used in the other projects here) — it ships faster, runs faster, and is the actively maintained branch.

---

## Project Structure

```
Hello-world-.net-framework-app/
├── App.xaml                  # Application entry point and global resources
├── App.xaml.cs               # Application code-behind
├── MainWindow.xaml           # Single window with the "Hello, World!" label
├── MainWindow.xaml.cs        # Empty code-behind (no logic needed)
├── App.config                # .NET Framework application configuration
└── Properties/
    ├── AssemblyInfo.cs       # Assembly metadata
    ├── Resources.resx        # Embedded resources
    └── Settings.settings     # Application settings
```

---

## Tech Stack

| Item | Value |
|---|---|
| Framework | .NET Framework 4.7.2 |
| UI Technology | WPF (Windows Presentation Foundation) |
| Project format | Classic `.csproj` (MSBuild 15) |
| Language | C# |
| Output type | Windows executable (`.exe`) |

---

## Prerequisites

- Windows OS
- Visual Studio 2019 or later with the **.NET desktop development** workload
- .NET Framework 4.7.2 targeting pack (included with Visual Studio)

---

## How to Run

1. Open `WPF.slnx` in Visual Studio.
2. Set `Hello-world-.net-framework-app` as the startup project.
3. Press **F5** (Debug) or **Ctrl+F5** (Run without debugging).

Or build from the command line:

```powershell
msbuild "Hello-world-.net-framework-app.csproj" /p:Configuration=Debug
.\bin\Debug\Hello-world-.net-framework-app.exe
```

---

## Key Concepts Demonstrated

- **XAML layout** — `Grid` containing a `StackPanel` with a `Label`
- **`HorizontalAlignment` / `VerticalAlignment`** — centering elements declaratively
- **Classic `.csproj` format** — the older XML project file used by .NET Framework (compare with the SDK-style `.csproj` in the Core projects)
