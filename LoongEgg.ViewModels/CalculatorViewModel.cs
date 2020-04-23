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
