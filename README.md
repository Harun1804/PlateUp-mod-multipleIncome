# Multiple Income Mod for PlateUp


Simple PlateUp mod that multiplies total earnings at end of day.


How it works:
- Records starting money at day start.
- At night, computes earnings for the day and awards a bonus equal to `(earnings_today * (multiplier - 1))`.


Default multiplier: `2` (2x total income).


Build instructions:
1. Ensure you have the `Yariazen.PlateUp.ModBuildUtilities` NuGet package installed (you already did).
2. Open the `.csproj` in Visual Studio or build with `dotnet build -c Release`.
3. Output will be placed into `content/` by the ModBuildUtilities package. Copy the produced folder into your PlateUp `Mods/` folder.
4. Launch PlateUp and verify money is multiplied at the end of the day.