using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// TODO: 23-5 增加对LoongEgg.Views和System.Windows的引用
using LoongEgg.Views;
using System.Windows;

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
            CalculatorView view = new CalculatorView();

            Application app = new Application();

            app.Run(view);
        }
    }
}
