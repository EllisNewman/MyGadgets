using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace ImageComposer
{
    public static class FileManager
    {
        // 设置默认值
        public static FUNC_TYPE funcType = FUNC_TYPE.SSRWide;
        public static UPRIGHT_TYPE uprightType = UPRIGHT_TYPE.Both;
        public static CARD_TYPE cardType = CARD_TYPE.Origin;
        public static GASHA_TYPE gashaType = GASHA_TYPE.Origin;

        //拼图流程的主入口，从此处区分各个功能要执行的不同操作
        public static ERROR_TYPE ImageCompose(string path)
        {
            ERROR_TYPE result = ERROR_TYPE.Unknown; // todo : 错误类型功能实现得很不好。是错误的尝试，反面教材。有待改进。

            switch (funcType)
            {
                case FUNC_TYPE.SSRWide:
                    result = WideCompose(path);
                break;

                case FUNC_TYPE.SSRUpright:
                    switch (uprightType)
                    {
                        case UPRIGHT_TYPE.NoFrame:
                            result = UprightCompose(path);
                        break;

                        case UPRIGHT_TYPE.WithFrame:
                            result = UprightComposeWithFrame(path);
                        break;

                        case UPRIGHT_TYPE.Both:
                            result = UprightCompose(path);
                            if (result == ERROR_TYPE.Succeed)
                                result = UprightComposeWithFrame(path);
                            else UprightComposeWithFrame(path);
                        break;
                    }
                break;

                case FUNC_TYPE.Gasha:
                    result = GashaCardCompose(path);
                break;

                case FUNC_TYPE.GashaInfo:
                    result = GashaInfoCompose(path);
                break;

                case FUNC_TYPE.WhiteBoard:
                    result = WhiteBoardCompose(path);
                break;
            }

            return result;
        }

        #region 横版卡面

        public static ERROR_TYPE WideCompose(string path)
        {
            Bitmap bitmapOrigin;

            try
            {
                bitmapOrigin = new Bitmap(path);
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }

            if (bitmapOrigin.Width != 1024 || bitmapOrigin.Height != 1024)
            {
                return ERROR_TYPE.SizeError;
            }

            Bitmap bitmapLeft = new Bitmap(1024, 720);
            Bitmap bitmapRight = new Bitmap(720, 258);
            Bitmap bitmapResult = new Bitmap(1280, 720);

            //DrawImage中，new rectangle指定目标图像尺寸，后面四个参数决定左上到右下两点的位置，从而确定出要切割出来的矩形图像，最后绘制到目标位图上。
            Graphics graphics = Graphics.FromImage(bitmapLeft);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 1024, 720), 0, 0, 1024, 720, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmapRight);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 720, 258), 0, 764, 722, 258, GraphicsUnit.Pixel);

            bitmapRight.RotateFlip(RotateFlipType.Rotate270FlipNone);

            //每个像素依次绘制到目标位图上。效率较低，有待改进。

            for (int i = 0; i < 1024; i++)
            {
                for (int j = 0; j < 720; j++)
                {
                    var pixel = bitmapLeft.GetPixel(i, j);
                    bitmapResult.SetPixel(i, j, pixel);
                }
            }

            for (int i = 0; i < 258; i++)
            {
                for (int j = 0; j < 720; j++)
                {
                    var pixel = bitmapRight.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 1022, j, pixel);
                }
            }

            if (cardType == CARD_TYPE.Origin)
            {
                try
                {
                    bitmapResult.Save(CreateSaveName(path), ImageFormat.Png);
                    bitmapOrigin.Dispose();
                    bitmapLeft.Dispose();
                    bitmapRight.Dispose();
                    bitmapResult.Dispose();
                    graphics.Dispose();
                }
                catch (Exception)
                {
                    return ERROR_TYPE.FileError;
                }
                return ERROR_TYPE.Succeed;
            }
            else
            {
                if (cardType == CARD_TYPE.Both)
                {
                    bitmapResult.Save(CreateSaveName(path), ImageFormat.Png);
                }

                Bitmap bitmapWide = new Bitmap(GetWideGashaName(path));

                if (bitmapWide.Width != 512 || bitmapWide.Height != 512)
                {
                    return ERROR_TYPE.SizeError;
                }

                Bitmap bitmap1 = new Bitmap(168, 510);
                Bitmap bitmap2 = new Bitmap(168, 510);
                Bitmap bitmap3 = new Bitmap(168, 210);
                Bitmap bitmap4 = new Bitmap(168, 210);
                Bitmap bitmapResultWide = new Bitmap(1616, 720);

                graphics = Graphics.FromImage(bitmap1);
                graphics.DrawImage(bitmapWide, new Rectangle(0, 0, 168, 510), 0, 0, 168, 510, GraphicsUnit.Pixel);
                graphics = Graphics.FromImage(bitmap2);
                graphics.DrawImage(bitmapWide, new Rectangle(0, 0, 168, 510), 170, 0, 168, 510, GraphicsUnit.Pixel);
                graphics = Graphics.FromImage(bitmap3);
                graphics.DrawImage(bitmapWide, new Rectangle(0, 0, 168, 210), 340, 0, 168, 210, GraphicsUnit.Pixel);
                graphics = Graphics.FromImage(bitmap4);
                graphics.DrawImage(bitmapWide, new Rectangle(0, 0, 168, 210), 340, 256, 168, 210, GraphicsUnit.Pixel);

                for (int i = 0; i < 168; i++)//b1
                {
                    for (int j = 0; j < 510; j++)
                    {
                        var pixel = bitmap1.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i, j, pixel);
                    }
                }

                for (int i = 0; i < 168; i++)//b3
                {
                    for (int j = 0; j < 210; j++)
                    {
                        var pixel = bitmap3.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i, j + 510, pixel);
                    }
                }

                for (int i = 0; i < 1280; i++)//br
                {
                    for (int j = 0; j < 720; j++)
                    {
                        var pixel = bitmapResult.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i + 168, j, pixel);
                    }
                }

                for (int i = 0; i < 168; i++)//b2
                {
                    for (int j = 0; j < 510; j++)
                    {
                        var pixel = bitmap2.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i + 1448, j, pixel);
                    }
                }

                for (int i = 0; i < 168; i++)//b4
                {
                    for (int j = 0; j < 210; j++)
                    {
                        var pixel = bitmap4.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i + 1448, j + 510, pixel);
                    }
                }

                try
                {
                    bitmapResultWide.Save(CreateWideGashaName(path), ImageFormat.Png);
                    bitmapOrigin.Dispose();
                    bitmapLeft.Dispose();
                    bitmapRight.Dispose();
                    bitmapResult.Dispose();
                    bitmapResultWide.Dispose();
                    bitmapWide.Dispose();
                    bitmap1.Dispose();
                    bitmap2.Dispose();
                    bitmap3.Dispose();
                    bitmap4.Dispose();
                    graphics.Dispose();
                }
                catch (Exception)
                {
                    return ERROR_TYPE.FileError;
                }
                return ERROR_TYPE.Succeed;
            }

        }

        #endregion

        #region 竖版卡面
        public static ERROR_TYPE UprightCompose(string path)
        {
            Bitmap bitmapOrigin;
            try
            {
                bitmapOrigin = new Bitmap(path);
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }

            if (bitmapOrigin.Width != 1024 || bitmapOrigin.Height != 1024)
            {
                return ERROR_TYPE.SizeError;
            }

            Bitmap bitmap1 = new Bitmap(640, 510);
            Bitmap bitmap2 = new Bitmap(380, 290);
            Bitmap bitmap3 = new Bitmap(260, 218);
            Bitmap bitmap4 = new Bitmap(118, 72);
            Bitmap bitmap5 = new Bitmap(118, 72);
            Bitmap bitmap6 = new Bitmap(24, 72);
            Bitmap bitmapResult = new Bitmap(640, 800);

            Graphics graphics = Graphics.FromImage(bitmap1);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 640, 510), 0, 0, 640, 510, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap2);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 380, 290), 642, 0, 380, 290, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap3);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 260, 218), 642, 292, 260, 218, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap4);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 118, 72), 904, 292, 118, 72, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap5);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 118, 72), 904, 366, 118, 72, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap6);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 24, 72), 904, 440, 24, 72, GraphicsUnit.Pixel);

            for (int i = 0; i < 640; i++)//1
            {
                for (int j = 0; j < 510; j++)
                {
                    var pixel = bitmap1.GetPixel(i, j);
                    bitmapResult.SetPixel(i, j, pixel);
                }
            }
            for (int i = 0; i < 380; i++)//2
            {
                for (int j = 0; j < 290; j++)
                {
                    var pixel = bitmap2.GetPixel(i, j);
                    bitmapResult.SetPixel(i, j + 510, pixel);
                }
            }
            for (int i = 0; i < 260; i++)//3
            {
                for (int j = 0; j < 218; j++)
                {
                    var pixel = bitmap3.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 380, j + 510, pixel);
                }
            }
            for (int i = 0; i < 118; i++)//4
            {
                for (int j = 0; j < 72; j++)
                {
                    var pixel = bitmap4.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 380, j + 728, pixel);
                }
            }
            for (int i = 0; i < 118; i++)//5
            {
                for (int j = 0; j < 72; j++)
                {
                    var pixel = bitmap5.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 498, j + 728, pixel);
                }
            }
            for (int i = 0; i < 24; i++)//6
            {
                for (int j = 0; j < 72; j++)
                {
                    var pixel = bitmap6.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 616, j + 728, pixel);
                }
            }

            try
            {
                bitmapResult.Save(CreateNameWithoutFrame(path), ImageFormat.Png);
                bitmapOrigin.Dispose();
                bitmap1.Dispose();
                bitmap2.Dispose();
                bitmap3.Dispose();
                bitmap4.Dispose();
                bitmap5.Dispose();
                bitmap6.Dispose();
                bitmapResult.Dispose();
                graphics.Dispose();
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }

            return ERROR_TYPE.Succeed;
        }

        public static ERROR_TYPE UprightComposeWithFrame(string path)
        {
            Bitmap bitmapOrigin;
            try
            {
                bitmapOrigin = new Bitmap(path);
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }

            if (bitmapOrigin.Width != 1024 || bitmapOrigin.Height != 1024)
            {
                return ERROR_TYPE.SizeError;
            }

            Bitmap bitmap1 = new Bitmap(640, 510);
            Bitmap bitmap2 = new Bitmap(380, 290);
            Bitmap bitmap3 = new Bitmap(260, 218);
            Bitmap bitmap4 = new Bitmap(118, 72);
            Bitmap bitmap5 = new Bitmap(118, 72);
            Bitmap bitmap6 = new Bitmap(24, 72);
            Bitmap bitmapResult = new Bitmap(640, 800);

            Graphics graphics = Graphics.FromImage(bitmap1);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 640, 510), 0, 512, 640, 510, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap2);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 380, 290), 642, 732, 380, 290, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap3);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 260, 218), 642, 512, 260, 218, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap4);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 118, 72), 904, 658, 118, 72, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap5);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 118, 72), 904, 584, 118, 72, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmap6);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 24, 72), 998, 510, 24, 72, GraphicsUnit.Pixel);

            for (int i = 0; i < 640; i++)//1
            {
                for (int j = 0; j < 510; j++)
                {
                    var pixel = bitmap1.GetPixel(i, j);
                    bitmapResult.SetPixel(i, j, pixel);
                }
            }
            for (int i = 0; i < 380; i++)//2
            {
                for (int j = 0; j < 290; j++)
                {
                    var pixel = bitmap2.GetPixel(i, j);
                    bitmapResult.SetPixel(i, j + 510, pixel);
                }
            }
            for (int i = 0; i < 260; i++)//3
            {
                for (int j = 0; j < 218; j++)
                {
                    var pixel = bitmap3.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 380, j + 510, pixel);
                }
            }
            for (int i = 0; i < 118; i++)//4
            {
                for (int j = 0; j < 72; j++)
                {
                    var pixel = bitmap4.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 380, j + 728, pixel);
                }
            }
            for (int i = 0; i < 118; i++)//5
            {
                for (int j = 0; j < 72; j++)
                {
                    var pixel = bitmap5.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 498, j + 728, pixel);
                }
            }
            for (int i = 0; i < 24; i++)//6
            {
                for (int j = 0; j < 72; j++)
                {
                    var pixel = bitmap6.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 616, j + 728, pixel);
                }
            }

            try
            {
                bitmapResult.Save(CreateNameWithFrame(path), ImageFormat.Png);
                bitmapOrigin.Dispose();
                bitmap1.Dispose();
                bitmap2.Dispose();
                bitmap3.Dispose();
                bitmap4.Dispose();
                bitmap5.Dispose();
                bitmap6.Dispose();
                bitmapResult.Dispose();
                graphics.Dispose();
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }

            return ERROR_TYPE.Succeed;
        }
        #endregion

        #region 卡池界面

        public static ERROR_TYPE GashaCardCompose(string path)
        {
            Bitmap bitmapOrigin;

            try
            {
                bitmapOrigin = new Bitmap(path);
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }

            if (bitmapOrigin.Width != 1024 || bitmapOrigin.Height != 1024)
            {
                return ERROR_TYPE.SizeError;
            }

            Bitmap bitmapLeft = new Bitmap(1024, 720);
            Bitmap bitmapRight = new Bitmap(720, 258);
            Bitmap bitmapResult = new Bitmap(1280, 720);

            Graphics graphics = Graphics.FromImage(bitmapLeft);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 1024, 720), 0, 0, 1024, 720, GraphicsUnit.Pixel);
            graphics = Graphics.FromImage(bitmapRight);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 720, 258), 0, 764, 720, 258, GraphicsUnit.Pixel);

            bitmapRight.RotateFlip(RotateFlipType.Rotate270FlipNone);

            for (int i = 0; i < 1024; i++)
            {
                for (int j = 0; j < 720; j++)
                {
                    var pixel = bitmapLeft.GetPixel(i, j);
                    bitmapResult.SetPixel(i, j, pixel);
                }
            }

            for (int i = 0; i < 258; i++)
            {
                for (int j = 0; j < 720; j++)
                {
                    var pixel = bitmapRight.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 1022, j, pixel);
                }
            }
            if (gashaType == GASHA_TYPE.Origin)
            {
                try
                {
                    bitmapResult.Save(CreateGashaName(path), ImageFormat.Png);
                    bitmapOrigin.Dispose();
                    bitmapLeft.Dispose();
                    bitmapRight.Dispose();
                    bitmapResult.Dispose();
                    graphics.Dispose();
                }
                catch (Exception)
                {
                    return ERROR_TYPE.FileError;
                }
                return ERROR_TYPE.Succeed;
            }
            else
            {
                if (gashaType == GASHA_TYPE.Both)
                {
                    bitmapResult.Save(CreateGashaName(path), ImageFormat.Png);
                }

                Bitmap bitmapWide = new Bitmap(GetWideGashaName(path));

                if (bitmapWide.Width != 512 || bitmapWide.Height != 512)
                {
                    return ERROR_TYPE.SizeError;
                }

                Bitmap bitmap1 = new Bitmap(168, 510);
                Bitmap bitmap2 = new Bitmap(168, 510);
                Bitmap bitmap3 = new Bitmap(168, 210);
                Bitmap bitmap4 = new Bitmap(168, 210);
                Bitmap bitmapResultWide = new Bitmap(1616, 720);

                graphics = Graphics.FromImage(bitmap1);
                graphics.DrawImage(bitmapWide, new Rectangle(0, 0, 168, 510), 0, 0, 168, 510, GraphicsUnit.Pixel);
                graphics = Graphics.FromImage(bitmap2);
                graphics.DrawImage(bitmapWide, new Rectangle(0, 0, 168, 510), 170, 0, 168, 510, GraphicsUnit.Pixel);
                graphics = Graphics.FromImage(bitmap3);
                graphics.DrawImage(bitmapWide, new Rectangle(0, 0, 168, 210), 340, 0, 168, 210, GraphicsUnit.Pixel);
                graphics = Graphics.FromImage(bitmap4);
                graphics.DrawImage(bitmapWide, new Rectangle(0, 0, 168, 210), 340, 256, 168, 210, GraphicsUnit.Pixel);

                for (int i = 0; i < 168; i++)//b1
                {
                    for (int j = 0; j < 510; j++)
                    {
                        var pixel = bitmap1.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i, j, pixel);
                    }
                }

                for (int i = 0; i < 168; i++)//b3
                {
                    for (int j = 0; j < 210; j++)
                    {
                        var pixel = bitmap3.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i, j + 510, pixel);
                    }
                }

                for (int i = 0; i < 1280; i++)//br
                {
                    for (int j = 0; j < 720; j++)
                    {
                        var pixel = bitmapResult.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i + 168, j, pixel);
                    }
                }

                for (int i = 0; i < 168; i++)//b2
                {
                    for (int j = 0; j < 510; j++)
                    {
                        var pixel = bitmap2.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i + 1448, j, pixel);
                    }
                }

                for (int i = 0; i < 168; i++)//b4
                {
                    for (int j = 0; j < 210; j++)
                    {
                        var pixel = bitmap4.GetPixel(i, j);
                        bitmapResultWide.SetPixel(i + 1448, j + 510, pixel);
                    }
                }

                try
                {
                    bitmapResultWide.Save(CreateWideGashaName(path), ImageFormat.Png);
                    bitmapOrigin.Dispose();
                    bitmapLeft.Dispose();
                    bitmapRight.Dispose();
                    bitmapResult.Dispose();
                    bitmapResultWide.Dispose();
                    bitmapWide.Dispose();
                    bitmap1.Dispose();
                    bitmap2.Dispose();
                    bitmap3.Dispose();
                    bitmap4.Dispose();
                    graphics.Dispose();
                }
                catch (Exception)
                {
                    return ERROR_TYPE.FileError;
                }
                return ERROR_TYPE.Succeed;
            }

        }

        #endregion

        #region 卡池介绍图
        public static ERROR_TYPE GashaInfoCompose(string path)
        {
            Bitmap bitmapOrigin;

            try
            {
                bitmapOrigin = new Bitmap(path);
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }

            if (bitmapOrigin.Width != 512 || bitmapOrigin.Height != 512)
            {
                return ERROR_TYPE.SizeError;
            }

            Bitmap bitmapLeft = new Bitmap(510, 324);
            Bitmap bitmapRight = new Bitmap(324, 66);
            Bitmap bitmapResult = new Bitmap(576, 324);

            Graphics graphics = Graphics.FromImage(bitmapLeft);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0,0,510,324), 0, 0, 510, 324, GraphicsUnit.Pixel);

            Graphics graphics2 = Graphics.FromImage(bitmapRight);
            graphics2.DrawImage(bitmapOrigin, new Rectangle(0,0,324,66), 2, 444, 324, 66, GraphicsUnit.Pixel);

            bitmapRight.RotateFlip(RotateFlipType.Rotate270FlipNone);

            for (int i = 0; i < 510; i++)
            {
                for (int j = 0; j < 324; j++)
                {
                    var pixel = bitmapLeft.GetPixel(i, j);
                    bitmapResult.SetPixel(i, j, pixel);
                }
            }

            for (int i = 0; i < 66; i++)
            {
                for (int j = 0; j < 324; j++)
                {
                    var pixel = bitmapRight.GetPixel(i, j);
                    bitmapResult.SetPixel(i + 510, j, pixel); //todo : magic number...
                }
            }

            try
            {
                bitmapResult.Save(CreateSaveName(path), ImageFormat.Png);
                bitmapOrigin.Dispose();
                bitmapLeft.Dispose();
                bitmapRight.Dispose();
                bitmapResult.Dispose();
                graphics.Dispose();
                graphics2.Dispose();
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }
            return ERROR_TYPE.Succeed;
        }

        #endregion

        #region 白板图

        public static ERROR_TYPE WhiteBoardCompose(string path)
        {
            Bitmap bitmapOrigin;

            try
            {
                bitmapOrigin = new Bitmap(path);
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }

            if (bitmapOrigin.Width != 512 || bitmapOrigin.Height != 256)
            {
                return ERROR_TYPE.SizeError;
            }

            Bitmap bitmapResult = new Bitmap(355, 205);

            Graphics graphics = Graphics.FromImage(bitmapResult);
            graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 356, 206), 3, 3, 357, 207, GraphicsUnit.Pixel);

            try
            {
                bitmapResult.Save(CreateSaveName(path), ImageFormat.Png);
                bitmapOrigin.Dispose();
                bitmapResult.Dispose();
                graphics.Dispose();
            }
            catch (Exception)
            {
                return ERROR_TYPE.FileError;
            }
            return ERROR_TYPE.Succeed;
        }

        #endregion

        #region tool

        public static string CreateSaveName(string str)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            if (num > 1)
                strResult[num - 2] += " - Composed";
            StringBuilder resultStrB = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                resultStrB.Append(strResult[i]);
                if (i < num - 1)
                    resultStrB.Append(".");
            }
            string result = resultStrB.ToString();

            return result;
        }

        public static string CreateNameWithoutFrame(string str)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            if (num > 1)
                strResult[num - 2] += " - NoFrame";
            StringBuilder resultStrB = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                resultStrB.Append(strResult[i]);
                if (i < num - 1)
                    resultStrB.Append(".");
            }
            string result = resultStrB.ToString();

            return result;
        }

        public static string CreateNameWithFrame(string str)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            if (num > 1)
                strResult[num - 2] += " - WithFrame";
            StringBuilder resultStrB = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                resultStrB.Append(strResult[i]);
                if (i < num - 1)
                    resultStrB.Append(".");
            }
            string result = resultStrB.ToString();

            return result;
        }

        public static string CreateGashaName(string str)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            if (num > 1)
                strResult[num - 2] += " - Gasha";
            StringBuilder resultStrB = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                resultStrB.Append(strResult[i]);
                if (i < num - 1)
                    resultStrB.Append(".");
            }
            string result = resultStrB.ToString();

            return result;
        }

        public static string CreateWideGashaName(string str)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            if (num > 1)
                strResult[num - 2] += " - GashaWideScreen";
            StringBuilder resultStrB = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                resultStrB.Append(strResult[i]);
                if (i < num - 1)
                    resultStrB.Append(".");
            }
            string result = resultStrB.ToString();

            return result;
        }

        public static string GetWideGashaName(string str)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            if (num > 1)
                strResult[num - 2] += "_x";
            StringBuilder resultStrB = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                resultStrB.Append(strResult[i]);
                if (i < num - 1)
                    resultStrB.Append(".");
            }
            string result = resultStrB.ToString();

            return result;
        }

        public static string CreateGashaInfoName(string str)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            if (num > 1)
                strResult[num - 2] += " - GashaInfo";
            StringBuilder resultStrB = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                resultStrB.Append(strResult[i]);
                if (i < num - 1)
                    resultStrB.Append(".");
            }
            string result = resultStrB.ToString();

            return result;
        }

        #endregion
    
    }
}
