using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallManager : MonoBehaviour
{
    GameObject ball;
    List<GameObject> ballInstances = new List<GameObject>();
    List<ColorBall> possibleColorBalls = new List<ColorBall>();
    List<ColorBall> spawnedColorBalls = new List<ColorBall>();

    Vector3 firingDirection;
    Vector3 launchOffset;

    float spawnCooldown = 2f;
    float timer = 0f;

    private static ColorBallManager instance;
    public static ColorBallManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        ball = Resources.Load("Prefabs/Ball") as GameObject;
        JsonLoader loader = new JsonLoader();
        possibleColorBalls = loader.LoadColorBalls();
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

    public ColorBall GetFrontBall()
    {
        if (spawnedColorBalls.Count > 0)
        {
            return spawnedColorBalls[0];
        }
        return null;
    }

    public void DestroyFrontBall() {
        if (ballInstances.Count > 0 && spawnedColorBalls.Count > 0)
        {
            Destroy(ballInstances[0]);
            ballInstances.RemoveAt(0);
            spawnedColorBalls.RemoveAt(0);
        }
    }

    public List<ColorBall> GetPossibleColorBalls()
    {
        return new List<ColorBall>(possibleColorBalls);
    }

    void SpawnRandomBall()
    {
        int index = Random.Range(0, possibleColorBalls.Count);
        GameObject ballInstance = Instantiate(ball, this.transform.position + launchOffset, Quaternion.identity);
        Renderer renderer = ballInstance.GetComponent<Renderer>();
        renderer.material = possibleColorBalls[index].GetMaterial();
        ballInstance.GetComponent<Rigidbody>().velocity = firingDirection * possibleColorBalls[index].GetSpeed();
        ballInstances.Add(ballInstance);
        spawnedColorBalls.Add(possibleColorBalls[index]);
    }

    void HandleGameStateChange(gameState newState)
    {
        if (newState == gameState.GAME_OVER)
        {
            if (ballInstances.Count > 0)
            {
                foreach (GameObject ball in ballInstances)
                {
                    Destroy(ball);
                }
            }
        }
    }
}
