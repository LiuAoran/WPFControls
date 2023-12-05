using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GlobalLanguage.Properties;

namespace GlobalLanguage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ResourceManager LanguageManager= new ResourceManager("GlobalLanguage.Strings.MainWindow", Assembly.GetExecutingAssembly());
        
        public static string CurrentCulture = Settings.Default.Culture;
        public static List<string> SupportedCultureList= new List<string>()
        {
            "en-US", "zh-CN"
        };
        
        protected override void OnStartup(StartupEventArgs e)
        {
            SetUpLanguage();
        }
        
        private void SetUpLanguage()
        {
            if (string.IsNullOrEmpty(CurrentCulture))
            {
                CurrentCulture = CultureInfo.CurrentCulture.Name;
                if (!SupportedCultureList.Contains(CurrentCulture))
                {
                    CurrentCulture = "en-US";
                }
                Settings.Default.Culture = CurrentCulture;
                Settings.Default.Save();
            }
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CurrentCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CurrentCulture);
        }
    }
}