using RimWorld;
using Verse;

namespace AutoTame;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class AutoTameSettings : ModSettings
{
    public int TrainInterval = GenDate.TicksPerDay;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TrainInterval, "TrainInterval", GenDate.TicksPerDay);
    }
}