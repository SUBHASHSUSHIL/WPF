# Calculator — .NET Core WPF App

A fully functional desktop calculator built with **WPF on .NET 10**. It replicates the layout and behaviour of a standard numeric keypad calculator, supporting the four basic arithmetic operations plus percentage and sign-toggle helpers.

---

## What It Does

| Feature | Detail |
|---|---|
| Arithmetic | Addition, subtraction, multiplication, division |
| Percentage | Divides the current value by 100 |
| Sign toggle | Multiplies the current value by −1 |
| Decimal input | Appends a decimal point (prevents duplicates) |
| Clear | Resets the display to `0` |
| Division-by-zero guard | Shows an error `MessageBox` instead of crashing |

---

## When to Use This Project

| Scenario | Reason |
|---|---|
| Learning WPF event handling | Every button wires its `Click` event to a code-behind handler — clear one-to-one mapping |
| Understanding XAML `Grid` layouts | 4-column × 6-row grid with `ColumnSpan` for the zero and result label |
| Learning `StaticResource` styles | Three named styles (`numberButtonsStyle`, `operatorButtonsStyle`, `additionalButtonsStyle`) applied across all buttons |
| Exploring enum-driven state | `SelectedOperator` enum tracks which operator was last pressed |
| Comparing .NET 10 vs .NET Framework | Contrast the SDK-style `.csproj` here with the classic format in `Hello-world-.net-framework-app` |

---

## Architecture

The app uses a straightforward **code-behind** pattern — no MVVM, no commands. This is intentional for clarity when learning the basics.

```
Calculator-.NET-Core-App/
├── App.xaml                  # Application entry point and global button styles
├── App.xaml.cs               # Application code-behind
├── AssemblyInfo.cs           # Assembly metadata
├── MainWindow.xaml           # 4×6 Grid with all calculator buttons
└── MainWindow.xaml.cs        # All click handlers + SimpleMath helper class
```

### Key classes in `MainWindow.xaml.cs`

| Class / Enum | Responsibility |
|---|---|
| `MainWindow` | UI logic — button click handlers, display update |
| `SimpleMath` | Static helper with `Add`, `Sustraction`, `Multiply`, `Divide` |
| `SelectedOperator` | Enum that records the pending operator (`Addition`, `Sustraction`, `Multiplication`, `Division`) |

---

## Tech Stack

| Item | Value |
|---|---|
| Framework | .NET 10 |
| UI Technology | WPF (Windows Presentation Foundation) |
| Project format | SDK-style `.csproj` |
| Language | C# (nullable enabled, implicit usings) |
| Output type | Windows executable (`.exe`) |
| Dependencies | None (no NuGet packages) |

---

## Prerequisites

- Windows OS
- Visual Studio 2022 (17.x or later) with the **.NET desktop development** workload
- .NET 10 SDK

---

## How to Run

```powershell
dotnet run --project "Calculator-.NET-Core-App.csproj"
```

Or open `WPF.slnx` in Visual Studio, set this project as startup, and press **F5**.

---

## Key Concepts Demonstrated

- **XAML `Grid` with `ColumnDefinitions` / `RowDefinitions`** — declarative responsive layout
- **`StaticResource` button styles** — consistent look applied via `Style="{StaticResource ...}"`
- **Code-behind event wiring** — `Click` attribute in XAML maps to named handler methods
- **`sender` comparison pattern** — single handler (`NumberButton_Click`, `OperationButton_Click`) dispatches on `sender == buttonName`
- **`double.TryParse` for safe input parsing** — avoids exceptions on unexpected display values
- **`MessageBox` for user feedback** — simple modal dialog for error reporting

---

## Limitations & Possible Improvements

- Chained operations are not supported (e.g. `1 + 2 + 3` requires pressing `=` between each pair).
- No keyboard input — only mouse clicks.
- No history or memory functions.
- MVVM refactoring would improve testability and separate concerns.
