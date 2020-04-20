using System;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/20 22:16:29
 | 主要用途：逆波兰表达式的分部类 > 核心数学
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.MathPro
{
    // TODO: 33-数学运算和函数运算的核心方法
    public partial class ReversePolishNotation
    {
        /*------------------------------------ Private Method -----------------------------------*/
        private static double CalculateOpr(string left, string right, string opr)
            => CalculateOpr(Convert.ToDouble(left), Convert.ToDouble(right), opr);

        private static double CalculateOpr(double left, double right, string opr) {
            switch (opr) {
                case "+": return left + right;
                case "-": return left - right;
                case "*": return left * right;
                case "/": return left / right;
                case "^": return Math.Pow(left, right);

                default: throw new  NotImplementedException(opr);
            }
        }

        private static double CalculateFun(string fun, string d)
            => CalculateFun(fun, Convert.ToDouble(d));

        const double Deg2Rad = Math.PI / 180.0;
        private static double CalculateFun(string fun, double d) {
            switch (fun) {
                case "cos": return Math.Cos(d * Deg2Rad);
                case "sin": return Math.Cos(d * Deg2Rad);
                case "sqr": return d * d;
                case "sqrt": return Math.Sqrt(d);

                default: throw new NotImplementedException(fun);
            }
        }
    }
}
