using System;
using System.Collections.Generic;
using System.Text;

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
    // TODO: 32-1 完善Token的公共方法
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
            if (string.IsNullOrEmpty(token))
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

        // TODO: 32-1 转译字符串到Token
        /// <summary>
        /// 将字符串转译成<see cref="Token"/>的集合
        /// </summary>
        /// <param name="inp">待转译的字符串</param>
        /// <returns></returns>
        public static List<Token> Tokenize(string inp) {
            var ret = new List<Token>();
            var str = inp.RemoveSpace(); // 即str.Replace(" ", string.Empty);

            int i = 0;
            int cnt = str.Length;
            char c;
            StringBuilder token = new StringBuilder();
            while (i < cnt) {
                c = str[i];
                token = new StringBuilder(c.ToString()); 

                if (c.IsDigit()) { // 如果是数字
                    while (i + 1 < cnt && str[i+1].IsDigit()) {
                        token.Append(str[i + 1]);
                        i += 1;
                    }
                }else if (c.IsLetter()) { // 如果是字母
                     while (i + 1 < cnt && str[i+1].IsLetter()) {
                        token.Append(str[i + 1]);
                        i += 1;
                    }
                }else if (c.IsOperator()) {// 如果字符串或者左括号后面的第一个字符是负号 
                    if (c == '-' && (i == 0 || (i > 0 && str[i - 1].IsLeftBracket()))) {
                        while (i + 1 < cnt && str[i + 1].IsDigit()) {
                            token.Append(str[i + 1]);
                            i += 1;
                        }
                    }
                }else if( c.IsLeftBracket() || c.IsRightBracket()) {
                    // do nothing
                }
                else {
                    throw new ArgumentException($"Undefine char : {c}");
                }

                ret.Add(new Token(token.ToString()));
                i += 1;
            }

            return ret;
        }

        public override string ToString() {
            return NormalizeString;
        }
    }
}
