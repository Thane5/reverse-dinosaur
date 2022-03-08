using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] buttonArray;
    [SerializeField] float minWaitTime = 0.3f;
    [SerializeField] float maxWaitTime = 3f;

    //This reference will be injected into new instances so that they can communicate
    [SerializeField] ObstacleSpawner obsSpawner;
    float waitTime;
    bool isWaiting = false;


    // Start is called before the first frame update
    void Start()
    {
        Global.ButtonCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting && Global.ButtonCounter < 5)
        {
            SpawnButton();
        }
    }

    void SpawnButton()
    {
        int pickElement = Random.Range(0, 5);
        GameObject newButton = GameObject.Instantiate(buttonArray[pickElement], transform, false);
        // Inject the reference to the obstacle spawner into the new object
        newButton.GetComponent<ItemButton>().ObsSpawner = obsSpawner;
        newButton.GetComponent<ItemButton>().Identifier = pickElement;
        StartCoroutine("SpawnTimer");
        Global.ButtonCounter++;
    }

    IEnumerator SpawnTimer()
    {
        isWaiting = true;
        waitTime = Random.Range(minWaitTime, maxWaitTime);
        //print("Start waiting for " + waitTime);

        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        //print("Spawned cloud after waiting after " + waitTime);
    }


}
