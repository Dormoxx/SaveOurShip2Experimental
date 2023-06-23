using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Verse;


namespace SaraSpacer
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main()
        {
            var harmony = new Harmony("dormoxx.sos2fork");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.Message(string.Format("Sara Spacer: successfully completed {0} harmony patches!", 
                harmony.GetPatchedMethods().Select(
                    new Func<MethodBase, Patches>(Harmony.GetPatchInfo)).SelectMany((Patches p) => p.Prefixes.Concat(p.Postfixes)).Count((Patch p) => p.owner.Contains(harmony.Id))
                )
             );
        }
    }
}

