using OpenCvSharp;
using OpenCVSharp_Sample;
using MinecraftConnection;

//MinecraftCommands commands = new MinecraftCommands("127.0.0.1", 25575, "minecraft");

//Console.Write("Resize:");
//var scaleSize = double.Parse(Console.ReadLine());
var scaleSize = 128.0;

var blockData = new List<MinecraftBlock>()
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

Mat srcImg = Cv2.ImRead(@"C:\Users\Takun\Desktop\img.jpeg");
//Mat srcImg = Cv2.ImRead(@"C:\Users\Takun\Desktop\lamy.png");
Mat resizeImg = new Mat();
Mat mosaicImg = new Mat();

double scale = scaleSize / srcImg.Width;

Console.WriteLine($"Width:{srcImg.Width * scale} Height:{srcImg.Height* scale}");
// 画像のリサイズ
Cv2.Resize(srcImg, resizeImg, new OpenCvSharp.Size(), scale, scale, InterpolationFlags.Area);
// モザイク画像変換
Cv2.Resize(resizeImg, mosaicImg, new OpenCvSharp.Size(), 1, 1, InterpolationFlags.Area);
// Lab色空間への変換
Mat labImg = new Mat(mosaicImg.Rows, mosaicImg.Cols, MatType.CV_8U);
Cv2.CvtColor(mosaicImg, labImg, ColorConversionCodes.RGB2Lab);

// 各ピクセル要素のLab値とマイクラブロックのLab値計算
string[,] blocks = new string[labImg.Rows, labImg.Cols];
for (int i = 0; i < labImg.Rows; i++)
{
    for (int j = 0; j < labImg.Cols; j++)
    {
        int element = 0; // ブロックIDの要素数
        double mostLow = 100; // ユークリッド距離

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
        blocks[i, j] = $"../../../assets/{blockData[element].blockId}.png";
        //commands.SendCommand($"setblock {64 + i} {100} {64 + j} air");
        //commands.SendCommand($"setblock {64 + i} {101} {64 + j} air");

        //commands.SendCommand($"setblock {64 + i} {101} {64 + j} {blockData[element].blockId}");
    }
}

//Cv2.ImShow("Lab Image", labImg);

// ブロック用に 16 倍
Cv2.Resize(labImg, labImg, new OpenCvSharp.Size(), 16, 16, InterpolationFlags.Area);
Mat minecraftImg = labImg.Clone();

// マイクラのブロックに置き換える
for (int i = 0; i < mosaicImg.Rows; i++)
{
    for (int j = 0; j < mosaicImg.Cols; j++)
    {
        var rect = new Rect(16 * j, 16 * i, 16, 16);
        minecraftImg[rect] = new Mat(blocks[i, j]);
        
    }
}
Cv2.Resize(labImg, labImg, new OpenCvSharp.Size(), 0.5, 0.5, InterpolationFlags.Area);
Cv2.ImShow("Lab Image", labImg);
Cv2.Resize(resizeImg, mosaicImg, new OpenCvSharp.Size(), 5, 5, InterpolationFlags.Area);
Cv2.ImShow("Mosaic Image", mosaicImg);
Cv2.Resize(minecraftImg, minecraftImg, new OpenCvSharp.Size(), 0.4, 0.4, InterpolationFlags.Area);
Cv2.ImShow("Minecraft Image", minecraftImg);

Cv2.WaitKey(0);
Cv2.DestroyAllWindows();