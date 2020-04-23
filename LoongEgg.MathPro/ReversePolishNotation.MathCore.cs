/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/20 22:16:29
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
using LoongEgg.LoongLogger;
using System;

namespace LoongEgg.MathPro
{
    // TODO: 33-数学运算和函数运算的核心方法
    public static partial class ReversePolishNotation
    {
        /// <summary>
        /// 普通计算
        /// </summary>
        /// <param name="left">左侧操作数</param>
        /// <param name="right">右侧操作数</param>
        /// <param name="opr">操作符</param>
        /// <returns>计算结果</returns>
        private static double CalculateOpr(string left, string right, string opr)
            => CalculateOpr(Convert.ToDouble(left), Convert.ToDouble(right), opr);

        /// <summary>
        /// 普通计算
        /// </summary>
        /// <param name="left">左侧操作数</param>
        /// <param name="right">右侧操作数</param>
        /// <param name="opr">操作符</param>
        /// <returns>计算结果</returns>
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

        /// <summary>
        /// 函数运算
        /// </summary>
        /// <param name="fun">函数名称</param>
        /// <param name="d">操作数</param>
        /// <returns></returns>
        private static double CalculateFun(string fun, string d) {
            if (string.IsNullOrEmpty(fun) || string.IsNullOrEmpty(d) ) {
                Logger.WriteFatal($"{fun} {d}");
            }

           return CalculateFun(fun, Convert.ToDouble(d));
        }

        const double Deg2Rad = Math.PI / 180.0;

        /// <summary>
        /// 函数运算, [注意]角的大小以角度记， 不是弧度
        /// </summary>
        /// <param name="fun"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double CalculateFun(string fun, double d) {
            Logger.WriteDebug($"{fun} {d}");

            switch (fun) {
                case "cos": return Math.Cos(d * Deg2Rad);
                case "sin": return Math.Sin(d * Deg2Rad);
                case "sqr": return d * d;
                case "sqrt": return Math.Sqrt(d);

                default: {
                        Logger.WriteFatal(fun + "???");
                        throw new NotImplementedException(fun);
                    }
            }
        }
    }
}
