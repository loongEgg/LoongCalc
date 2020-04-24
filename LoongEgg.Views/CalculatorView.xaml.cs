using System.Windows;
using System.Windows.Input;
using LoongEgg.ViewModels;

namespace LoongEgg.Views
{
    /// <summary>
    /// CalculatorView.xaml 的交互逻辑
    /// </summary>
    public partial class CalculatorView : Window
    {
        public CalculatorView() {
            InitializeComponent();
            // TODO: 36-3  
            //DataContext = new CalcualtorViewModelDemo();
        }

        // TODO: 23-3 窗体移动代码
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }
    }
}
