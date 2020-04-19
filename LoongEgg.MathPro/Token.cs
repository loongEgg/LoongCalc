/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/19 21:42:45
 | 主要用途：Token的分部类 > 属性和构造器
 | 更改记录：
 |			 时间		版本		更改
 */
using System;

namespace LoongEgg.MathPro
{
    // TODO: 31-1 词元的基本属性， [partial]分部类
    /// <summary>
    /// 数学表达式的词元
    /// </summary>
    public partial class Token
    {
        /*-------------------------------------- Properties -------------------------------------*/
        /// <summary>
        /// 词元的类型
        /// </summary>
        public TokenType Type { get; private set; }

        /// <summary>
        /// 将原字符串全部.ToLower()
        /// </summary>
        public string NormalizeString { get; private set; }

        /// <summary>
        /// 运算的优先级
        /// </summary>
        public int Priority { get; private set; } = -1;

        /*------------------------------------- Constructors ------------------------------------*/
        /// <summary>
        /// 主构造器
        /// </summary>
        /// <param name="token"></param>
        public Token(string token) {
            this.NormalizeString = token.ToLower();
            this.Type = GetTokenType(token);
            this.Priority = GetTokenPriority(Type, NormalizeString);
        }

        public Token(char token) : this(token.ToString()) { }
    }
}
