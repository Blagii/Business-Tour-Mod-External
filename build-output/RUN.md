# Kako pokrenuti / zašto „ne pali"

## Najvažnije

Ovo je **Windows** program (.NET Framework 4.7.2, WinForms) i **ne može da se pokrene u Arena sandboxu** (Linux). Moraš ga prebaciti na Windows računar / VM. Takođe je potrebna *Business Tour* igra pokrenuta na tom računaru.

## Koraci

1. Preuzmi `BusinessTourMod-Clean-Release.zip` (preporučeno) ili `BusinessTourMod-Release.zip`.
2. **Raspakuj ceo zip u jedan folder** — `.exe`, `.config` i svi `.dll` moraju biti u istom folderu. Ne pokreći iz zip-a.
3. Desni klik na `run.bat` → **Run as administrator** (ili samo dvoklik). On proverava fajlove, .NET Framework, da li je igra pokrenuta, skida „blocked" atribut i pokreće program, pa **ostavlja prozor otvoren** sa `Exit code` i sadržajem `startup-error.log`.
4. Ako `run.bat` ne prikazuje ništa, pokreni `cmd.exe`, `cd` u taj folder i ukucaj `run.bat`.

`run.bat` je najlakši način da vidiš *šta tačno* ne valja, jer običan dvoklik na `.exe` zatvori konzolu i greška se ne vidi.

## Šta piše u prozoru programa

Statusna traka na vrhu sada uvek nešto prikazuje:

| Status | Značenje |
| --- | --- |
| `Igra nije pokrenuta...` / `Nema procesa 'BusinessTour'...` | Igra nije pokrenuta ili se proces ne zove tačno `BusinessTour`. |
| `...pristup odbijen (Win32 5)` | Pokreni `run.bat` **kao administrator**. |
| `GameAssembly.dll nije pronadjen...` | Današnja verzija igre nema taj modul → ofseti iz 2019. ne važe. |
| `Igra je 64-bitna...` | Kod koristi 32-bitne adrese; sa 64-bitnom igrom ne može da radi. |
| `Povezano sa igrom (base 0x...)` | Proces je pronađen i otvoren; mod pokušava da čita memoriju. |

Sve neobrađene greške se upisuju u `startup-error.log` pored `.exe` i prikazuju u `MessageBox`-u.

## Ako se `.exe` uopšte ne pojavi

- **Windows Defender / SmartScreen** ga često obriše ili blokira kao `HackTool`/`PUA`. Proveri *Protection history*, pa dodaj folder u *Exclusions*, odnosno **More info → Run anyway**. `run.bat` automatski poziva `Unblock-File`.
- **.NET Framework 4.7.2**: Win 10 1803+ / Win 11 ga imaju. Ako nema, instaliraj „.NET Framework 4.7.2 Runtime".
- Proveri da nisi pokrenuo fajl direktno iz zip-a i da su svi DLL-ovi pored `.exe`.
- Pogledaj `Event Viewer → Windows Logs → Application` za `.NET Runtime` grešku.

## Zašto i dalje verovatno neće menjati novac

Hardkodovani ofseti (`0x012CC25C`, `0x012C6090`, `0x48`, `168`) važe samo za verziju igre iz 2019. Uz to, vrednosti se menjaju samo u tvojoj lokalnoj memoriji — online server ih ne prihvata. Projekat je u README-u označen kao zastareo i namenjen učenju / istoriji. Popravke u ovoj grani rešavaju **pokretanje i dijagnostiku**, ne kompatibilnost sa današnjom igrom.

## Originalna vs. clean varijanta

- **Original** (`build-output/`): pre pokretanja šalje HTTP zahtev ka `goguardian.ml`. Taj domen je mrtav, pa program staje sa porukom o whitelist grešci. Zato koristi clean.
- **Clean** (`build-output-clean/`): bez mrežnog poziva i bez anti-debug provere; UI i rad sa memorijom su isti.
