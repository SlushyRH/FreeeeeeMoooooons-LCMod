using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace CustomMoonPriceModLC
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class CustomMoonPrice : BaseUnityPlugin
    {
        private const string GUID = "SlushyRH.LethalCompany.FreeeeeeMoooooons";
        private const string NAME = "FreeeeeeMoooooons";
        private const string VERSION = "1.0.0";

        private readonly Harmony harmony = new Harmony(GUID);

        internal ManualLogSource logSource;

        void Awake()
        {
            // create loggingsource
            logSource = BepInEx.Logging.Logger.CreateLogSource(GUID);
            logSource.LogInfo("CONGRATS! All the moons are now Freeeeee Moooooons");

            harmony.PatchAll(typeof(CustomMoonPrice));
            harmony.PatchAll(typeof(MoonPricePatch));
        }
    }
}