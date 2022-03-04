using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBrain : MonoBehaviour
{
    [SerializeField] bool isGrounded = true;
    [SerializeField] float SensorDistance = 0.25f;
    [SerializeField] float JumpHeight = 6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ObstacleSensor();
    }

    private void ObstacleSensor()
    {

    }
}
