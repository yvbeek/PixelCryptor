#region Using directives
using System;
using System.Drawing;
#endregion

namespace PixelCryptor.IO {
    /// <summary>
    /// Class for Filesystem object information.
    /// </summary>
    public struct ShellObject {
        public Bitmap SmallIcon;
        public Bitmap LargeIcon;
        public string TypeName;
    }
}
