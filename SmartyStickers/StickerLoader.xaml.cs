using SmartyStickers.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartyStickers
{
    /// <summary>
    /// Логика взаимодействия для StickerLoader.xaml
    /// </summary>
    public partial class StickerLoader : Window
    {
        private string pathToManager = "Data\\InfoStickers.data";
        public StickerLoader()
        {
            InitializeComponent();
            DataCreating();
            BinaryFormatter formatter = new BinaryFormatter();
           
            using (FileStream fs = new FileStream(pathToManager, FileMode.Open))
            {
                try
                {
                    List<uint> ids = (List<uint>)formatter.Deserialize(fs);
                    if (ids.Count > 0)
                    {
                        LoadStickers(ids);
                    }
                    
                }
                catch(SerializationException)
                {
                    LoadSticker(1);
                    List<uint> ids = new List<uint>(){ 1 };
                   formatter.Serialize(fs,ids);
                }
            }
            this.Close();
        }
        private void DataCreating()
        {
            if (!File.Exists(pathToManager))
            {
                File.Create(pathToManager);
            }
            Directory.CreateDirectory("Data\\Stickers");
        }

        private void LoadStickers(List<uint> stickers)
        {
            foreach(var sticker in stickers)
            {
                LoadSticker(sticker);
            }
        }
        private void LoadSticker(uint sticker)
        {
            MainWindow mw = new MainWindow(sticker);
            mw.Show();
        }
    }
}
