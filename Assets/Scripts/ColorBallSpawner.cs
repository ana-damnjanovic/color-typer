using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallSpawner : MonoBehaviour
{
    GameObject ball;
    JsonLoader jsonLoader = new JsonLoader();
    List<ColorBallData> colorBallData;
    List<Material> materials = new List<Material>();
    List<GameObject> spawnedBalls = new List<GameObject>();

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
        GameStateManager.OnGameStateChanged += HandleGameStateChange;
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

    public void DestroyFrontBall() {
        if (spawnedBalls.Count > 0)
        {
            spawnedBalls.RemoveAt(0);
        }
    }

    void SpawnRandomBall()
    {
        SpawnBallByIndex(Random.Range(0, colorBallData.Count));
    }

    void SpawnBallByIndex(int index)
    {
        GameObject ballInstance = Instantiate(ball, this.transform.position + launchOffset, Quaternion.identity);
        Renderer renderer = ballInstance.GetComponent<Renderer>();
        renderer.material = materials[index];
        ballInstance.GetComponent<Rigidbody>().velocity = firingDirection * colorBallData[index].GetSpeed();
        spawnedBalls.Add(ballInstance);
    }

    void HandleGameStateChange(gameState newState)
    {
        if (newState == gameState.GAME_OVER)
        {
            if (spawnedBalls.Count > 0)
            {
                foreach (GameObject ball in spawnedBalls)
                {
                    Destroy(ball);
                }
            }
        }
    }
}
