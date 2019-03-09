using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnCooldown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnCooldown)
        {
            Instantiate(spawnObject, transform);
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }
}
