using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace AutoTame;

public class CompAutoTameTrain : ThingComp
{
    public static readonly HashSet<CompAutoTameTrain> comps = new HashSet<CompAutoTameTrain>();
    public bool autoTame;
    public bool autoTrain;
    public CompPowerTrader compPower;
    public string curGraphicPath;
    public CompProperties_AutoTameTrain Props => props as CompProperties_AutoTameTrain;

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        base.PostSpawnSetup(respawningAfterLoad);
        compPower = parent.TryGetComp<CompPowerTrader>();
        comps.Add(this);
        LongEventHandler.ExecuteWhenFinished(SetGraphic);
    }

    public void SetGraphic()
    {
        if (!compPower.PowerOn)
        {
            TryChangeGraphic($"{parent.def.graphicData.texPath}_Off");
        }
        else if (autoTame)
        {
            TryChangeGraphic($"{parent.def.graphicData.texPath}_A");
        }
        else if (autoTrain)
        {
            TryChangeGraphic($"{parent.def.graphicData.texPath}_B");
        }
        else if (compPower.PowerOn)
        {
            TryChangeGraphic(parent.def.graphicData.texPath);
        }
    }

    public void TryChangeGraphic(string texPath)
    {
        if (texPath == curGraphicPath)
        {
            return;
        }

        var graphicData = new GraphicData
        {
            graphicClass = parent.def.graphicData.graphicClass,
            texPath = texPath,
            shaderType = parent.def.graphicData.shaderType,
            drawSize = parent.def.graphicData.drawSize,
            color = parent.def.graphicData.color,
            colorTwo = parent.def.graphicData.colorTwo
        };
        var newGraphic = graphicData.GraphicColoredFor(parent);
        Traverse.Create(parent).Field("graphicInt").SetValue(newGraphic);
        if (parent.Spawned && parent.Map != null &&
            Traverse.Create(parent.Map.mapDrawer).Field("sections").GetValue() != null)
        {
            parent.Map.mapDrawer.MapMeshDirty(parent.Position, MapMeshFlag.Things);
        }

        curGraphicPath = texPath;
    }

    public override void PostDeSpawn(Map map)
    {
        base.PostDeSpawn(map);
        comps.Remove(this);
    }

    public override void PostDestroy(DestroyMode mode, Map previousMap)
    {
        base.PostDestroy(mode, previousMap);
        comps.Remove(this);
    }

    public override void CompTick()
    {
        base.CompTick();
        if (autoTrain && compPower.PowerOn && Find.TickManager.TicksGame % 60000 == 0)
        {
            if (GenRadial.RadialDistinctThingsAround(parent.Position, parent.Map, Props.radius, true)
                .OfType<Pawn>().Where(x => x.RaceProps.Animal && x.Faction == parent.Faction
                                                              && x.training?.NextTrainableToTrain() != null)
                .TryRandomElement(out var animal))
            {
                var trainable = animal.training.NextTrainableToTrain();
                animal.training.Train(trainable, null);
            }
        }

        SetGraphic();
    }

    public bool PreventsUntaming(Pawn animal)
    {
        return autoTame && compPower.PowerOn && animal.Position.DistanceTo(parent.Position) <= Props.radius;
    }

    public override IEnumerable<Gizmo> CompGetGizmosExtra()
    {
        if (parent.Faction != Faction.OfPlayer)
        {
            yield break;
        }

        yield return new Command_Toggle
        {
            defaultLabel = "AT.AutoTame".Translate(),
            defaultDesc = "AT.AutoTameDesc".Translate(),
            icon = ContentFinder<Texture2D>.Get("UI/Toggleautotame"),
            toggleAction = delegate
            {
                autoTame = !autoTame;
                if (autoTame && autoTrain)
                {
                    autoTrain = false;
                }

                SetGraphic();
            },
            isActive = () => autoTame
        };

        yield return new Command_Toggle
        {
            defaultLabel = "AT.AutoTrain".Translate(),
            defaultDesc = "AT.AutoTrainDesc".Translate(),
            icon = ContentFinder<Texture2D>.Get("UI/Toggleautotrain"),
            toggleAction = delegate
            {
                autoTrain = !autoTrain;
                if (autoTame && autoTrain)
                {
                    autoTame = false;
                }

                SetGraphic();
            },
            isActive = () => autoTrain
        };
    }

    public override void PostExposeData()
    {
        base.PostExposeData();
        Scribe_Values.Look(ref autoTame, "autoTame");
        Scribe_Values.Look(ref autoTrain, "autoTrain");
    }
}