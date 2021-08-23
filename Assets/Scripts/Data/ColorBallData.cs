using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorBallDataWrapper
{
    public List<ColorBallData> dataset;
}

[System.Serializable]
public class ColorBallData
{
    [SerializeField]
    string color = "Red";
    [SerializeField]
    string shape = "Heart";
    [SerializeField]
    float initialSpeed = 5.0f;

    public string GetColor()
    {
        return color;
    }

    public string GetShape()
    {
        return shape;
    }

    public float GetInitialSpeed()
    {
        return initialSpeed;
    }
}

public class ColorBall
{
    string color;
    float speed;
    Material material;
    Texture texture;

    public ColorBall(string color, float speed, Material material, Texture texture)
    {
        this.color = color;
        this.speed = speed;
        this.material = material;
        this.texture = texture;
    }

    public string GetColor()
    {
        return color;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public Material GetMaterial()
    {
        return material;
    }

    public Texture GetTexture()
    {
        return texture;
    }
}
