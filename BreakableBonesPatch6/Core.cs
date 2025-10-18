using BoneLib.BoneMenu;
using BoneLib.BoneMenu.UI;
using HarmonyLib;
using Il2CppSLZ.Marrow.PuppetMasta;
using MelonLoader;
using System;
using UnityEngine;
using static Il2CppSLZ.Marrow.PuppetMasta.PuppetMaster;

[assembly: MelonInfo(typeof(BreakableBonesPatch6.Core), "BreakableBonesPatch6", "1.0.0", "MajedCT", null)]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]

namespace BreakableBonesPatch6
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            this.categ = MelonPreferences.CreateCategory("BoneBreaking");
            breakTorque = this.categ.CreateEntry<float>("BoneBreakTorque", 7000f, null, null, false, false, null, null);
            breakForce = this.categ.CreateEntry<float>("BoneBreakForce", 7000f, null, null, false, false, null, null);
            toggled = this.categ.CreateEntry<bool>("Toggled", true, null, null, false, false, null, null);
            takedamage = this.categ.CreateEntry<bool>("NPCDamage", true, null, null, false, false, null, null);
            Page page = Page.Root.CreatePage("BoneBreaking", Color.white);
            page.CreateFloat("Break Torque", Color.red, Core.breakTorque.Value, Core.increment, 0f, float.MaxValue, delegate (float value)
            {
                Core.breakTorque.Value = value;
            });
            page.CreateFloat("Break Force", Color.red, Core.breakForce.Value, Core.increment, 0f, float.MaxValue, delegate (float value)
            {
                Core.breakForce.Value = value;
            });
            page.CreateBool("Toggled", Color.red, Core.toggled.Value, delegate (bool value)
            {
                Core.toggled.Value = value;
            });
            page.CreateBool("Damage On Break", Color.red, Core.takedamage.Value, delegate (bool value)
            {
                Core.takedamage.Value = value;
            });
            Page subpage = page.CreatePage("Experimental Settings [!]", Color.yellow);
            subpage.CreateFloat("force/torque button increment", Color.yellow, Core.increment, 25f, 0f, float.MaxValue, delegate (float value)
            {
                Core.increment = value;
            });
            subpage.CreateFloat("brokenjoint maxforce", Color.yellow, Core.max, 1f, 0f, float.MaxValue, delegate (float value)
            {
                Core.max = value;
            });
            subpage.CreateBool("unlock_x", Color.yellow, Core.x, delegate (bool value)
            {
                Core.x = value;
            });
            subpage.CreateBool("unlock_y", Color.yellow, Core.y, delegate (bool value)
            {
                Core.y = value;
            });
            subpage.CreateBool("unlock_z", Color.yellow, Core.z, delegate (bool value)
            {
                Core.z = value;
            });
            subpage.CreateBool("fix_destroy-respawn", Color.yellow, Core.fixspawn, delegate (bool value)
            {
                Core.fixspawn = value;
            });
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002077 File Offset: 0x00000277
        public override void OnDeinitializeMelon()
        {
            MelonPreferences.Save();
        }

        // Token: 0x04000004 RID: 4
        public MelonPreferences_Category categ;

        // Token: 0x04000005 RID: 5
        public static MelonPreferences_Entry<float> breakTorque;

        // Token: 0x04000006 RID: 6
        public static MelonPreferences_Entry<float> breakForce;

        // Token: 0x04000007 RID: 7
        public static MelonPreferences_Entry<bool> toggled;

        // Token: 0x04000008 RID: 8
        public static MelonPreferences_Entry<bool> takedamage;

        // Token: 0x04000009 RID: 9
        public static bool x = false;

        // Token: 0x0400000A RID: 10
        public static bool y = true;

        // Token: 0x0400000B RID: 11
        public static bool z = false;

        // Token: 0x0400000C RID: 12
        public static bool fixspawn = true;

        // Token: 0x0400000D RID: 13
        public static float increment = 50f;

        // Token: 0x0400000E RID: 14
        public static float max = 0f;

        // Token: 0x02000004 RID: 4
        [HarmonyPatch(typeof(PuppetMaster), "Awake")]
        public class onAwake
        {
            // Token: 0x0600000A RID: 10 RVA: 0x000026EC File Offset: 0x000008EC
            [HarmonyPostfix]
            public static void Postfix(PuppetMaster __instance)
            {
                GameObject gameObject = __instance.gameObject;
                gameObject.AddComponent<JointHandler>().pMaster = __instance;
            }
        }
    }
}
