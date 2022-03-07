using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] buttonArray;
    [SerializeField] float minWaitTime = 0.3f;
    [SerializeField] float maxWaitTime = 3f;
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
        int pickElement = Random.Range(0, 4);
        GameObject newButton = GameObject.Instantiate(buttonArray[pickElement], transform, false);
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
