using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using EFT;
using EFT.Interactive;
using System.Net.Sockets;
using UnityEngine;

namespace acidphantasm_letmeout.Patches
{
    internal class InteractWithTransit_Patch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(GClass1676), nameof(GClass1676.InteractWithTransit));
        }

        [PatchPrefix]
        static bool Prefix(GClass1676 __instance, Player player, TransitInteractionPacketStruct packet)
        {
            if (__instance == null) return true;

            Logger.LogInfo("DisableExitsHit");

            __instance.method_15(player);
            __instance.transitPlayers.Add(player.ProfileId, player.Id);
            __instance.profileKeys[player.ProfileId] = packet.keyId;
            __instance.dictionary_0[packet.pointId].GroupEnter(player);
            //ExfiltrationControllerClass.Instance.BannedPlayers.Add(player.Id);
            ExfiltrationControllerClass.Instance.CancelExtractionForPlayer(player);
            //ExfiltrationControllerClass.Instance.DisableExitsInteraction();

            return false;
        }
    }
}
