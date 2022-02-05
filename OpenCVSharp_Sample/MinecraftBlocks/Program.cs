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
     "oak_planks",
     "spruce_planks",
     "warped_planks",
    // 原木関係
     "acacia_log",
     "birch_log",
     "dark_oak_log",
     "jungle_log",
     "oak_log",
     "spruce_log",
    // 樹皮を向いた原木関係
     "stripped_acacia_log",
     "stripped_birch_log",
     "stripped_dark_oak_log",
     "stripped_jungle_log",
     "stripped_oak_log",
     "stripped_spruce_log",
     // テラコッタ関連
     "black_terracotta",
     "blue_terracotta",
     "brown_terracotta",
     "cyan_terracotta",
     "gray_terracotta",
     "green_terracotta",
     "light_blue_terracotta",
     "light_gray_terracotta",
     "lime_terracotta",
     "magenta_terracotta",
     "orange_terracotta",
     "pink_terracotta",
     "purple_terracotta",
     "red_terracotta",
     "terracotta",
     "white_terracotta",
     "yellow_terracotta",
};

var blockData = new List<Vec3b>();

foreach (var item in blockImgs)
{
    var srcImg = Cv2.ImRead($"../../../assets/{item}.png");
    var labImg = new Mat();
    //labImg = srcImg.Clone();
    
    Cv2.CvtColor(srcImg, labImg, ColorConversionCodes.RGB2Lab, 0);

    Console.WriteLine(item);

    int L = 0;
    int a = 0;
    int b = 0;

    for (int i = 0; i < labImg.Height; i++)
    {
        for (int j = 0; j < labImg.Width; j++)
        {
            // 各ピクセル要素にアクセス
            var pix = labImg.At<Vec3b>(i, j);
            //Console.WriteLine($"L:{pix[0]} a:{pix[1]} b:{pix[2]}");
            L += pix[0];
            a += pix[1];
            b += pix[2];
        }
    }

    // 各マイクラブロックの平均Lab値を求める
    double aveL = (L / (labImg.Width * labImg.Height));
    double aveA = (a / (labImg.Width * labImg.Height));
    double aveB = (b / (labImg.Width * labImg.Height));
    Vec3b pixAve = new Vec3b();
    pixAve.Item0 = (byte)aveL;
    pixAve.Item1 = (byte)aveA;
    pixAve.Item2 = (byte)aveB;

    blockData.Add(pixAve);
}

blockData.ForEach(item => Console.WriteLine(item));

int count = 0;
var list = new List<string>();
foreach(var item in blockData)
{
    list.Add("new MinecraftBlock " + "{ "
        + "L = " + item.Item0
        + ", a = " + item.Item1
        + ", b = " + item.Item2
        + ", blockId = " + $"\"{blockImgs[count]}\""
        + " },");
    count++;
}

list.ForEach(item => Console.WriteLine(item));