# Windows Application Packaging Project

A **Windows Application Packaging Project** (`.wapproj`) that wraps an existing WPF app into an **MSIX package** — the modern format for distributing and installing Windows desktop applications.

---

## What It Does

- Produces an `.msix` / `.msixbundle` installer from the associated WPF application.
- Defines application identity, display metadata, logos, and capabilities in `Package.appxmanifest`.
- Enables distribution through the **Microsoft Store**, enterprise sideloading, or direct download.
- Grants the packaged app access to modern Windows APIs (notifications, background tasks, etc.) while keeping full-trust `Win32` privileges via the `runFullTrust` restricted capability.

---

## When to Use This Project

| Scenario | Reason |
|---|---|
| Distributing a WPF app via the Microsoft Store | MSIX is the required format for Store submission |
| Cleaner installs / uninstalls | MSIX is fully reversible — the OS tracks every file and registry entry; uninstall is clean |
| Auto-update support | Installer supports automatic delta updates without user interaction |
| Testing packaging before release | Run locally to catch manifest errors, missing assets, or capability issues early |
| Enterprise sideloading | Sign the package with your org certificate and deploy via Intune or Group Policy |
| Accessing WinRT APIs from a WPF app | Packaging grants the app an identity, which some WinRT APIs require |

---

## Project Structure

```
test-windows-application-packaging-project/
├── Package.appxmanifest              # App identity, capabilities, visual assets manifest
├── test-windows-application-packaging-project.wapproj   # Packaging project file
└── Images/
    ├── Square44x44Logo.png           # Taskbar / start menu small icon
    ├── Square150x150Logo.png         # Start menu medium tile
    ├── Wide310x150Logo.png           # Start menu wide tile
    ├── StoreLogo.png                 # Microsoft Store listing icon
    └── SplashScreen.png             # Splash screen shown during launch
```

---

## Package Manifest Highlights (`Package.appxmanifest`)

```xml
<Identity
  Name="590e116d-42fe-44ec-8128-0b046355131c"
  Publisher="CN=acer"
  Version="1.0.0.0" />
```

```xml
<Capabilities>
  <Capability Name="internetClient" />
  <rescap:Capability Name="runFullTrust" />
</Capabilities>
```

| Field | Value | Notes |
|---|---|---|
| Target OS | Windows 10 (14393+) | Anniversary Update minimum |
| Device families | `Windows.Universal`, `Windows.Desktop` | Desktop only in practice |
| Internet capability | `internetClient` | Outbound network access |
| Full trust | `runFullTrust` | Required for classic Win32 / WPF apps |

---

## Tech Stack

| Item | Value |
|---|---|
| Package format | MSIX |
| Project type | Windows Application Packaging Project (`.wapproj`) |
| Manifest schema | `appx/manifest/foundation/windows10` |
| Target devices | Windows 10 Desktop (build 14393+) |
| Publisher | `CN=acer` (local/self-signed) |

---

## Prerequisites

- Windows 10 or later
- Visual Studio 2022 with the **Windows application packaging** workload component
- For Store submission: a Microsoft Partner Center account and a Store-issued certificate
- For local testing: a self-signed developer certificate (Visual Studio can create one automatically)

---

## How to Build and Run

1. Open `WPF.slnx` in Visual Studio.
2. Set `test-windows-application-packaging-project` as the startup project.
3. Press **F5** — Visual Studio packages the app, deploys it locally, and launches it.

To produce a distributable package:

- **Right-click** the packaging project → **Publish** → **Create App Packages...**
- Follow the wizard to select Store upload or sideloading.

---

## Key Concepts Demonstrated

- **`Package.appxmanifest`** — single file that defines everything Windows needs to install, launch, and display the app
- **Visual asset requirements** — multiple logo sizes required by the OS for tiles, taskbar, and Store
- **`runFullTrust` capability** — bridges classic desktop apps into the MSIX packaging model
- **MSIX identity** — packaged apps gain an identity (`Name` + `Publisher`), enabling features like per-user install and WinRT API access
- **Separation of app and packaging** — the `.wapproj` is a wrapper; the actual WPF project compiles independently

---

## Difference Between `.wapproj` and a Standard `.csproj`

| | `.csproj` (WPF app) | `.wapproj` (Packaging project) |
|---|---|---|
| Produces | `.exe` | `.msix` / `.msixbundle` |
| Contains | Source code | Manifest + assets + reference to the app project |
| Runtime | .NET runtime | Windows installer infrastructure |
| Required for Store | No | Yes |
