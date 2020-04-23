using LoongEgg.LoongLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    /// <summary>
    /// 逆波兰表达式
    /// </summary>
    public static partial class ReversePolishNotation
    {
        // TODO: 35-2 List to Queue, 将中缀表达式转为后缀表达式
        /// <summary>
        /// 转换为后缀表达式
        /// </summary>
        /// <param name="tokens">中缀表达式的集合</param>
        /// <returns>逆波兰表达式的转换结果</returns>
        public static Queue<Token> ConvertToPostFix(List<Token> tokens) {
            Logger.WriteInfor("Begin to Convert to Post Fix ...");

            // Stack of tokens with a type of 
            // TokenType.Function, TokenType.Operator or Bracket
            // [LAST IN FIRST OUT]
            Stack<Token> stack = new Stack<Token>();

            // [FIRST IN FIRST OUT]
            Queue<Token> queue = new Queue<Token>();

            stack.Push(new Token('('));
            tokens.Add(new Token(')'));

            tokens.ForEach(token =>
            {
                switch (token.Type) {
                    case TokenType.Function:
                        Logger.WriteDebug($"stack.Push({token})");
                        stack.Push(token);    // 将函数压入栈顶
                        break;

                    case TokenType.Operand:
                        Logger.WriteDebug($"queue.Enqueue({token})");
                        queue.Enqueue(token); // 将操作数添加到堆的结尾
                        break;

                    case TokenType.LeftBracket: // 如果是左括号入栈
                        Logger.WriteDebug($"stack.Push({token})");
                        stack.Push(token);
                        break;

                    case TokenType.Operator:
                        if (stack.Count == 0) // 如果栈中没有东西
                        {
                            Logger.WriteDebug($"stack.Push({token})");
                            stack.Push(token);// 直接把操作符压入
                        }
                        else {
                            Token last = stack.Pop(); // 把栈顶的东西弹出，并赋值给last
                            Logger.WriteDebug($"stack.Pop() > {last}");

                            if (last.Type == TokenType.LeftBracket      // 如果last是左括号
                                || last.Type == TokenType.RightBracket  // 或者右括号
                                || token.Priority >= last.Priority)     // 或者当前token的优先级大于等于上一个
                            {
                                Logger.WriteDebug($"stack.Push({token})");
                                stack.Push(last); // 把last压回栈

                                Logger.WriteDebug($"stack.Push({token})");
                                stack.Push(token);// 把当前token入栈
                            }
                            else { // 如果当前token的优先级小于上一个
                                do {
                                    Logger.WriteDebug($"queue.Enqueue({last})");
                                    queue.Enqueue(last); // 上一个放到堆尾

                                    last = stack.Pop();  // 再在栈里取一个
                                    Logger.WriteDebug($"stack.Pop() > {last}");
                                } while (token.Priority < last.Priority); // 当当前token优先级小于上一个时
                                stack.Push(last); // 优先级低的先入栈
                                Logger.WriteDebug($"stack.Push({last})");

                                stack.Push(token);
                                Logger.WriteDebug($"stack.Push({token})");
                            }
                        }
                        break;


                    case TokenType.RightBracket:
                        bool notFindLeftBracket = true;
                        do {
                            Token last = stack.Pop(); // 弹出直到找到左括号
                            Logger.WriteDebug($"stack.Pop() > {last}");

                            if (last.Type == TokenType.LeftBracket) {
                                if (stack.Count == 0) {
                                    notFindLeftBracket = false;
                                    break;
                                }
                                else {
                                    last = stack.Pop();
                                    Logger.WriteDebug($"stack.Pop() > {last}");
                                    if (last.Type == TokenType.Function) {
                                        queue.Enqueue(last);
                                        Logger.WriteDebug($"queue.Enqueue({last})");
                                    }
                                    else {
                                        stack.Push(last);
                                        Logger.WriteDebug($"stack.Push({last})");
                                    }
                                    notFindLeftBracket = false;
                                    break;
                                }
                            }
                            queue.Enqueue(last);
                            Logger.WriteDebug($"queue.Enqueue({last})");
                        } while (notFindLeftBracket);
                        break;

                    default:
                        break;
                }
            });

            Logger.WriteInfor($"Convert to Post Fix Ok ...");
            var list = queue.ToList();
            StringBuilder builder = new StringBuilder();
            list.ForEach(token => builder.Append(token.ToString() + ' '));
            Logger.WriteInfor($"Post Fix > {builder.ToString()}");

            return queue;
        }

        // TODO: 35-3 计算逆波兰后缀表达式
        /// <summary>
        /// 计算结果
        /// </summary>
        /// <param name="postFix"></param>
        /// <returns></returns>
        public static double EvaluatePostFix(Queue<Token> postFix) {
            Logger.WriteInfor("");
            Logger.WriteInfor("");
            Logger.WriteInfor("");
            Logger.WriteInfor("Begin to Evaluate Post Fix ...");
            Stack<Token> stack = new Stack<Token>();

            while (postFix.Count > 0) {
                Token last = postFix.Dequeue();
                Logger.WriteDebug($"postFix.Dequeue() > {last}");
                if (last.Type == TokenType.Operand) {
                    stack.Push(last);
                    Logger.WriteDebug($"stack.Push({last})");
                }
                else {
                    if (last.Type == TokenType.Operator) {
                        var right = stack.Pop();
                        Logger.WriteDebug($"stack.Pop() > {right}");

                        var left = stack.Pop();
                        Logger.WriteDebug($"stack.Pop() > {left}");

                        Logger.WriteDebug($"Calcualting > {left} {last} {right}");
                        var tmp = CalculateOpr(left, right, last);
                        Logger.WriteDebug($"Calcualted > {left} {last} {right} = {tmp}");

                        stack.Push(tmp);
                    }
                    else if (last.Type == TokenType.Function) {
                        var fun = stack.Pop();
                        Logger.WriteDebug($"stack.Pop() > {fun}");

                        Logger.WriteDebug($"Calcualting > {last} {fun}");
                        var tmp = CalculateFun(last, fun);

                        Logger.WriteDebug($"Calcualted > {last} {fun} = {tmp}");
                        stack.Push(tmp);
                    }
                }
            }
            Logger.WriteInfor($"Finish Evaluating Post Fix ...");

            if (double.TryParse(stack.Pop().ToString(), out double res)) {
                Logger.WriteInfor($"Result = {res}");
                return res;
            }
            else {
                throw new Exception("计算错误");
            }
        }

        private static Token CalculateOpr(Token left, Token right, Token opr) {
            if (left.Type != TokenType.Operand
                || right.Type != TokenType.Operand
                || opr.Type != TokenType.Operator)
                throw new ArgumentException($"Operating: {left} {opr} {right}???");

            return new Token(
                            CalculateOpr(
                                left.NormalizeString, 
                                right.NormalizeString, 
                                opr.NormalizeString
                            ).ToString()
                        );
        }

        private static Token CalculateFun(Token fun, Token d) {
            if (fun.Type != TokenType.Function
                || d.Type != TokenType.Operand)
                throw new ArgumentException($"Function: {fun} {d} ???");

            return new Token(
                            CalculateFun(
                                fun.NormalizeString, 
                                d.NormalizeString
                            ).ToString()
                        );
        }
    }
}
