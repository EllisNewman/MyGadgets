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
