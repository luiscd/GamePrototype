using GamePrototype.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace GamePrototype.Engine
{
    public class ConfigurationFileReader
    {
        public static List<BaseEntity> Entities = new List<BaseEntity>();
        public static List<Objects.Object> Objects = new List<Objects.Object>();
        private string path;

        private const string entitiesFile = "entities.json";
        private const string objectsFile = "objects.json";
        
        public ConfigurationFileReader()
        {
            path = Directory.GetCurrentDirectory();
        }

        public List<BaseEntity> LoadEntities()
        {
            Entities = JsonConvert.DeserializeObject<List<BaseEntity>>(ReadFromFile(entitiesFile));
            return Entities;    
        }

        public List<Objects.Object> LoadObjects()
        {
            Objects = JsonConvert.DeserializeObject<List<Objects.Object>>(ReadFromFile(objectsFile));
            return Objects;
        }
        
        public string ReadFromFile(string file)
        {
            string jsonData = string.Empty;

            try
            {
                var filePath = Path.Combine(path, file);
                jsonData = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }

            return jsonData;
        }

    }
}
