using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloudPrefab;
    [SerializeField] float minWaitTime = 0.3f;
    [SerializeField] float maxWaitTime = 3f;
    [SerializeField] float minYOffset = -1f;
    [SerializeField] float maxYOffset = 1f;


    float waitTime;
    bool isWaiting = false;
    Vector2 spawnerPos;

    private void SpawnCloud()
    {
        spawnerPos = transform.position;
        print(spawnerPos);
        GameObject newCloud = GameObject.Instantiate(cloudPrefab, transform, false);
        newCloud.name = "Cloud_" + Time.frameCount;
        newCloud.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(minYOffset, maxYOffset));
        StartCoroutine("SpawnTimer");
    }

    // The Coroutine thing
    IEnumerator SpawnTimer()
    {
        isWaiting = true;
        waitTime = Random.Range(minWaitTime, maxWaitTime);
        //print("Start waiting for " + waitTime);

        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        //print("Spawned cloud after waiting after " + waitTime);
    }

    void Update()
    {
        if (isWaiting)
        {
            //Do nothing, thats what waiting means!
        }
        else
        {
            SpawnCloud();
        }
    }
}
