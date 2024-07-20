# Lethal Logo Mod
Welcome! This mod allows you to change the logo displayed at the top of the screen in the Lethal Company menu.

## Usage

### Manual Install
Make sure BepInEx 5.4.21 is installed. (other version of BepInEx are untested)
Copy the folder `Mod Contents\plugins\Ashk3000-LethalLogoMod` into `Lethal Company\BepInEx\plugins`
Run Lethal Company

### Editing Logo
Edit logo.png inside of `Lethal Company\BepInEx\config`
Feel Free to read and edit `Lethal Company\BepInEx\config\com.ashk3000.LethalLogoMod.cfg`

#### Tips
- Use a resolution of 545 by 249
- Use a transparent PNG
- Don't use anti-aliasing
- Use the default logo's outline to make your logo look nice

## Developing

### Building
run `dotnet build`, then copy `LethalLogoMod.dll` from `bin\Debug` to `Mod Contents\plugins\Ashk3000-LethalLogoMod`.
If you get an error when build try running `dotnet clean` before trying again.

### Publishing
To publish the mod, build it, then put the contents of `Mod Contents` in a zip file named `Ashk3000-LethalLogoMod-x.y.z.zip`. (replace x.y.z with the version number)
