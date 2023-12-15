using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomMoonPriceModLC
{
    [HarmonyPatch(typeof(Terminal))]
    internal class MoonPricePatch
    {
        private static int totalCostOfItems = -5;

        [HarmonyPatch("LoadNewNode")]
        [HarmonyPrefix]
        static void LoadNewNodePatchBefore(ref TerminalNode node)
        {
            Terminal terminal = GameObject.FindObjectOfType<Terminal>();

            if (terminal == null && node == null)
                return;

            if (node.buyRerouteToMoon != -2)
                return;

            Traverse totalCostOfItemsRef = Traverse.Create(terminal).Field("totalCostOfItems");
            totalCostOfItems = (int)totalCostOfItemsRef.GetValue();
            totalCostOfItemsRef.SetValue(0);
        }

        [HarmonyPatch("LoadNewNode")]
        [HarmonyPostfix]
        static void LoadNewNodePatchAfter(ref TerminalNode node)
        {
            Terminal terminal = GameObject.FindObjectOfType<Terminal>();

            if (terminal == null && node == null)
                return;

            if (totalCostOfItems == -5)
                return;

            Traverse totalCostOfItemsRef = Traverse.Create(terminal).Field("totalCostOfItems");
            totalCostOfItemsRef.SetValue(0);

            totalCostOfItems = -5;
        }

        [HarmonyPatch("LoadNewNodeIfAffordable")]
        [HarmonyPrefix]
        static void LoadNewNodeIfAffordablePatch(ref TerminalNode node)
        {
            if (node == null)
                return;

            // if node is moon then set cost to 0
            if (node.buyRerouteToMoon != -1)
            {
                node.itemCost = 0;
            }

            Debug.Log($"INTERCEPTED IT~!~!!");
            Debug.Log($"Display Text: {node.displayText}");
            Debug.Log($"Name: {node.name}");
            Debug.Log($"Terminal Event: {node.terminalEvent}");
            Debug.Log($"Buy Item Index: {node.buyItemIndex}");
            Debug.Log($"Buy Reroute To Moon: {node.buyRerouteToMoon}");
            Debug.Log($"Display Planet Info: {node.displayPlanetInfo}");
            Debug.Log($"Item Cost: {node.itemCost}");
        }


    }
}
