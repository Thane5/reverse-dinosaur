using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }
}
