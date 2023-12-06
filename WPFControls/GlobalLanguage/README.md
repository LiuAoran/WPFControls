# Global Language
## Description

提供一种适用于 WPF 的全球化语言方案。本 Demo 添加资源文件后使用了 Rider 的 Localization Manager 工具添加了 zh Culture，然后添加了一些示例文案资源。也可以使用 Visual Studio 添加和编辑资源文件。

## Usage

1. 创建 Strings 文件夹，在其中创建资源文件 MainWindow.resx。创建 ResourceManager 实例，传入资源文件的命名空间和资源文件名。

    ```csharp
    var LanguageManager= new ResourceManager("GlobalLanguage.Strings.MainWindow", Assembly.GetExecutingAssembly());
    ```

2. 设置语言，使用 CultureInfo 类的 CurrentCulture和CurrentUICulture 属性设置语言。

    ```csharp
    Thread.CurrentThread.CurrentUICulture = new CultureInfo(CurrentCulture);
    Thread.CurrentThread.CurrentCulture = new CultureInfo(CurrentCulture);
    ```
   
3. 使用 ResourceManager 实例的 GetString 方法获取资源文件中的文案。

    ```csharp
    LanguageManager.GetString("Title");
    ```
   也可以在 xaml 中直接使用资源文件中的文案，需要先在 xaml 中引入资源文件的命名空间。
   
    ```xaml
    xmlns:strings="clr-namespace:GlobalLanguage.Strings"
   
    <TextBlock Text="{x:Static strings:MainWindow.Title}"/>
    ```
    在 xaml 中使用静态资源的方式，需要将资源文件的自定义生成工具设置为 PublicResXFileCodeGenerator，否则会报错。
