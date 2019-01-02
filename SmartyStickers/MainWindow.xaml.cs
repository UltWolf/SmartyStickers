using SmartyStickers.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartyStickers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string PathToStickerManager = "Data\\InfoStickers.data";
        private Sticker sticker = new Sticker();
        private string PathToSticker;
        
        BinaryFormatter bf = new BinaryFormatter();
        public MainWindow(uint IdSticker)
        {
            InitializeComponent();
            this.sticker =  new Sticker(IdSticker);
            this.PathToSticker = "Data//Stickers//" + sticker.IdSticker + ".data";
            RecoveryWindow();
         
        }
        private void WriteDataToSticker()
        {
            sticker.Text = Notes.Text;
            if (File.Exists(this.PathToSticker))
            {
                
                using (FileStream fs = new FileStream(this.PathToSticker, FileMode.Create))
                {
                    bf.Serialize(fs, sticker);
                }
            }
        }
        public MainWindow( )
        {
            InitializeComponent(); 

        }
        private  void RecoveryWindow()
        {
            if (File.Exists(this.PathToSticker)) {
                using (FileStream fs = new FileStream(this.PathToSticker,FileMode.Open))
                {
                    this.sticker = (Sticker)bf.Deserialize(fs);
                }
            }
             MainGrid.Background = new SolidColorBrush(Color.FromRgb(sticker.R, sticker.G, sticker.B));
             Notes.Text = sticker.Text;
        }
        private uint GetLastNumberArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(PathToStickerManager, FileMode.Open))
            {
                var array =  (List<uint>)bf.Deserialize(fs);
                return (uint)array[array.Count - 1];
            }

        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainGrid.Background = Brushes.Red;
            this.sticker.SetColor(255, 0, 0);
        }

        private void YellowButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Yellow;
        }

        private void GreenButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Green;
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Blue;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

         
 

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            WriteDataToSticker();
            MessageBox.Show("File have been saved");
        }

        private void AddSticker_Click(object sender, RoutedEventArgs e)
        {
            var lastId = GetLastNumberArray() + 1;
            var windows = new MainWindow(lastId);
            List<uint> ids = new List<uint>();
            using (FileStream fs = new FileStream(PathToStickerManager, FileMode.Open))
            {
               ids = (List<uint>)bf.Deserialize(fs);
            }
            ids.Add(lastId);
                    using (FileStream fs = new FileStream(this.PathToStickerManager, FileMode.Create))
                    {
                        bf.Serialize(fs, ids);
                    } 
           
                    windows.Show();
        }

        private void CloseSticker_Click(object sender, RoutedEventArgs e)
        {
            WriteDataToSticker();
            this.Close();
        }
    }
}
