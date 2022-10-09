using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Classes
{
    internal class IOService
    {
        private readonly string PATH;
        public IOService(string path)
        {
            PATH = path;
        }

        public BindingList<TaskList> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TaskList>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskList>>(fileText);
            }
        }

        public void SaveData(object _todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_todoDataList);
                writer.Write(output);
            }

        }
    }
}
