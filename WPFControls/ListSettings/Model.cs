using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsListView
{
    [Serializable]
    public class FileInfo
    {
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileDate { get; set; }
        public string OpenDate { get; set; }
        public FileInfo() { }

    }

    [Serializable]
    internal class EmployeeList
    {
        private ArrayList _employees = null;

        public EmployeeList()
        {
            _employees = new ArrayList();
        }

        public System.Collections.IEnumerator Employees
        {
            get
            {
                return _employees.GetEnumerator();
            }
        }

        public void AddEmployee(int id, string name)
        {
            _employees.Add(new DictionaryEntry(id, name));
        }

        public void RemoveEmployee(int id, string name)
        {
            DictionaryEntry de = new DictionaryEntry(id, name);
            if (_employees.Contains(de))
            {
                _employees.Remove(de);
            }
        }

        public void ClearAllEmployees()
        {
            _employees.Clear();
        }

        public int EmployeesCount
        {
            get
            {
                return _employees.Count;
            }
        }
    }
}
