using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using MinecraftConnection;

namespace MinecraftArtApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage srcImg = new BitmapImage();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetImgButton(object sender, RoutedEventArgs args)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "画像ファイル|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    srcImg = new BitmapImage();
                    var ms = new MemoryStream();
                    using (var fs = new FileStream(dialog.FileName, FileMode.Open))
                    {
                        fs.CopyTo(ms);
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    srcImg.BeginInit();
                    srcImg.StreamSource = ms;
                    srcImg.EndInit();

                    this.beforeImg.Source = srcImg;
                    this.convertImgButton.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ConvertImgButton(object sender, RoutedEventArgs args)
        {
            this.afterImg.Source = srcImg.ToMinecraftImage();
            this.imgToMinecraftButton.IsEnabled = true;
        }

        private void ImgToMinecraftButton(object sender, RoutedEventArgs args)
        {
            // ローカルホストへ接続
            MinecraftCommands commands = new MinecraftCommands("127.0.0.1", 25575, "minecraft");
            for (int i = 0; i < ImgConvert.blockId.GetLength(0); i++)
            {
                for (int j = 0; j < ImgConvert.blockId.GetLength(1); j++)
                {
                    // 砂系ブロックは落下してしまうので下に石ブロックを引いておく
                    // 座標は皆さんの環境に合わせてください.
                    commands.SetBlock(64 + i, 100, 64 + j, "stone");
                    commands.SetBlock(64 + i, 101, 64 + j, ImgConvert.blockId[i, j]);
                }
            }
        }

    }
}