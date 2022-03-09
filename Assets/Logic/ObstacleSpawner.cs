using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacleArray;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonSound;

    public int Identifier;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        GameObject newObstacle = GameObject.Instantiate(obstacleArray[Identifier], transform, false);
        newObstacle.name = obstacleArray[Identifier].gameObject.name + "_@" + Time.frameCount;
        audioSource.PlayOneShot(buttonSound);
    }
}
