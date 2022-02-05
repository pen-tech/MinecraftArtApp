using OpenCvSharp;

var blockPass = "../../../assets/";
var blockImgs = new List<string>()
{
    // コンクリ関係
    "black_concrete",
     "black_concrete_powder",
     "blue_concrete",
     "blue_concrete_powder",
     "brown_concrete",
     "brown_concrete_powder",
     "cyan_concrete",
     "cyan_concrete_powder",
     "gray_concrete",
     "gray_concrete_powder",
     "green_concrete",
     "green_concrete_powder",
     "light_blue_concrete",
     "light_blue_concrete_powder",
     "light_gray_concrete",
     "light_gray_concrete_powder",
     "lime_concrete",
     "lime_concrete_powder",
     "magenta_concrete",
     "magenta_concrete_powder",
     "orange_concrete",
     "orange_concrete_powder",
     "pink_concrete",
     "pink_concrete_powder",
     "purple_concrete",
     "purple_concrete_powder",
     "red_concrete",
     "red_concrete_powder",
     "white_concrete",
     "white_concrete_powder",
     "yellow_concrete",
     "yellow_concrete_powder",
    // 木材関係
     "acacia_planks",
     "birch_planks",
     "crimson_planks",
     "dark_oak_planks",
     "jungle_planks",
    // "oak_planks",
     "spruce_planks",
     "warped_planks",
    // 原木関係
     "acacia_log",
    // "birch_log",
     "dark_oak_log",
     "jungle_log",
     "oak_log",
     "spruce_log",
    // 樹皮を向いた原木関係
     "stripped_acacia_log",
    // "stripped_birch_log",
    // "stripped_dark_oak_log",
    // "stripped_jungle_log",
     "stripped_oak_log",
     "stripped_spruce_log",

};

foreach (var item in blockImgs)
{
    var srcImg = Cv2.ImRead($"../../../assets/{item}.png");
    var colorImg = new Mat();

    Cv2.CvtColor(srcImg, colorImg, ColorConversionCodes.BGR2Lab, 0);

    Console.WriteLine(item);

    int L = 0;
    int a = 0;
    int b = 0;

    for (int i = 0; i < colorImg.Height; i++)
    {
        for (int j = 0; j < colorImg.Width; j++)
        {
            // 各ピクセル要素にアクセス
            var pix = colorImg.At<Vec3b>(i, j);
            Console.WriteLine($"要素:{i} {j} => L:{pix[0]} a:{pix[1]} b:{pix[2]}");
            L += pix[0];
            a += pix[1];
            b += pix[2];
        }
    }

    // 各マイクラブロックの平均Lab値を求める
    //Vec3b pixAve = new Vec3b();
    double aveL = (L / (colorImg.Width * colorImg.Height));
    double aveA = (a / (colorImg.Width * colorImg.Height));
    double aveB = (b / (colorImg.Width * colorImg.Height));
    Console.Write($"平均Lab値: {aveL} {aveA} {aveB}");

    Cv2.Resize(srcImg, srcImg, new Size(), 10, 10, InterpolationFlags.Area);
    Cv2.Resize(colorImg, colorImg, new Size(), 10, 10, InterpolationFlags.Area);
    Cv2.ImShow("Block Image", srcImg);
    Cv2.ImShow("Color Image", srcImg);
    Cv2.WaitKey(0);
    Cv2.DestroyWindow("Block Image");
    Cv2.DestroyWindow("Color Image");
}