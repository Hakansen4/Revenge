using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static string directory = "SaveData";
    public static string FileName = "RevengeSave.txt";

    public static void Save(SaveObjects saveObject)
    {
        if (!directoryExists())
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);
        BinaryFormatter binaryF = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath());
        binaryF.Serialize(file, saveObject);
        file.Close();
    }
    public static SaveObjects Load()
    {
        if (SaveExits())
        {
            try
            {
                BinaryFormatter binaryF = new BinaryFormatter();
                FileStream file = File.Open(GetFullPath(), FileMode.Open);
                SaveObjects so = (SaveObjects)binaryF.Deserialize(file);
                file.Close();
                return so;

            }
            catch (SerializationException)
            {
                Debug.Log("Failed to load file");
            }
        }
        return null;
    }

    private static bool SaveExits()
    {
        return File.Exists(GetFullPath());
    }

    private static bool directoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }
    private static string GetFullPath()
    {
        return Application.persistentDataPath + "/" + directory + "/" + FileName;
    }
}
