using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace CustomMoonPriceModLC
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class CustomMoonPrice : BaseUnityPlugin
    {
        private const string GUID = "SlushyRH.LethalCompany.CustomMoonPrice";
        private const string NAME = "Custom Moon Price";
        private const string VERSION = "1.0.0";

        private static CustomMoonPrice Instance;

        private readonly Harmony harmony = new Harmony(GUID);

        internal ManualLogSource logSource;

        void Awake()
        {
            if (Instance == null)
                Instance = this;

            // create loggingsource
            logSource = BepInEx.Logging.Logger.CreateLogSource(GUID);
            logSource.LogInfo("THE CUSTOM MOON PRICE HAS AWOKEN!");


            harmony.PatchAll(typeof(CustomMoonPrice));
            harmony.PatchAll(typeof(MoonPricePatch));
        }
    }
}