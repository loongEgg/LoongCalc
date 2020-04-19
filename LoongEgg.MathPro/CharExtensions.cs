using System.Linq;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/19 20:21:51
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.MathPro
{
    // TODO: 30-1 字符的扩展方法-类型判断
    /// <summary>
    /// 字符的扩展方法
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// 是操作符? +-*/^
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsOperator(this char self) => "+-*/^".Contains(self);

        /// <summary>
        /// 是操作数？ 0~9或.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsDigit(this char self) => ".0123456789".Contains(self);

        /// <summary>
        /// 是字母？
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsLetter(this char self) => (self >= 'a' && self <= 'z') || (self >= 'A' && self <= 'Z');

        /// <summary>
        /// 是左括号？
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsLeftBracket(this char self) => '(' == self;

        /// <summary>
        /// 是右括号？
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsRightBracket(this char self) => ')' == self;
    }
}
