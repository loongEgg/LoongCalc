using System;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/19 21:46:58
 | 主要用途：Token的分部类 > 公共静态方法
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.MathPro
{
    
    public partial class Token
    { 
        /*------------------------------------ Public Methods -----------------------------------*/
        // TODO: 31-2 类型判断
        /// <summary>
        /// 获取Token的类型
        /// </summary> 
        public static TokenType GetTokenType(char c) {
            if (c.IsDigit()) {
                if (c == '.') throw new ArgumentException("<.>不能独立成为操作数");
                return TokenType.Operand;
            }
            else if (c.IsOperator()) {
                return TokenType.Operator;
            }
            else if (c.IsLeftBracket()) {
                return TokenType.LeftBracket;
            }else if (c.IsRightBracket()) {
                return TokenType.RightBracket;
            }
            else {
                throw new ArgumentException($"{c} 不合适的TokenType");
            }
        }

        /// <summary>
        /// 获取Token的类型
        /// </summary> 
        public static TokenType GetTokenType(string token) {
            if (token == null)
                throw new ArgumentNullException("token");

            // 一个字符长度
            if (token.Length == 1) {
                return GetTokenType(token[0]);
            }
            else {
                // 操作数
                if(double.TryParse(token, out double d)) {
                    return TokenType.Operand;
                }
                else { // 函数
                    return TokenType.Function;
                }
            }
        }
          
        // TODO: 31-3 优先级
        /// <summary>
        /// token的运算级别
        /// </summary>
        /// <param name="type">token的类型</param>
        /// <param name="token">ToLower后的token字符串</param>
        /// <returns>运算级数字别大的优先</returns>
        public static int GetTokenPriority(TokenType type, string token) {

            int priority = -1;

            switch (type) {
                case TokenType.Operator: {
                        if ("+-".Contains(token))
                            priority = 1;
                        else if ("*/".Contains(token))
                            priority = 2;
                        else if (token == "^")
                            priority = 3;
                        else
                            throw new Exception($"Unknow math operator: {token}");
                    }
                    break;

                case TokenType.Function:
                    priority = 4;
                    break;

                case TokenType.Operand: 
                case TokenType.LeftBracket: 
                case TokenType.RightBracket:
                    priority = -1;
                    break;
            }

            return priority;
        }
    }
}
