using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;

namespace BreakableBonesPatch6
{
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [DebuggerNonUserCode]
    [CompilerGenerated]
    internal class Resource1
    {
        internal Resource1()
        {
        }

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000019 RID: 25 RVA: 0x00002710 File Offset: 0x00000910
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                bool flag = Resource1.resourceMan == null;
                if (flag)
                {
                    ResourceManager resourceManager = new ResourceManager("BreakableBones.Resource1", typeof(Resource1).Assembly);
                    Resource1.resourceMan = resourceManager;
                }
                return Resource1.resourceMan;
            }
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600001A RID: 26 RVA: 0x00002758 File Offset: 0x00000958
        // (set) Token: 0x0600001B RID: 27 RVA: 0x0000213E File Offset: 0x0000033E
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Resource1.resourceCulture;
            }
            set
            {
                Resource1.resourceCulture = value;
            }
        }

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x0600001C RID: 28 RVA: 0x00002770 File Offset: 0x00000970
        internal static UnmanagedMemoryStream snapcracklepop
        {
            get
            {
                return Resource1.ResourceManager.GetStream("snapcracklepop", Resource1.resourceCulture);
            }
        }

        // Token: 0x0400001A RID: 26
        private static ResourceManager resourceMan;

        // Token: 0x0400001B RID: 27
        private static CultureInfo resourceCulture;
    }
}
