using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataLoader
{
    public List<ColorBall> LoadColorBalls()
    {
        List<ColorBall> colorBalls = new List<ColorBall>();
        TextAsset json = Resources.Load<TextAsset>("Data/BallData");
        ColorBallDataWrapper dataWrapper = JsonUtility.FromJson<ColorBallDataWrapper>(json.text);
        foreach (ColorBallData data in dataWrapper.dataset)
        {
            string colorPath = "Materials/Ball Materials/" + data.GetColor() + "Material";
            Material material = Resources.Load(colorPath, typeof(Material)) as Material;
            ColorBall colorBall = new ColorBall(data.GetColor(), data.GetInitialSpeed(), material);
            colorBalls.Add(colorBall);
        }
        return colorBalls;
    }

    public ScoreData LoadHighScore()
    {
        ScoreData highScore;
        string filePath = Application.persistentDataPath + "/highScore.json";
        if (File.Exists(filePath))
        {
            string fileContents = File.ReadAllText(filePath);
            highScore = JsonUtility.FromJson<ScoreData>(fileContents);
        }
        else
        {
            ScoreData newScoreData = new ScoreData();
            newScoreData.highScore = 0;
            highScore = newScoreData;
        }
        return highScore;
    }

    public void SaveHighScore(ScoreData highScore)
    {
        string jsonString = JsonUtility.ToJson(highScore);
        string filePath = Application.persistentDataPath + "/highScore.json";
        File.WriteAllText(filePath, jsonString);
    }
}
