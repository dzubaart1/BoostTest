using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Data
{
    public class JsonStorage
    {
        private string _jsonPath;
        private string _scorePath;
        
        private static JsonStorage _singleton;
        public static JsonStorage Instance()
        {
            return _singleton ??= new JsonStorage();
        }
        
        public JsonStorage()
        {
            _jsonPath = Application.streamingAssetsPath + $"{Path.DirectorySeparatorChar}data";

            if (!Directory.Exists(_jsonPath))
            {
                Directory.CreateDirectory(_jsonPath);
            }
            
            _scorePath = $"{_jsonPath}{Path.DirectorySeparatorChar}score.json";

            var scoreFile = new FileInfo(_scorePath);
            if (!scoreFile.Exists)
            {
                using var fs = scoreFile.Create();
            }
            Debug.Log("Path " + _scorePath);
        }

        public void Save(float score)
        {
            string json = JsonUtility.ToJson(new ScoreSaved()
            {
                Score = score
            });
            JsonSave(json, _scorePath);
        }

        public float GetScore()
        {
            using var sr = new StreamReader(_scorePath, Encoding.UTF8);
            var score = JsonUtility.FromJson<ScoreSaved>(sr.ReadToEnd());
            Debug.Log("Load " + score.Score);
            return score.Score;
        }
        
        private void JsonSave(string json, string path)
        {
            using var streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(json);
            streamWriter.Close();
        }
    }

    public struct ScoreSaved
    {
        public float Score;
    }
}