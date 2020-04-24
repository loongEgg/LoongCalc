using LoongEgg.LoongCore;
using LoongEgg.LoongLogger;
using System.Windows.Controls;
using System.Windows.Input;
using LoongEgg.MathSimple;

namespace LoongEgg.ViewModels
{
    /*
	| 
	| WeChat: InnerGeek
	| LoongEgg@163.com 
	|
	*/
  
    public class CalculatorViewModel: BaseViewModel
    { 
        /*------------------------------------- Properties --------------------------------------*/
        // TODO: 36-2
        public ICommand InputCommand { get; private set; }


        public string Result {
            get => _Result;
            set => SetProperty(ref _Result, value);
        }
        private string _Result;


        private ExpressionSimple _Expression;

        /*------------------------------------- Constructor -------------------------------------*/
        public CalculatorViewModel() {
            InputCommand = new DelegateCommand(Input);
            _Expression = new ExpressionSimple();
        }

        /*------------------------------------ Public Methods -----------------------------------*/
        public void Input(object input) {
            if (input is Button btn) {
                // TODO: 38-1 获取Button的Content
                string inp = btn.Content.ToString();
                Result = _Expression.Push(inp);
                Logger.WriteInfor($"Sth input {Result}...");
            }
        }
    }
}
