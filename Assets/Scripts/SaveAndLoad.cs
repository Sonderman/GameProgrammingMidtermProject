using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



public static class SaveLoadManager 
{


    public static void SavePlayerPosition(float xPosition, float yPosition)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData gamedata = new GameData(xPosition,yPosition);
        formatter.Serialize(stream, gamedata);
        stream.Close();
    }
    public static GameData LoadPlayerPosition()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData gamedata =  formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gamedata;
        }
        else
        {
            Debug.LogError("Save File Not Found!! in:"+path);
            return null;
        }
    }


    public static void SaveBallState(Ball ball)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ball.data";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData gamedata = new GameData(ball);
        formatter.Serialize(stream, gamedata);
        stream.Close();
    }
    public static GameData LoadBallState()
    {
        string path = Application.persistentDataPath + "/ball.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData gamedata = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gamedata;
        }
        else
        {
            Debug.LogError("Save File Not Found!! in:" + path);
            return null;
        }
    }




    public static void SaveScores(int score, int highScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Score.data";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData gamedata = new GameData(score,highScore);
        formatter.Serialize(stream, gamedata);
        stream.Close();
    }

    public static GameData LoadScores()
    {
        string path = Application.persistentDataPath + "/Score.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData gamedata = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gamedata;
        }
        else
        {
            Debug.LogError("Save File Not Found!! in:" + path);
            return null;
        }
    }
}
