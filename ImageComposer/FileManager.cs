using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImageComposer
{
    public static class FileManager
    {
        // 设置默认值
        public static FUNC_TYPE funcType = FUNC_TYPE.SSRWide;
        public static UPRIGHT_TYPE uprightType = UPRIGHT_TYPE.Both;
        public static CARD_TYPE cardType = CARD_TYPE.Origin;
        public static GASHA_TYPE gashaType = GASHA_TYPE.Origin;
        public static GASHAINFO_TYPE gashaInfoType = GASHAINFO_TYPE.New;
        //新增EVENT
        public static EVENT_TYPE eventType = EVENT_TYPE.Full_With_LogoAll;

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
                //新增EVENT
                case FUNC_TYPE.Event:
                    result = EventCompose(path);
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

            //新建位图后将素材剪切绘制到位图上 （修正错位问题：在剪切时需要在y位置增加1像素）
            Bitmap bitmapResult = new Bitmap(1280, 720);
            using (Graphics G_result = Graphics.FromImage(bitmapResult))
            {
                using (Bitmap bitmapLeft = bitmapOrigin.Clone(new System.Drawing.Rectangle(0, 1, 1022, 720), bitmapOrigin.PixelFormat))
                {
                    G_result.DrawImage(bitmapLeft, 0, 0, 1022, 720);
                }
                bitmapOrigin.RotateFlip(RotateFlipType.Rotate270FlipNone);
                using (Bitmap bitmapRight = bitmapOrigin.Clone(new System.Drawing.Rectangle(764, 303, 258, 720), bitmapOrigin.PixelFormat))
                {
                    G_result.DrawImage(bitmapRight, 1022, 0, 258, 720);
                }
                bitmapOrigin.Dispose();
            }

            if (cardType == CARD_TYPE.Origin)
            {
                try
                {
                    bitmapResult.Save(CreateSaveName(path), ImageFormat.Png);
                    bitmapResult.Dispose();
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

                Bitmap bitmapResultWide = new Bitmap(1616, 720);
                using (Graphics G_ResultWide = Graphics.FromImage(bitmapResultWide))
                {
                    G_ResultWide.DrawImage(bitmapResult, 168, 0, 1280, 720);
                    using (Bitmap bitmapWide_L = bitmapWide.Clone(new System.Drawing.Rectangle(0, 1, 168, 510), bitmapOrigin.PixelFormat))
                    {
                        G_ResultWide.DrawImage(bitmapWide_L, 0, 0, 168, 510);
                    }
                    using (Bitmap bitmapWide_R = bitmapWide.Clone(new System.Drawing.Rectangle(170, 1, 168, 510), bitmapOrigin.PixelFormat))
                    {
                        G_ResultWide.DrawImage(bitmapWide_R, 1448, 0, 168, 510);
                    }
                    using (Bitmap bitmapWide_l = bitmapWide.Clone(new System.Drawing.Rectangle(340, 1, 168, 210), bitmapOrigin.PixelFormat))
                    {
                        G_ResultWide.DrawImage(bitmapWide_l, 0, 510, 168, 210);
                    }
                    using (Bitmap bitmapWide_r = bitmapWide.Clone(new System.Drawing.Rectangle(340, 257, 168, 210), bitmapOrigin.PixelFormat))
                    {
                        G_ResultWide.DrawImage(bitmapWide_r, 1448, 510, 168, 210);
                    }
                    bitmapResult.Dispose();
                    bitmapWide.Dispose();
                }

                try
                {
                    bitmapResultWide.Save(CreateWideGashaName(path), ImageFormat.Png);
                    bitmapResultWide.Dispose();
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

        #region EVENT界面
        public static ERROR_TYPE EventCompose(string path)
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

            Bitmap bitmapResult = new Bitmap(1280, 720);
            using (Graphics G_result = Graphics.FromImage(bitmapResult))
            {
                using (Bitmap bitmapLeft = bitmapOrigin.Clone(new System.Drawing.Rectangle(0, 1, 1022, 720), bitmapOrigin.PixelFormat))
                {
                    G_result.DrawImage(bitmapLeft, 0, 0, 1022, 720);
                }
                bitmapOrigin.RotateFlip(RotateFlipType.Rotate270FlipNone);
                using (Bitmap bitmapRight = bitmapOrigin.Clone(new System.Drawing.Rectangle(764, 303, 258, 720), bitmapOrigin.PixelFormat))
                {
                    G_result.DrawImage(bitmapRight, 1022, 0, 258, 720);
                }
                bitmapOrigin.Dispose();
            }

            if (eventType == EVENT_TYPE.ALL)
            {
                bitmapResult.Save(CreateFullEventName(path, CREATEFILENAME_TYPE.Origin), ImageFormat.Png);
            }

            Bitmap bitmapWide = new Bitmap(GetFullEventName(path, GETFILENAME_TYPE.x0));

            if (bitmapWide.Width != 512 || bitmapWide.Height != 512)
            {
                return ERROR_TYPE.SizeError;
            }

            Bitmap bitmapResultWide = new Bitmap(1616, 720);
            using (Graphics G_ResultWide = Graphics.FromImage(bitmapResultWide))
            {
                G_ResultWide.DrawImage(bitmapResult, 168, 0, 1280, 720);
                using (Bitmap bitmapWide_L = bitmapWide.Clone(new System.Drawing.Rectangle(0, 1, 168, 510), bitmapOrigin.PixelFormat))
                {
                    G_ResultWide.DrawImage(bitmapWide_L, 0, 0, 168, 510);
                }
                using (Bitmap bitmapWide_R = bitmapWide.Clone(new System.Drawing.Rectangle(170, 1, 168, 510), bitmapOrigin.PixelFormat))
                {
                    G_ResultWide.DrawImage(bitmapWide_R, 1448, 0, 168, 510);
                }
                using (Bitmap bitmapWide_l = bitmapWide.Clone(new System.Drawing.Rectangle(340, 1, 168, 210), bitmapOrigin.PixelFormat))
                {
                    G_ResultWide.DrawImage(bitmapWide_l, 0, 510, 168, 210);
                }
                using (Bitmap bitmapWide_r = bitmapWide.Clone(new System.Drawing.Rectangle(340, 257, 168, 210), bitmapOrigin.PixelFormat))
                {
                    G_ResultWide.DrawImage(bitmapWide_r, 1448, 510, 168, 210);
                }
                bitmapResult.Dispose();
                bitmapWide.Dispose();
            }

            if (eventType == EVENT_TYPE.ALL)
            {
                bitmapResultWide.Save(CreateFullEventName(path, CREATEFILENAME_TYPE.EventWide), ImageFormat.Png);
            }

            Bitmap bitmapFull_T = new Bitmap(GetFullEventName(path, GETFILENAME_TYPE.x1));

            if (bitmapFull_T.Width != 512 || bitmapFull_T.Height != 512)
            {
                return ERROR_TYPE.SizeError;
            }

            Bitmap bitmapResultFull = new Bitmap(1616, 960);
            using (Graphics G_ResultFull = Graphics.FromImage(bitmapResultFull))
            {
                G_ResultFull.DrawImage(bitmapResultWide, 0, 120, 1616, 720);
                using (Bitmap bitmapFull_T1 = bitmapFull_T.Clone(new System.Drawing.Rectangle(0, 1, 510, 120), bitmapFull_T.PixelFormat))
                {
                    G_ResultFull.DrawImage(bitmapFull_T1, 0, 0, 510, 120);
                }
                using (Bitmap bitmapFull_T2 = bitmapFull_T.Clone(new System.Drawing.Rectangle(0, 123, 510, 120), bitmapFull_T.PixelFormat))
                {
                    G_ResultFull.DrawImage(bitmapFull_T2, 510, 0, 510, 120);
                }
                using (Bitmap bitmapFull_T3 = bitmapFull_T.Clone(new System.Drawing.Rectangle(0, 245, 510, 120), bitmapFull_T.PixelFormat))
                {
                    G_ResultFull.DrawImage(bitmapFull_T3, 1020, 0, 510, 120);
                }
                using (Bitmap bitmapFull_T4 = bitmapFull_T.Clone(new System.Drawing.Rectangle(0, 367, 86, 120), bitmapFull_T.PixelFormat))
                {
                    G_ResultFull.DrawImage(bitmapFull_T4, 1530, 0, 86, 120);
                }
                bitmapResultWide.Dispose();
                bitmapFull_T.Dispose();
            }

            Bitmap bitmapFull_B = new Bitmap(GetFullEventName(path, GETFILENAME_TYPE.x2));

            if (bitmapFull_B.Width != 512 || bitmapFull_B.Height != 512)
            {
                return ERROR_TYPE.SizeError;
            }

            using (Graphics G_ResultFull = Graphics.FromImage(bitmapResultFull))
            {
                using (Bitmap bitmapFull_B1 = bitmapFull_B.Clone(new System.Drawing.Rectangle(0, 1, 510, 120), bitmapFull_B.PixelFormat))
                {
                    G_ResultFull.DrawImage(bitmapFull_B1, 0, 840, 510, 120);
                }
                using (Bitmap bitmapFull_B2 = bitmapFull_B.Clone(new System.Drawing.Rectangle(0, 123, 510, 120), bitmapFull_B.PixelFormat))
                {
                    G_ResultFull.DrawImage(bitmapFull_B2, 510, 840, 510, 120);
                }
                using (Bitmap bitmapFull_B3 = bitmapFull_B.Clone(new System.Drawing.Rectangle(0, 245, 510, 120), bitmapFull_B.PixelFormat))
                {
                    G_ResultFull.DrawImage(bitmapFull_B3, 1020, 840, 510, 120);
                }
                using (Bitmap bitmapFull_B4 = bitmapFull_B.Clone(new System.Drawing.Rectangle(0, 367, 86, 120), bitmapFull_B.PixelFormat))
                {
                    G_ResultFull.DrawImage(bitmapFull_B4, 1530, 840, 86, 120);
                }
                bitmapFull_B.Dispose();
            }

            if (eventType == EVENT_TYPE.Full)
            {
                try
                {
                    bitmapResultFull.Save(CreateFullEventName(path, CREATEFILENAME_TYPE.EventFull), ImageFormat.Png);
                    bitmapResultFull.Dispose();
                }
                catch (Exception)
                {
                    return ERROR_TYPE.FileError;
                }
                return ERROR_TYPE.Succeed;
            }
            else
            {
                if (eventType == EVENT_TYPE.ALL)
                {
                    bitmapResultFull.Save(CreateFullEventName(path, CREATEFILENAME_TYPE.EventFull), ImageFormat.Png);
                }

                Bitmap bitmapFull_Logo1 = new Bitmap(GetFullEventName(path, GETFILENAME_TYPE.logo_01));
                //针对某些情况下只有logo1，因此对logo2存在进行判断后引用
                if (System.IO.File.Exists(GetFullEventName(path, GETFILENAME_TYPE.logo_02)))
                {
                    Bitmap bitmapFull_Logo2 = new Bitmap(GetFullEventName(path, GETFILENAME_TYPE.logo_02));
                    if (eventType == EVENT_TYPE.ALL)
                    {
                        Bitmap bitmapResultFullWithLogo2 = new Bitmap(1616, 960);
                        using (Graphics G_ResultFull = Graphics.FromImage(bitmapResultFullWithLogo2))
                        {
                            G_ResultFull.DrawImage(bitmapResultFull, 0, 0, 1616, 960);
                            G_ResultFull.DrawImage(bitmapFull_Logo2, ReadLogoJson(path, 2, "x") + 168, ReadLogoJson(path, 2, "y") + 120);
                        }
                        bitmapResultFullWithLogo2.Save(CreateFullEventName(path, CREATEFILENAME_TYPE.EventFull_With_Logo2), ImageFormat.Png);
                        bitmapResultFullWithLogo2.Dispose();
                    }
                }
                //Bitmap bitmapFull_Logo2 = new Bitmap(GetFullEventName(path, GETFILENAME_TYPE.logo_02));

                using (Graphics G_ResultFull = Graphics.FromImage(bitmapResultFull))
                {
                    G_ResultFull.DrawImage(bitmapFull_Logo1, ReadLogoJson(path, 1, "x") + 168, ReadLogoJson(path, 1, "y") + 120);
                }

                if (System.IO.File.Exists(GetFullEventName(path, GETFILENAME_TYPE.logo_02)))
                {
                    if (eventType == EVENT_TYPE.ALL)
                    {
                        bitmapResultFull.Save(CreateFullEventName(path, CREATEFILENAME_TYPE.EventFull_With_Logo1), ImageFormat.Png);
                    }
                    Bitmap bitmapFull_Logo2 = new Bitmap(GetFullEventName(path, GETFILENAME_TYPE.logo_02));
                    using (Graphics G_ResultFull = Graphics.FromImage(bitmapResultFull))
                    {
                        G_ResultFull.DrawImage(bitmapFull_Logo2, ReadLogoJson(path, 2, "x") + 168, ReadLogoJson(path, 2, "y") + 120);
                    }
                    bitmapFull_Logo2.Dispose();
                }

                try
                {
                    bitmapResultFull.Save(CreateFullEventName(path, CREATEFILENAME_TYPE.EventFull_With_LogoAll), ImageFormat.Png);
                    bitmapFull_Logo1.Dispose();
                    bitmapResultFull.Dispose();
                }
                catch (Exception)
                {
                    return ERROR_TYPE.FileError;
                }
                return ERROR_TYPE.Succeed;
            }

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

            if (gashaInfoType == GASHAINFO_TYPE.New)
            {
                Bitmap bitmapLeft = new Bitmap(510, 366);
                Bitmap bitmapRight = new Bitmap(366, 140);
                Bitmap bitmapResult = new Bitmap(650, 366);

                Graphics graphics = Graphics.FromImage(bitmapLeft);
                graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 510, 366), 0, 0, 510, 366, GraphicsUnit.Pixel);

                Graphics graphics2 = Graphics.FromImage(bitmapRight);
                graphics2.DrawImage(bitmapOrigin, new Rectangle(0, 0, 366, 140), 2, 370, 366, 140, GraphicsUnit.Pixel);


                for (int i = 0; i < 510; i++)
                {
                    for (int j = 0; j < 366; j++)
                    {
                        var pixel = bitmapLeft.GetPixel(i, j);
                        bitmapResult.SetPixel(i, j, pixel);
                    }
                }

                bitmapRight.RotateFlip(RotateFlipType.Rotate270FlipNone);

                for (int i = 0; i < 140; i++)
                {
                    for (int j = 0; j < 366; j++)
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
            else
            {
                Bitmap bitmapLeft = new Bitmap(510, 324);
                Bitmap bitmapRight = new Bitmap(324, 66);
                Bitmap bitmapResult = new Bitmap(576, 324);

                Graphics graphics = Graphics.FromImage(bitmapLeft);
                graphics.DrawImage(bitmapOrigin, new Rectangle(0, 0, 510, 324), 0, 0, 510, 324, GraphicsUnit.Pixel);

                Graphics graphics2 = Graphics.FromImage(bitmapRight);
                graphics2.DrawImage(bitmapOrigin, new Rectangle(0, 0, 324, 66), 2, 444, 324, 66, GraphicsUnit.Pixel);


                for (int i = 0; i < 510; i++)
                {
                    for (int j = 0; j < 324; j++)
                    {
                        var pixel = bitmapLeft.GetPixel(i, j);
                        bitmapResult.SetPixel(i, j, pixel);
                    }
                }

                bitmapRight.RotateFlip(RotateFlipType.Rotate270FlipNone);

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

        public static string CreateFullEventName(string str , CREATEFILENAME_TYPE createFileNameType)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            if (num > 1)
                switch (createFileNameType)
                {
                    case CREATEFILENAME_TYPE.Origin:
                        strResult[num - 2] += "_Origin";
                        break;
                    case CREATEFILENAME_TYPE.EventWide:
                        strResult[num - 2] += " - EventWide";
                        break;
                    case CREATEFILENAME_TYPE.EventFull:
                        strResult[num - 2] += " - EventFull";
                        break;
                    case CREATEFILENAME_TYPE.EventFull_With_Logo1:
                        strResult[num - 2] += " - EventFull_With_Logo1";
                        break;
                    case CREATEFILENAME_TYPE.EventFull_With_Logo2:
                        strResult[num - 2] += " - EventFull_With_Logo2";
                        break;
                    case CREATEFILENAME_TYPE.EventFull_With_LogoAll:
                        strResult[num - 2] += " - EventFull_With_LogoAll";
                        break;
                }
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

        public static string GetFullEventName(string str, GETFILENAME_TYPE getFileNameType)
        {
            string[] strResult = str.Split('.');
            int num = strResult.Length;
            
            if (num > 1)
                switch (getFileNameType)
                {
                    case GETFILENAME_TYPE.x:
                        strResult[num - 2] += "_x";
                    break;
                    case GETFILENAME_TYPE.x0:
                        strResult[num - 2] += "_x0";
                    break;
                    case GETFILENAME_TYPE.x1:
                        strResult[num - 2] += "_x1";
                    break;
                    case GETFILENAME_TYPE.x2:
                        strResult[num - 2] += "_x2";
                    break;
                    case GETFILENAME_TYPE.logo_01:
                        strResult[num - 2] += "_logo_01";
                    break;
                    case GETFILENAME_TYPE.logo_02:
                        strResult[num - 2] += "_logo_02";
                    break;
                    case GETFILENAME_TYPE.logo_position:
                        strResult[num - 2] = strResult[num - 2].Substring(0, strResult[num - 2].Length - 2);
                        strResult[num - 2] += "logo_position.txt";
                    return strResult[num - 2];
                }

            StringBuilder resultStrB = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                resultStrB.Append(strResult[i]);
                if (i < num - 1)
                    resultStrB.Append(".");
            }
            return resultStrB.ToString();
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

        /// <summary>
        /// 读取LOGO位置
        /// </summary>
        public static int ReadLogoJson(string path, int logoNum, string key)
        {
            string jsonfile = GetFullEventName(path, GETFILENAME_TYPE.logo_position);//JSON文件路径

            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    int value = (int) o["list"][logoNum - 1]["position"][key];
                    return value;
                }
            }
        }
        #endregion

    }
}
