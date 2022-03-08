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
        GameObject newButton = GameObject.Instantiate(obstacleArray[Identifier], transform, false);
        audioSource.PlayOneShot(buttonSound);
    }
}
