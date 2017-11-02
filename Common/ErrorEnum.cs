
using System.ComponentModel;

namespace Common
{
    public enum ErrorEnum
    {
        /// <summary>
        /// 缺少必要的参数
        /// </summary>
        [Description("缺少必要的参数")]
        E1,
        /// <summary>
        /// 链接异常,请稍后再试
        /// </summary>
        [Description("链接异常,请稍后再试")]
        E2,
        /// <summary>
        /// 请求成功,但未取得预期的成果
        /// </summary>
        [Description("请求成功,但未取得预期的成果")]
        E3,
        /// <summary>
        /// Miss Cookie
        /// </summary>
        [Description("Miss Cookie")]
        E4,
        /// <summary>
        /// Error Token
        /// </summary>
        [Description("Error Token")]
        E5,
        /// <summary>
        /// 账号名称或者密码错误
        /// </summary>
        [Description("账号名称或者密码错误")]
        E6,
        /// <summary>
        /// 已存在的用户名
        /// </summary>
        [Description("已存在的用户名")]
        E7,
        /// <summary>
        /// 当前表结构缺少PrimaryKey
        /// </summary>
        [Description("当前表结构缺少PrimaryKey")]
        E1000,
        /// <summary>
        /// 当前操作必须传入条件限制
        /// </summary>
        [Description("当前操作必须传入条件限制")]
        E1001,
        /// <summary>
        /// 当前操作必须传入UPDATE字段和值
        /// </summary>
        [Description("当前操作必须传入UPDATE字段和值")]
        E1002,
        /// <summary>
        /// 当您尝试 JOIN 时,请先设置 Alia 值
        /// </summary>
        [Description("当您尝试 JOIN 时,请先设置 Alia 值")]
        E1003
    }
}
