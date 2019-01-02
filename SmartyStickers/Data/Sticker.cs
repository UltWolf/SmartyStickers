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
            this.Color = Brushes.White;
        }
        public Sticker()
        {

        } 
        public uint IdSticker; 
        public string Text; 
        public SolidColorBrush Color = new SolidColorBrush(Colors.Wheat );
    }
}
