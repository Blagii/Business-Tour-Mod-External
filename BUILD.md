# Building

Both variants are produced automatically by `.github/workflows/build.yml` on a
`windows-2022` runner (MSBuild, **Release / Any CPU**, .NET Framework 4.7.2):

| Folder | Symbol | Behaviour |
| --- | --- | --- |
| `build-output/` | *(none)* | Original code: SteamID whitelist over HTTP to `goguardian.ml` + anti-debug worker. |
| `build-output-clean/` | `CLEAN_BUILD` | Same UI and memory-editing features, but the whitelist HTTP check and the anti-debug worker are compiled out (`#if !CLEAN_BUILD`). |

Either `.exe` needs its sibling DLLs, `BusinessTourMod.exe.config`, Windows and
.NET Framework 4.7.2. Ready-to-use archives: `BusinessTourMod-Release.zip` and
`BusinessTourMod-Clean-Release.zip`. Both archives contain `run.bat` (diagnostic
launcher) and `RUN.md` (troubleshooting); runtime errors are written to
`startup-error.log` next to the executable.

## Locally (Visual Studio / MSBuild on Windows)

```
msbuild BusinessTourMod.sln /p:Configuration=Release "/p:Platform=Any CPU"
msbuild BusinessTourMod.sln /t:Rebuild /p:Configuration=Release "/p:Platform=Any CPU" /p:DefineConstants=CLEAN_BUILD
```

All NuGet dependencies are vendored under `packages/`, so `nuget restore` is
optional. The stale `BusinessTour.ico` content entry was removed from the
`.csproj` (the file never existed).

## Notes

This is an outdated (2019) memory-editing trainer for *Business Tour*; per the
README it no longer works with the current game. Antivirus products commonly
flag such tools as `HackTool`/`PUA`. Use only for study, on a machine you
control, and never against other players online.
