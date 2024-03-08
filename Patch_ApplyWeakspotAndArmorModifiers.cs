using HarmonyLib;
using UnityEngine;

namespace Hikaria.IgnoreLimbMaxHealthClamp;

[HarmonyPatch]
internal class Patch_ApplyWeakspotAndArmorModifiers
{
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb_Custom), nameof(Dam_EnemyDamageLimb_Custom.ApplyWeakspotAndArmorModifiers))]
    [HarmonyPrefix]
    private static bool Dam_EnemyDamageLimb_Custom__ApplyWeakspotAndArmorModifiers__Prefix(Dam_EnemyDamageLimb_Custom __instance, ref float __result, float dam, float precisionMulti = 1f)
    {
        __result = dam * Mathf.Max(__instance.m_weakspotDamageMulti * precisionMulti, 1f) * __instance.m_armorDamageMulti;
        return false;
    }

    /*
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb), nameof(Dam_EnemyDamageLimb.ApplyWeakspotAndArmorModifiers))]
    [HarmonyPrefix]
    private static bool Dam_EnemyDamageLimb__ApplyWeakspotAndArmorModifiers__Prefix(Dam_EnemyDamageLimb __instance, ref float __result, float dam, float precisionMulti = 1f)
    {
        if (__instance.m_type == eLimbDamageType.Weakspot)
        {
            __result = dam * Mathf.Max(__instance.m_weakspotDamageMulti * precisionMulti, 1f) * __instance.m_armorDamageMulti;
        }
        else
        {
            __result = dam * __instance.m_weakspotDamageMulti * __instance.m_armorDamageMulti;
        }
        return false;
    }
    */
}
