using System;
using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace AutoTame;

[StaticConstructorOnStartup]
internal class AutoTameMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static AutoTameMod instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public AutoTameMod(ModContentPack content) : base(content)
    {
        instance = this;
        Settings = GetSettings<AutoTameSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal AutoTameSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Auto Tame";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        Settings.TrainInterval = (int)Math.Round(listing_Standard.SliderLabeled(
            "AT.TrainInterval".Translate(Settings.TrainInterval.ToStringTicksToPeriod()),
            Settings.TrainInterval, GenTicks.TickLongInterval, GenDate.TicksPerTwelfth));

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("AT.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}