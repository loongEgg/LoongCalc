/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/20 18:46:30
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
using System;

namespace LoongEgg.MathPro
{

    public static class StringExtensions
    {
        /// <summary>
        /// 是操作符? +-*/^
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsOperator(this string self) => "+-*/^".Contains(self);

        // 是函数？
        public static bool IsFunction(this string self) => (!Double.TryParse(self, out double d) && !self.IsOperator());

        // 是操作数
        public static bool IsOperand(this string self) => Double.TryParse(self, out double d);
   
        /// <summary>
        /// 剔除字符串中的空格
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string RemoveSpace(this string self) => self.Replace(" ",  string.Empty);
    }
}
