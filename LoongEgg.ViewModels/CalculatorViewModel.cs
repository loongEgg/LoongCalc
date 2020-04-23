using LoongEgg.LoongCore;
using LoongEgg.LoongLogger;
using System.Windows.Input;

namespace LoongEgg.ViewModels
{
    /*
	| 
	| WeChat: InnerGeek
	| LoongEgg@163.com 
	|
	*/
    public class CalcualtorViewModelDemo : BaseViewModel
    {
        public ICommand InputCommand { get; private set; }

        public CalcualtorViewModelDemo() {
            InputCommand = new DelegateCommand(Input);
        }

        public void Input(object input) {
            Logger.WriteInfor($"sth is being input 233333333 {input}...");
        }
    }

    public class CalculatorViewModel: BaseViewModel
    { 
        /*------------------------------------- Properties --------------------------------------*/
        // TODO: 36-2
        public ICommand InputCommand { get; private set; } 

        /*------------------------------------- Constructor -------------------------------------*/
        public CalculatorViewModel() {
            InputCommand = new DelegateCommand(Input);
        }

        /*------------------------------------ Public Methods -----------------------------------*/ 
        public void Input(object input) {
            Logger.WriteInfor("Sth input ...");
        }
    }
}
