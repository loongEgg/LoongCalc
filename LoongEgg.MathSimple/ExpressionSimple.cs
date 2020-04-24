/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/24 20:38:54
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
using LoongEgg.Contract;

namespace LoongEgg.MathSimple
{
    // TODO: 38-3 新建一个ExpressionSimple类来处理简单的计算
    public class ExpressionSimple : IExpression
    {
        /*---------------------------------------- Fields ---------------------------------------*/

        /*-------------------------------------- Properties -------------------------------------*/
        public string Left { get; private set; } = "";
        public string Right { get; private set; } = "";
        public string Operator { get; private set; } = "";

        /*-------------------------------- Dependency Properties --------------------------------*/

        /*------------------------------------- Constructors ------------------------------------*/

        /*------------------------------------ Public Methods -----------------------------------*/
         public string Push(string inp) {
            if(inp == "=") {
                if( Left != "" && Right != "") {
                    var tmp ="";
                    switch (Operator) {
                        case "+": tmp = (double.Parse(Left) + double.Parse(Right)).ToString(); break;
                        case "-": tmp =  (double.Parse(Left) - double.Parse(Right)).ToString();break;
                        case "*": tmp =  (double.Parse(Left) * double.Parse(Right)).ToString();break;
                        case "/": tmp =  (double.Parse(Left) / double.Parse(Right)).ToString();break;
                        default: tmp =  "";break;
                    }
                    Left = "";
                    Right = "";
                    Operator = "";
                    return tmp;
                }
            }

            if (inp.IsOperator()) {
                if(Left == "") {

                }
                else {
                    Operator = inp;
                }
            }else if (inp.IsOperand()) { 

                if(Operator != "") {
                    Right += inp;
                }
                else {
                    Left += inp;
                }
            }
            return Left + Operator + Right;
        }
        /*------------------------------------ Private Method -----------------------------------*/
    }
}
