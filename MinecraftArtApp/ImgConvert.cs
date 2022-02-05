using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MinecraftArtApp
{
    public static class ImgConvert
    {
        private static List<MinecraftBlock> blockData = new List<MinecraftBlock>()
        {
            new MinecraftBlock { L = 8, a = 130, b = 130, blockId = "black_concrete" },
            new MinecraftBlock { L = 25, a = 130, b = 129, blockId = "black_concrete_powder" },
            new MinecraftBlock { L = 87, a = 168, b = 151, blockId = "blue_concrete" },
            new MinecraftBlock { L = 110, a = 166, b = 148, blockId = "blue_concrete_powder" },
            new MinecraftBlock { L = 63, a = 131, b = 103, blockId = "brown_concrete" },
            new MinecraftBlock { L = 90, a = 129, b = 101, blockId = "brown_concrete_powder" },
            new MinecraftBlock { L = 128, a = 124, b = 179, blockId = "cyan_concrete" },
            new MinecraftBlock { L = 153, a = 118, b = 183, blockId = "cyan_concrete_powder" },
            new MinecraftBlock { L = 62, a = 129, b = 130, blockId = "gray_concrete" },
            new MinecraftBlock { L = 88, a = 128, b = 130, blockId = "gray_concrete_powder" },
            new MinecraftBlock { L = 88, a = 105, b = 133, blockId = "green_concrete" },
            new MinecraftBlock { L = 115, a = 99, b = 133, blockId = "green_concrete_powder" },
            new MinecraftBlock { L = 157, a = 143, b = 187, blockId = "light_blue_concrete" },
            new MinecraftBlock { L = 190, a = 128, b = 184, blockId = "light_blue_concrete_powder" },
            new MinecraftBlock { L = 132, a = 124, b = 127, blockId = "light_gray_concrete" },
            new MinecraftBlock { L = 161, a = 125, b = 127, blockId = "light_gray_concrete_powder" },
            new MinecraftBlock { L = 155, a = 75, b = 156, blockId = "lime_concrete" },
            new MinecraftBlock { L = 174, a = 75, b = 149, blockId = "lime_concrete_powder" },
            new MinecraftBlock { L = 107, a = 188, b = 86, blockId = "magenta_concrete" },
            new MinecraftBlock { L = 133, a = 183, b = 88, blockId = "magenta_concrete_powder" },
            new MinecraftBlock { L = 113, a = 154, b = 57, blockId = "orange_concrete" },
            new MinecraftBlock { L = 138, a = 135, b = 72, blockId = "orange_concrete_powder" },
            new MinecraftBlock { L = 132, a = 168, b = 76, blockId = "pink_concrete" },
            new MinecraftBlock { L = 174, a = 153, b = 93, blockId = "pink_concrete_powder" },
            new MinecraftBlock { L = 91, a = 183, b = 119, blockId = "purple_concrete" },
            new MinecraftBlock { L = 112, a = 184, b = 112, blockId = "purple_concrete_powder" },
            new MinecraftBlock { L = 54, a = 166, b = 68, blockId = "red_concrete" },
            new MinecraftBlock { L = 76, a = 164, b = 66, blockId = "red_concrete_powder" },
            new MinecraftBlock { L = 217, a = 127, b = 131, blockId = "white_concrete" },
            new MinecraftBlock { L = 230, a = 127, b = 128, blockId = "white_concrete_powder" },
            new MinecraftBlock { L = 172, a = 114, b = 85, blockId = "yellow_concrete" },
            new MinecraftBlock { L = 190, a = 101, b = 100, blockId = "yellow_concrete_powder" },
            new MinecraftBlock { L = 100, a = 140, b = 82, blockId = "acacia_planks" },
            new MinecraftBlock { L = 174, a = 114, b = 113, blockId = "birch_planks" },
            new MinecraftBlock { L = 63, a = 150, b = 100, blockId = "crimson_planks" },
            new MinecraftBlock { L = 43, a = 127, b = 110, blockId = "dark_oak_planks" },
            new MinecraftBlock { L = 121, a = 128, b = 99, blockId = "jungle_planks" },
            new MinecraftBlock { L = 133, a = 119, b = 105, blockId = "oak_planks" },
            new MinecraftBlock { L = 88, a = 124, b = 106, blockId = "spruce_planks" },
            new MinecraftBlock { L = 108, a = 116, b = 161, blockId = "warped_planks" },
            new MinecraftBlock { L = 102, a = 125, b = 123, blockId = "acacia_log" },
            new MinecraftBlock { L = 217, a = 126, b = 126, blockId = "birch_log" },
            new MinecraftBlock { L = 46, a = 124, b = 116, blockId = "dark_oak_log" },
            new MinecraftBlock { L = 68, a = 119, b = 113, blockId = "jungle_log" },
            new MinecraftBlock { L = 88, a = 123, b = 110, blockId = "oak_log" },
            new MinecraftBlock { L = 36, a = 127, b = 111, blockId = "spruce_log" },
            new MinecraftBlock { L = 104, a = 143, b = 80, blockId = "stripped_acacia_log" },
            new MinecraftBlock { L = 175, a = 114, b = 111, blockId = "stripped_birch_log" },
            new MinecraftBlock { L = 58, a = 124, b = 115, blockId = "stripped_dark_oak_log" },
            new MinecraftBlock { L = 136, a = 122, b = 102, blockId = "stripped_jungle_log" },
            new MinecraftBlock { L = 146, a = 118, b = 104, blockId = "stripped_oak_log" },
            new MinecraftBlock { L = 93, a = 122, b = 109, blockId = "stripped_spruce_log" },
            new MinecraftBlock { L = 19, a = 130, b = 117, blockId = "black_terracotta" },
            new MinecraftBlock { L = 74, a = 144, b = 124, blockId = "blue_terracotta" },
            new MinecraftBlock { L = 54, a = 129, b = 110, blockId = "brown_terracotta" },
            new MinecraftBlock { L = 98, a = 127, b = 130, blockId = "cyan_terracotta" },
            new MinecraftBlock { L = 43, a = 129, b = 117, blockId = "gray_terracotta" },
            new MinecraftBlock { L = 82, a = 111, b = 127, blockId = "green_terracotta" },
            new MinecraftBlock { L = 124, a = 140, b = 129, blockId = "light_blue_terracotta" },
            new MinecraftBlock { L = 115, a = 131, b = 111, blockId = "light_gray_terracotta" },
            new MinecraftBlock { L = 115, a = 103, b = 129, blockId = "lime_terracotta" },
            new MinecraftBlock { L = 106, a = 150, b = 97, blockId = "magenta_terracotta" },
            new MinecraftBlock { L = 93, a = 140, b = 81, blockId = "orange_terracotta" },
            new MinecraftBlock { L = 95, a = 151, b = 82, blockId = "pink_terracotta" },
            new MinecraftBlock { L = 85, a = 145, b = 102, blockId = "purple_terracotta" },
            new MinecraftBlock { L = 74, a = 150, b = 80, blockId = "red_terracotta" },
            new MinecraftBlock { L = 103, a = 136, b = 93, blockId = "terracotta" },
            new MinecraftBlock { L = 184, a = 129, b = 110, blockId = "white_terracotta" },
            new MinecraftBlock { L = 134, a = 119, b = 92, blockId = "yellow_terracotta" }
        };
        public static string[,] blockId { get;set; }

        public static WriteableBitmap ToMinecraftImage(this BitmapImage image)
        {
            Mat srcImg = image.ToMat();
            Mat resizeImg = new Mat();

            // 画像のリサイズ
            if (srcImg.Width < srcImg.Height)
            {
                double scale = 128.0 / srcImg.Height;
                Cv2.Resize(srcImg, resizeImg, new Size(), scale, scale, InterpolationFlags.Area);
            }
            else
            {
                double scale = 128.0 / srcImg.Width;
                Cv2.Resize(srcImg, resizeImg, new Size(), scale, scale, InterpolationFlags.Area);
            }

            // Lab 値へ変換
            Mat labImg = new Mat(resizeImg.Rows, resizeImg.Cols, MatType.CV_8U);
            Cv2.CvtColor(resizeImg, labImg, ColorConversionCodes.RGB2Lab);

            // ブロックの関連付け
            string[,] blockPass = new string[labImg.Rows, labImg.Cols];
            blockId = new string[labImg.Rows, labImg.Cols];
            for (int i = 0; i < labImg.Rows; i++)
            {
                for (int j = 0; j < labImg.Cols; j++)
                {
                    int element = 0; // ブロックIDの要素数
                    double mostLow = 1000000; // ユークリッド距離

                    var pix = labImg.At<Vec3b>(i, j); // 各ピクセル要素取得
                    for (int k = 0; k < blockData.Count; k++)
                    {
                        double calc = Math.Sqrt(Math.Pow(blockData[k].L - pix.Item0, 2) + Math.Pow(blockData[k].a - pix.Item1, 2) + Math.Pow(blockData[k].b - pix.Item2, 2));
                        if (calc < mostLow)
                        {
                            mostLow = calc;
                            element = k;
                        }
                    }
                    blockPass[i, j] = $"../../../assets/{blockData[element].blockId}.png";
                    blockId[i, j] = blockData[element].blockId;
                }
            }

            // ブロック用に 16 倍して置き換える
            Cv2.Resize(labImg, labImg, new Size(), 16, 16, InterpolationFlags.Area);
            Mat minecraftImg = labImg.Clone();

            for (int i = 0; i < resizeImg.Rows; i++)
            {
                for (int j = 0; j < resizeImg.Cols; j++)
                {
                    var rect = new Rect(16 * j, 16 * i, 16, 16);
                    minecraftImg[rect] = new Mat(blockPass[i, j]);
                }
            }

            return minecraftImg.ToWriteableBitmap();
        }

        private static Mat ToMat(this BitmapImage image)
        {
            var bitmapSource = (BitmapSource)image;
            return BitmapSourceConverter.ToMat(bitmapSource);
        }
    }
}
