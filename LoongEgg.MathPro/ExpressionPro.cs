using LoongEgg.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/24 22:08:14
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.MathPro
{

    public class ExpressionPro : IExpression
    {
        private List<Token> Tokens = new List<Token>();

        public Token Last {
            get { return Tokens[Tokens.Count - 1]; }
            set { Tokens[Tokens.Count - 1] = value; }
        } 

        public string Push(string inp) {
            if (inp == "=") {
                if (Tokens.Any()) {
                    var post = ReversePolishNotation.ConvertToPostFix(Tokens);
                    var res = ReversePolishNotation.EvaluatePostFix(post);
                    Tokens = new List<Token>();
                    return res.ToString();
                }
            }

            if(Tokens.Count == 0) {
                Tokens.Add(new Token(inp));
            }
            else {
                if (Last.Type == TokenType.Operand && inp.IsOperand())
                    Last = new Token(Last.NormalizeString + inp);
                else
                    Tokens.Add(new Token(inp));
            }

            StringBuilder build = new StringBuilder();
            Tokens.ForEach(t => build.Append(t.NormalizeString + " "));
            return build.ToString();

        }
    }


     
}
