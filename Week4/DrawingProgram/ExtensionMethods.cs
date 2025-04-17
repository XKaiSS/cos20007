using System;
using System.IO;
using SplashKitSDK;

namespace MyGame
{
    public static class ExtensionMethods
    {
        // 从文本中读取一行并转成 int
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }

        // 从文本中读取一行并转成 float
        public static float ReadSingle(this StreamReader reader)
        {
            return Convert.ToSingle(reader.ReadLine());
        }

        // 连续读取三行浮点并构造 Color
        public static Color ReadColor(this StreamReader reader)
        {
            float r = reader.ReadSingle();
            float g = reader.ReadSingle();
            float b = reader.ReadSingle();
            return Color.RGBColor(r, g, b);
        }

        // 将 Color 的 R/G/B 分别写三行
        public static void WriteColor(this StreamWriter writer, Color clr)
        {
            writer.WriteLine(clr.R);
            writer.WriteLine(clr.G);
            writer.WriteLine(clr.B);
        }
    }
}
