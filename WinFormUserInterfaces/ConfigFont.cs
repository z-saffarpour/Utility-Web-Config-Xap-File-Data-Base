using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZaHra.WinFormUserInterfaces
{
    class ConfigFont
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        static FontFamily _fontFamily;
        
        public static void LoadFont()
        {
            var fontArray = Properties.Resources.fontAwesome;
            var dataLength = Properties.Resources.fontAwesome.Length;

            var ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);


            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            var pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            _fontFamily = pfc.Families[0];
        }

        public static void AllocFont(Control ctrl, FontStyle fontStyle, float size)
        {
            ctrl.Font = new Font(_fontFamily, size, fontStyle);
        }
    }
}
