using Verse;

namespace AutoTame;

public class CompProperties_AutoTameTrain : CompProperties
{
    public float radius;

    public CompProperties_AutoTameTrain()
    {
        compClass = typeof(CompAutoTameTrain);
    }
}