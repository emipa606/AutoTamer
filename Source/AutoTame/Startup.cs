using System.Linq;
using HarmonyLib;
using Verse;

namespace AutoTame;

[StaticConstructorOnStartup]
public static class Startup
{
    static Startup()
    {
        new Harmony("AutoTame.Mod").PatchAll();
    }

    public static bool AnimalShouldNotUntame(Pawn animal)
    {
        var result = CompAutoTameTrain.comps.Any(x => x.PreventsUntaming(animal));
        return result;
    }
}