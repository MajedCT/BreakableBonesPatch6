using AudioImportLib;
using Il2CppPuppetMasta;
using Il2CppSLZ.Marrow.PuppetMasta;
using static Il2CppSLZ.Marrow.PuppetMasta.PuppetMaster;
using MelonLoader;
using MelonLoader.Utils;
using System;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
using Il2CppSLZ.Marrow;
using Il2CppSLZ.Marrow.Data;
using Il2CppSLZ.Marrow.AI;


namespace BreakableBonesPatch6
{
    [RegisterTypeInIl2Cpp]
    internal class JointHandler : MonoBehaviour
    {
        public JointHandler(IntPtr poptart) : base(poptart)
        {
        }

        // Token: 0x06000002 RID: 2 RVA: 0x0000205B File Offset: 0x0000025B
        private void Start()
        {
            this.muscles = pMaster.muscles;

        }



        // Token: 0x06000003 RID: 3 RVA: 0x00002148 File Offset: 0x00000348
        private void Update()
        {
            
            if (!Core.toggled.Value)
            {
                return;
            }

            foreach (Muscle muscle in this.muscles)
            {
                bool flag = muscle._maxForce == 0f;
                if (flag)
                {
                    break;
                }
                ConfigurableJoint joint = muscle.jointBreakBroadcaster.GetComponent<ConfigurableJoint>();
                float magnitude = joint.currentTorque.magnitude;
                float magnitude2 = joint.currentForce.magnitude;
                bool flag2 = magnitude > Core.breakTorque.Value || magnitude2 > Core.breakForce.Value;
                if (flag2)
                {
                    
                    joint.angularXMotion = (ConfigurableJointMotion)(Core.x ? 2 : 1);
                    joint.angularYMotion = (ConfigurableJointMotion)(Core.y ? 2 : 1);
                    joint.angularZMotion = (ConfigurableJointMotion)(Core.z ? 2 : 1);
                    string str = Path.Combine(MelonEnvironment.UserDataDirectory, "BoneBreaking");
                    AudioClip audioClip = API.LoadAudioClip(str + "/snapcracklepop.wav", true);
                    AudioSource audioSource = joint.connectedBody.gameObject.GetComponent<AudioSource>() ? joint.connectedBody.gameObject.GetComponent<AudioSource>() : joint.connectedBody.gameObject.AddComponent<AudioSource>();
                    audioSource.pitch = Random.Range(0.75f, 1.15f);
                    audioSource.PlayOneShot(audioClip, Random.Range(0.8f, 1.3f));
                    this.oldForce = muscle._maxForce;
                    muscle._maxForce = 0f;
                    //kill
                    if (Core.kill.Value)
                    {
                        pMaster.Kill();


                    }
                }
            }
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002300 File Offset: 0x00000500
        private void OnDestroy()
        {
            bool flag = !Core.fixspawn;
            if (!flag)
            {
                foreach (Muscle muscle in this.muscles)
                {
                    bool flag2 = muscle._maxForce != 0f;
                    if (flag2)
                    {
                        return;
                    }
                    ConfigurableJoint joint = muscle.jointBreakBroadcaster.GetComponent<ConfigurableJoint>();
                    joint.angularXMotion = (ConfigurableJointMotion)1;
                    joint.angularYMotion = (ConfigurableJointMotion)1;
                    joint.angularZMotion = (ConfigurableJointMotion)1;
                    muscle._maxForce = this.oldForce;
                }
                // var _musclespring = this.pMaster.muscleSpring;
                // this.pMaster.muscles = _musclespring;
                pMaster.FixMusclePositions();

                pMaster.Resurrect();
            }
        }

        // Token: 0x04000001 RID: 1
        public PuppetMaster pMaster;

        // Token: 0x04000002 RID: 2
        public Muscle[] muscles;

        // Token: 0x04000003 RID: 3
        private float oldForce;
    }
}
