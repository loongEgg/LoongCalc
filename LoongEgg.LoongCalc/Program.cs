using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// TODO: 23-5 增加对LoongEgg.Views和System.Windows的引用
using LoongEgg.Views;
using System.Windows;
using LoongEgg.LoongLogger;

// TODO: 23-4 增加程序集引用
//            PresentationCore
//            PresentationFramework
//            System.Window
//            System.Window.Presentation
//            WindowsBase

namespace LoongEgg.LoongCalc
{

    class Program
    {
        // TODO: 23-6 在控制台中启动WPF窗体
        [STAThread]// 不要忘了这个标注
        static void Main(string[] args) {

            // TODO: 34-值类型、引用类型和ref的大坑
            // 值类型  ：int double float bool
            // 引用类型：剩下的大多数
            Logger.Enable(LoggerType.Debug | LoggerType.Console | LoggerType.File, LoggerLevel.Debug);

            int a = 9;
            int b = a;
            b = 2333;
            Logger.WriteInfor($"a={a}");
            Logger.WriteInfor($"b={b}");

            int[] C = new int[] { 6, 9, 10 };
            int[] D = C;
            D[2] = 233;
            Logger.WriteError($"C[2]={C[2]}");
            Logger.WriteError($"D[2]={D[2]}");

            Person p1 = new Person { Name = "小门", Age = 3 };
            Person p2 = p1;
            p2.Age = 18;

            Logger.WriteFatal($"p1.Age={p1.Age}");
            Logger.WriteFatal($"p2.Age={p2.Age}");

            a = 9999;
            Logger.WriteDebug($"a={a}");
            ChangeSth(ref a);
            Logger.WriteDebug($"a={a}");
            
            Logger.Disable();
            Console.ReadKey();
        }

        static void ChangeSth(ref int i) {
            i = 2333333;
        }

        class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

        

        static void AppRun() {
            CalculatorView view = new CalculatorView();

            Application app = new Application();

            app.Run(view);
        }
    }
}
