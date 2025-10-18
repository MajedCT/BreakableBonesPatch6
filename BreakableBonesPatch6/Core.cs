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
        // path for ts thing daouifadihj9 wohoo i made a comment im so intellegient
        private static readonly string BonelabPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
            "Steam\\steamapps\\common\\BONELAB\\UserData\\BoneBreaking\\snapcracklepop.wav"
        );




        private void checksnapcrackle()
        {
            try
            {
                string folder = Path.GetDirectoryName(BonelabPath);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                if (!File.Exists(BonelabPath))
                {
                    using (var stream = Resources.Resource1.snapcracklepop)
                    using (var fileStream = new FileStream(BonelabPath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                    MelonLogger.Msg("extracted snapcracklepop");
                }
            }
            catch (Exception e)
            {
                MelonLogger.Error($"couldn't extract snapcracklepop: {e}");
            }
        }
        public override void OnInitializeMelon()
        {
            checksnapcrackle();
            this.categ = MelonPreferences.CreateCategory("BoneBreaking");
            breakTorque = this.categ.CreateEntry<float>("BoneBreakTorque", 7000f, null, null, false, false, null, null);
            breakForce = this.categ.CreateEntry<float>("BoneBreakForce", 7000f, null, null, false, false, null, null);
            toggled = this.categ.CreateEntry<bool>("Toggled", true, null, null, false, false, null, null);
            kill = this.categ.CreateEntry<bool>("KillOnBreak", true, null, null, false, false, null, null);
            Page page = Page.Root.CreatePage("Breakable Bones", Color.white);
            page.CreateFloat("Break Torque", Color.red, breakTorque.Value, increment, 0f, float.MaxValue, delegate (float value)
            {
                breakTorque.Value = value;
            });
            page.CreateFloat("Break Force", Color.red, breakForce.Value, increment, 0f, float.MaxValue, delegate (float value)
            {
                breakForce.Value = value;
            });
            page.CreateBool("Mod Toggle", Color.red, toggled.Value, delegate (bool value)
            {
                toggled.Value = value;
            });
            page.CreateBool("Kill On Break", Color.red, kill.Value, delegate (bool value)
            {
                kill.Value = value;
            });
            Page subpage = page.CreatePage("Experimental Settings [!]", Color.yellow);
            subpage.CreateFloat("force/torque button increment", Color.yellow, increment, 25f, 0f, float.MaxValue, delegate (float value)
            {
                increment = value;
            });
            subpage.CreateFloat("brokenjoint maxforce", Color.yellow, max, 1f, 0f, float.MaxValue, delegate (float value)
            {
                max = value;
            });
            subpage.CreateBool("unlock_x", Color.yellow, x, delegate (bool value)
            {
                x = value;
            });
            subpage.CreateBool("unlock_y", Color.yellow, y, delegate (bool value)
            {
                y = value;
            });
            subpage.CreateBool("unlock_z", Color.yellow, z, delegate (bool value)
            {
                z = value;
            });
            subpage.CreateBool("fix_destroy-respawn", Color.yellow, fixspawn, delegate (bool value)
            {
                fixspawn = value;
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
        public static MelonPreferences_Entry<bool> kill;

        // Token: 0x04000009 RID: 9
        public static bool x = false;

        // Token: 0x0400000A RID: 10
        public static bool y = true;

        // Token: 0x0400000B RID: 11
        public static bool z = false;

        // Token: 0x0400000C RID: 12
        public static bool fixspawn = true;

        // Token: 0x0400000D RID: 13
        public static float increment = 100f;

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
