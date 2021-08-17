using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallSpawner : MonoBehaviour
{
    GameObject ball;
    JsonLoader jsonLoader = new JsonLoader();
    List<ColorBallData> colorBallData;
    List<Material> materials = new List<Material>();

    void Awake()
    {
        ball = Resources.Load("Prefabs/Ball") as GameObject;
        colorBallData = jsonLoader.LoadColorBallData();
        foreach (ColorBallData data in colorBallData)
        {
            string colorPath = "Materials/Ball Materials/" + data.getColor() + "Material";
            Material material = Resources.Load(colorPath, typeof(Material)) as Material;
            materials.Add(material);
        }
    }

    void Update()
    {

    }

    void SpawnBallInstance(int index)
    {
        GameObject ballInstance = Instantiate(ball, this.transform.position, Quaternion.identity);
        ballInstance.GetComponent<Renderer>().material = materials[index];
    }
}
