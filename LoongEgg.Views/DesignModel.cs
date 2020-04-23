using LoongEgg.ViewModels;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/23 22:53:50
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.Views
{

    // TODO: 37-1 创建DesignModel
    public class DesignModel : CalculatorViewModel
    {
        public static CalculatorViewModel Instance { get; private set; } = new CalculatorViewModel(); 
    }
}
