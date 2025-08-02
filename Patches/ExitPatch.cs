using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using EFT;
using acidphantasm_letmeout.Utils;

namespace acidphantasm_letmeout.Patches
{
    internal class DisableExitsInteraction_Patch : ModulePatch
    {
        public Player myPlayer;
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(ExfiltrationControllerClass), nameof(ExfiltrationControllerClass.DisableExitsInteraction));
        }

        [PatchPrefix]
        static bool Prefix(ExfiltrationControllerClass __instance)
        {
            if (__instance == null) return true;

            Logger.LogInfo("DisableExitsInteraction");
            __instance.BannedPlayers.Remove(MainUtils.GetMainPlayer().Id);

            return false;
        }
    }
}
