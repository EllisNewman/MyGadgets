using System;
using System.Collections.Generic;
using System.Text;

namespace ImageComposer
{
    class Define
    {
    }

    /// <summary>
    /// 定义程序可选择的各项功能
    /// </summary>
    public enum FUNC_TYPE
    {
        /// <summary>
        /// 横版SSR卡面，支持长图拼接
        /// </summary>
        SSRWide,
        /// <summary>
        /// 竖版卡面，可选带框或去除边框
        /// </summary>
        SSRUpright,
        /// <summary>
        /// 活动界面，支持完整图拼接
        /// </summary>
        Event,
        /// <summary>
        /// 卡池界面，支持长图拼接
        /// </summary>
        Gasha,
        /// <summary>
        /// 卡池介绍图
        /// </summary>
        GashaInfo,
        /// <summary>
        /// 白板图
        /// </summary>
        WhiteBoard
    }

    /// <summary>
    /// 卡面拼接时的参数选项
    /// </summary>
    public enum CARD_TYPE
    {
        /// <summary>
        /// 原图
        /// </summary>
        Origin,
        /// <summary>
        /// 长图
        /// </summary>
        Wide,
        /// <summary>
        /// 两者都要
        /// </summary>
        Both
    }

    /// <summary>
    /// 竖版卡图拼接时的选项
    /// </summary>
    public enum UPRIGHT_TYPE
    {
        /// <summary>
        /// 无框
        /// </summary>
        NoFrame,
        /// <summary>
        /// 带框
        /// </summary>
        WithFrame,
        /// <summary>
        /// 两者都要
        /// </summary>
        Both
    }

    /// <summary>
    /// 活动界面图拼接时的选项
    /// </summary>
    public enum EVENT_TYPE
    {
        /// <summary>
        /// 完整大图
        /// </summary>
        Full,
        /// <summary>
        /// 完整大图(带有LOGO)
        /// </summary>
        Full_With_LogoAll,
        /// <summary>
        /// 全都要
        /// </summary>
        ALL
    }

    /// <summary>
    /// 创建文件名类型
    /// </summary>
    public enum CREATEFILENAME_TYPE
    {
        /// <summary>
        /// - Origin
        /// </summary>
        Origin,
        /// <summary>
        /// - EventWide
        /// </summary>
        EventWide,
        /// <summary>
        ///  - EventFull
        /// </summary>
        EventFull,
        /// <summary>
        ///  - EventFull_With_Logo1
        /// </summary>
        EventFull_With_Logo1,
        /// <summary>
        ///  - EventFull_With_Logo2
        /// </summary>
        EventFull_With_Logo2,
        /// <summary>
        ///  - EventFull_With_LogoAll
        /// </summary>
        EventFull_With_LogoAll,
    }

    /// <summary>
    /// 获取文件名类型
    /// </summary>
    public enum GETFILENAME_TYPE
    {
        /// <summary>
        /// _x
        /// </summary>
        x,
        /// <summary>
        /// _x0
        /// </summary>
        x0,
        /// <summary>
        /// _x1
        /// </summary>
        x1,
        /// <summary>
        /// _x2
        /// </summary>
        x2,
        /// <summary>
        /// _logo_01
        /// </summary>
        logo_01,
        /// <summary>
        /// _logo_02
        /// </summary>
        logo_02,
        /// <summary>
        /// logo_position
        /// </summary>
        logo_position
    }

    /// <summary>
    /// 卡池界面图拼接时的选项
    /// </summary>
    public enum GASHA_TYPE
    {
        /// <summary>
        /// 原图
        /// </summary>
        Origin,
        /// <summary>
        /// 长图
        /// </summary>
        Wide,
        /// <summary>
        /// 两者都要
        /// </summary>
        Both
    }

    /// <summary>
    /// 卡池信息图拼接时的选项
    /// </summary>
    public enum GASHAINFO_TYPE
    {
        /// <summary>
        /// 新版
        /// </summary>
        New,
        /// <summary>
        /// 旧版
        /// </summary>
        Old
    }

    /// <summary>
    /// 可能的错误(或成功)类型
    /// </summary>
    public enum ERROR_TYPE
    {
        /// <summary>
        /// 成功，无错误
        /// </summary>
        Succeed,
        /// <summary>
        /// 图片尺寸不匹配
        /// </summary>
        SizeError,
        /// <summary>
        /// 文件存取错误
        /// </summary>
        FileError,
        /// <summary>
        /// 未知错误
        /// </summary>
        Unknown
    }

}
