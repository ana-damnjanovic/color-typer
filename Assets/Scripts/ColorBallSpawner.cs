using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallSpawner : MonoBehaviour
{
    GameObject ball;
    JsonLoader jsonLoader = new JsonLoader();
    List<ColorBallData> colorBallData;
    List<Material> materials = new List<Material>();
    Vector3 firingDirection;
    Vector3 launchOffset;
    float spawnCooldown = 2f;
    float timer;

    void Awake()
    {
        ball = Resources.Load("Prefabs/Ball") as GameObject;
        colorBallData = jsonLoader.LoadColorBallData();
        foreach (ColorBallData data in colorBallData)
        {
            string colorPath = "Materials/Ball Materials/" + data.GetColor() + "Material";
            Material material = Resources.Load(colorPath, typeof(Material)) as Material;
            materials.Add(material);
        }

        firingDirection = (Camera.main.transform.position - this.transform.position).normalized;
        launchOffset = Vector3.up * 1.75f;
        GameStateManager.Instance.SetState(gameState.RUN);
    }

    void Update()
    {
        if (GameStateManager.Instance.GetState() == gameState.RUN)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                SpawnRandomBall();
                timer = spawnCooldown;
            }
            
        }
    }

    void SpawnRandomBall()
    {
        SpawnBallByIndex(Random.Range(0, colorBallData.Count));
    }

    void SpawnBallByIndex(int index)
    {
        GameObject ballInstance = Instantiate(ball, this.transform.position + launchOffset, Quaternion.identity);
        ballInstance.GetComponent<Renderer>().material = materials[index];
        ballInstance.GetComponent<Rigidbody>().velocity = firingDirection * colorBallData[index].GetSpeed();
    }
}
