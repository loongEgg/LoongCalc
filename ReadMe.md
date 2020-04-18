# LoongCalc

## 21-项目结构
![File](Figures/file.png)
- ```LoongEgg.LoongCalc```是一个控制台程序用来启动整个项目
- ```LoongEgg.ViewModels```是一个类库，用来放ViewModel
- ```LoongEgg.ViewModels.Test```是ViewModel的单元测试项目
- ```LoongEgg.Views```用来放View，也就是各种窗体和控件
## 22-如何在VS中生成MarkDown文件
- ```MarkdownEditor Editor```需要安装这个插件
- 插入图片时名字有空格或者特殊字符可能出错

## 23-圆角无边框窗体移动、在控制台启动WPF、不显示控制台窗体
1. 窗体无边框设置
```xml
    Width="360"
    Height="500"
    AllowsTransparency="True" 允许透明后彻底无边框
    Background="#FFB4D2EC"
    WindowStartupLocation="CenterScreen" 启动后出现在屏幕中间
    WindowStyle="None" 无边框
    MouseLeftButtonDown="Window_MouseLeftButtonDown" 鼠标左键按压时的处理事件，用来移动窗口
```

2. 圆角切割
```xml
<Window.Clip>
        <RectangleGeometry
            RadiusX="30"
            RadiusY="30"
            Rect="0,0, 360, 500" />
</Window.Clip>
```

3. 窗体移动的后台代码
```c#
private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }
```

4. 增加程序集引用 
-   PresentationCore
-   PresentationFramework
-   System.Window
-   System.Window.Presentation
-   WindowsBase

5. 增加Using
```c#
using LoongEgg.Views;
using System.Windows;
```

6. 在控制台中启动WPF窗体
```c#
namespace LoongEgg.LoongCalc
{
    class Program
    {
        // TODO: 23-6 在控制台中启动WPF窗体
        [STAThread] // 不要忘了这个标注
        static void Main(string[] args) {
            CalculatorView view = new CalculatorView();

            Application app = new Application();

            app.Run(view);

        }
    }
}

```

7. 不显示控制台窗体的方法
输出类型设置为```Windows应用程序```   
![23.Console Set](Figures/23.ConsoleSet.png)

![Dinosaur](Figures/Dinosaur.png)

## 24-在程序集正确引用资源
**尽量用绝对路径**
1. 在新建的``Themes\Fonts.xaml``资源字典引用外部自定义字体  
``LoongEgg.Views``为程序集的名称  
``application``和``component``为标准用法，不要去动    
``/Assets/``为到资源的文件夹路径
```xml
<!--  使用自定义字体 #后面的字体名字请在资源管理器打开你的字体文件找到名字填进去  -->
    <FontFamily x:Key="Fonts.Icon">pack://application:,,,/LoongEgg.Views;component/Assets/#Font Awesome 5 Free Solid</FontFamily>
```
2. 将特定的图标“字”设置为静态资源 
``system:String``来源于引用的名称空间``xmlns:system="clr-namespace:System;assembly=mscorlib"``
```xml
<!--  定义一个图标“字”的静态资源  -->
    <system:String x:Key="Icons.PowerOff">&#xf011;</system:String>
```
3. 为了方便使用，应该把所有资源集合到自定义控件库的``Themes\Generic.xaml``
```xml
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="clr-namespace:LoongEgg.Views">

    <ResourceDictionary.MergedDictionaries>

        <!--  在这里组装各种资源  -->
        <ResourceDictionary Source="/LoongEgg.Views;component/Themes/Fonts.xaml" />
    </ResourceDictionary.MergedDictionaries>

</ResourceDictionary>

```
4. 在窗体引用资源
```xml
<Window
    x:Class="LoongEgg.Views.CalculatorView"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:local="clr-namespace:LoongEgg.Views"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    Title="CalculatorView"
    Width="360"
    Height="500"
    AllowsTransparency="True"
    Background="#FFB4D2EC"
    MouseLeftButtonDown="Window_MouseLeftButtonDown"
    WindowStartupLocation="CenterScreen"
    WindowStyle="None"
    mc:Ignorable="d">

    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!--  因为所有资源都被集合到Generic.xaml，所以只需要引用它  -->
                <ResourceDictionary Source="/LoongEgg.Views;component/Themes/Generic.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>

    <!--  切割圆角  -->
    <Window.Clip>
        <RectangleGeometry
            RadiusX="30"
            RadiusY="30"
            Rect="0,0, 360, 500" />
    </Window.Clip>

    <Grid>
        <!--  字体和“字”都被定义到了静态资源，更易使用  -->
        <Button
            Content="{StaticResource Icons.PowerOff}"
            FontFamily="{StaticResource Fonts.Icon}"
            FontSize="56" />
    </Grid>
</Window>

```
