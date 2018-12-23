using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class UserData
{
    [Serializable]
    public class GameData
    {
        public int PewdieScore { get; set; }
        public int BeastMasterScore { get; set; }
        public int TrolleyScore { get; set; }

        public GameData()
        {
        }
    }

    static UserData _instance;
    public static UserData Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UserData();
            return _instance;
        }
    }

    private GameData _data;

    public UserData()
    {
        _data = new GameData();
        LoadData();
    }

    public int CurrentCharacter { get; set; }
    public int CurrentScore { get; set; }

    public int PewdieScore
    {
        get { return _data.PewdieScore; }
        set
        {
            _data.PewdieScore = value;
            SaveData();
        }
    }

    public int BeastMasterScore
    {
        get { return _data.BeastMasterScore; }
        set
        {
            _data.BeastMasterScore = value;
            SaveData();
        }
    }

    public int TrolleyScore
    {
        get { return _data.TrolleyScore; }
        set
        {
            _data.TrolleyScore = value;
            SaveData();
        }
    }

    private string DataFile
    {
        get { return Application.dataPath + "/userdata.bin"; }
    }

    private void LoadData()
    {
        if (File.Exists(DataFile))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Open(DataFile, FileMode.Open))
            {
                try
                {
                    _data = (GameData)bf.Deserialize(file);
                }
                catch
                {
                    _data = new GameData();
                }
            }
        }
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(DataFile))
        {
            bf.Serialize(file, _data);
        }
    }
}