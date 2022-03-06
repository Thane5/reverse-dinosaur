using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] float fallSpeed = 1f;
    public bool isFalling = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFalling)
        {
            this.transform.Translate(Vector2.down * fallSpeed / 100);
        }

    }

    void OnCollisionEnter2D()
    {
        //print("lol");
    }

    void OnTriggerEnter2D()
    {
        print("Triggered");
        isFalling = false;
    }
}
