using acidphantasm_letmeout.Patches;
using BepInEx;

namespace acidphantasm_letmeout
{
    [BepInPlugin("com.acidphantasm.letmeout", "acidphantasm-LetMeOut", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            new InteractWithTransit_Patch().Enable();
        }
    }
}
