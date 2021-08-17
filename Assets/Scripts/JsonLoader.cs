using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoader
{
    public List<ColorBallData> LoadColorBallData()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/BallData");
        ColorBallDataWrapper dataWrapper = JsonUtility.FromJson<ColorBallDataWrapper>(json.text);
        return dataWrapper.dataset;
    }
}
