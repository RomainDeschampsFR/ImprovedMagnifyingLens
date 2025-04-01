using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace ImprovedMagnifyingLens
{
    class Patches
    {
        [HarmonyPatch(typeof(Panel_FireStart), nameof(Panel_FireStart.HasDirectSunlight))]
        internal static class Panel_FireStart_HasDirectSunlight
        {
            private static bool Prefix(Panel_FireStart __instance)
            {
                WeatherStage weather = GameManager.GetUniStorm().GetWeatherStage();
                if (weather == WeatherStage.Clear || weather == WeatherStage.PartlyCloudy)
                {
                    if (GameManager.GetWeatherComponent().IsIndoorScene()) return false;
                    if (GameManager.GetUniStorm().m_SunLight.transform == null) return false;
                    Transform transform = GameManager.GetUniStorm().m_SunLight.transform;
                    int layerMask = (1 << 8) | (1 << 9) | (1 << 11);
                    RaycastHit hit;
                    if (GameManager.GetPlayerObject().transform == null) return false;
                    if (Physics.Raycast(GameManager.GetPlayerObject().transform.position + GameManager.GetPlayerObject().transform.forward, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity, layerMask))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                return false;
            }
        }
    }
}
