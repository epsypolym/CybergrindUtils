using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(CGUtils.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(CGUtils.BuildInfo.Company)]
[assembly: AssemblyProduct(CGUtils.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + CGUtils.BuildInfo.Author)]
[assembly: AssemblyTrademark(CGUtils.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(CGUtils.BuildInfo.Version)]
[assembly: AssemblyFileVersion(CGUtils.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfoAttribute(typeof(CGUtils.CGUtils), CGUtils.BuildInfo.Name, CGUtils.BuildInfo.Version, CGUtils.BuildInfo.Author, CGUtils.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Hakita", "ULTRAKILL")]
