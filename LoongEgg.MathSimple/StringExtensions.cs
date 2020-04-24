using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoongEgg.MathSimple
{
	/*
	| 
	| WeChat: InnerGeek
	| LoongEgg@163.com 
	|
	*/
    // TODO: 38-2用扩展方法获取输入的类型
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
    }
}
