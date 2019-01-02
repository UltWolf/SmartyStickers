using System;
using System.Windows.Media;

namespace SmartyStickers.Data
{
    [Serializable]
    public class Sticker
    {
        public Sticker (uint IdSticker)
        {
            this.IdSticker = IdSticker;
        }
        public Sticker()
        {

        }
        public void SetColor(byte R,byte G, byte B)
        {
            this.R = R;
            this.G = G;
            this.B = B; 
        }
        public byte R =255;
        public byte G =255;
        public byte B = 255;
        
        public uint IdSticker; 
        public string Text;  
    }
}
