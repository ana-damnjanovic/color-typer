using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoader
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
}
