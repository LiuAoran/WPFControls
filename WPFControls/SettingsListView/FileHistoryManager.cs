using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SettingsListView
{
    public interface IHasFilePath
    {
        public string FilePath { get; set; }
    }

    [Serializable]
    public class FileInfo : IHasFilePath
    {
        public string FilePath { get; set; } = string.Empty;
        public string FileSize { get; set; } = string.Empty;
        public string OpenDate { get; set; } = string.Empty;
    }

    public class FileHistoryManager<THistory> : INotifyPropertyChanged where THistory : class, IHasFilePath
    {
        private ObservableCollection<THistory>? _history;

        public ObservableCollection<THistory>? History
        {
            get => _history;
            set
            {
                _history = value;
                UpdateProper(ref _history, value);
            }
        }

        public int DefaultHistoryCount { get; private set; } = int.MaxValue;
        public string DefaultFilePath { get; private set; } = string.Empty;

        private static FileHistoryManager<THistory>? _instance;
        public static FileHistoryManager<THistory> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileHistoryManager<THistory>();
                }
                return _instance;
            }
        }

        private FileHistoryManager()
        {
            History = new ObservableCollection<THistory>();
            DefaultFilePath = "History.xml";
            DefaultHistoryCount = 10;
        }

        public void AddToHistory(THistory item)
        {
            THistory? existingItem = History?.FirstOrDefault(i => i.FilePath == item.FilePath);

            if (existingItem != null)
            {
                History?.Remove(existingItem);
            }
            History?.Insert(0, item);

            if (History?.Count > DefaultHistoryCount)
            {
                History?.RemoveAt(History.Count - 1);
            }
        }

        public void SaveHistory(string filePath = "")
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = DefaultFilePath;
            }

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<THistory>));
                    serializer.Serialize(fs, History);
                }
            }
            catch (Exception)
            {
                ClearHistory();
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        public void LoadHistory(string filePath = "")
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = DefaultFilePath;
            }

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<THistory>));
                    object? obj = serializer.Deserialize(fs);
                    if (obj != null)
                    {
                        History = (ObservableCollection<THistory>)obj;
                    }
                }
            }
            catch (Exception)
            {
                ClearHistory();
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        public void ClearHistory()
        {
            History?.Clear();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void UpdateProper<T>(ref T properValue,
                            T newValue,
                            [CallerMemberName] string properName = "")
        {

            properValue = newValue;
            OnPropertyChanged(properName);

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}
