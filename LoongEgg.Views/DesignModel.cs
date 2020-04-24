/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/23 23:21:00
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
using LoongEgg.ViewModels;

namespace LoongEgg.Views
{

    public class DesignModel { 
        public static CalculatorViewModel Instance { get; private set; } = new CalculatorViewModel(); 
    }
}