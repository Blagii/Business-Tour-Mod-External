Business Tour Mod - CLEAN build
================================
Compiled with the CLEAN_BUILD symbol. Removed at compile time:
  * the SteamID whitelist HTTP request to goguardian.ml (Program.cs)
  * the anti-debug / anti-analysis background worker (SecurityChecks.cs, GUI.cs, Designer.cs)
Everything else (WinForms UI, memory reading/writing) is unchanged.
The original, unmodified build is in ..\build-output.
Requires Windows + .NET Framework 4.7.2 + a running BusinessTour game.
