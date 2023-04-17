using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DarkMode.Managers
{
    class ThemeManager
    {
        public static void SetTheme(bool isDark)
        {
            string uri = isDark ? "Themes/DarkModeDictionary.xaml" : "Themes/LightModeDictionary.xaml";
            ResourceDictionary newDict = new ResourceDictionary();
            newDict.Source = new Uri(uri, UriKind.Relative);

            // 从应用程序资源中获取所有已经合并的资源字典
            var dictionaries = Application.Current.Resources.MergedDictionaries;

            // 移除旧的字典
            var oldDict = dictionaries.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("ModeDictionary.xaml"));
            if (oldDict != null)
            {
                dictionaries.Remove(oldDict);
            }

            // 添加新的字典
            dictionaries.Add(newDict);

            // 刷新UI以使更改生效
            Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    window.Dispatcher.Invoke(() => { }, System.Windows.Threading.DispatcherPriority.Background);
                }
            });
        }

    }
}
