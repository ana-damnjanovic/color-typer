using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColorBall
{
    [SerializeField]
    string color { get; } = "Red";
    [SerializeField]
    float velocity { get; set; } = 5.0f;

    public ColorBall CreateFromJson(string json)
    {
        return JsonUtility.FromJson<ColorBall>(json);
    }
}
