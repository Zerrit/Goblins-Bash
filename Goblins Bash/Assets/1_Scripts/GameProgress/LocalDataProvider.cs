using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace _1_Scripts.GameProgress
{
    public class LocalDataProvider : IDataProvider
    {
        private const string FileName = "PlayerSave";
        private const string SaveFileExtension = "json";

        private IPersistentData _persistantData;


        public LocalDataProvider(IPersistentData persistentData) => _persistantData = persistentData;

        private string SavePath => Application.persistentDataPath;
        private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtension}");

        public bool TryLoad()
        {
            if (!IsDataAlreadyExist()) return false;
   
            _persistantData.Progress = JsonConvert.DeserializeObject<PlayerProgress>(File.ReadAllText(FullPath));
            return true;
        }

        public void Save()
        {
            File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistantData.Progress, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        private bool IsDataAlreadyExist() => File.Exists(FullPath);
    }
}