using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    void Start()
    {
        transform.name = "Cloud_" + Time.frameCount;
        //transform.position = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        if (transform.position.x <= -5)
        {
            Destroy(this.gameObject);
        }
    }
}
