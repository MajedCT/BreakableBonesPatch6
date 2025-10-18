using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using MelonLoader;

namespace BreakableBonesPatch6
{
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [DebuggerNonUserCode]
    [CompilerGenerated]
    internal class Resource1
    {
        internal Resource1() { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (resourceMan == null)
                {
                    resourceMan = new ResourceManager("BreakableBones.Resource1", typeof(Resource1).Assembly);
                }
                return resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get => resourceCulture;
            set => resourceCulture = value;
        }

        internal static UnmanagedMemoryStream snapcracklepop
        {
            get => ResourceManager.GetStream("snapcracklepop", resourceCulture);
        }

        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;
    }

    
}
