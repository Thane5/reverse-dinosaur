using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBrain : MonoBehaviour
{
    [SerializeField] GameObject sensorOrigin;
    [SerializeField] float sensorDistance = 0.25f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] float bigJumpHeight = 6;
    [SerializeField] float smallJumpHeight = 5;
    [SerializeField] LayerMask obstacleLayers;

    private Rigidbody2D dinoRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        dinoRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ObstacleSensor();
    }

    // This uses a CircleCast2D as a sensor to detect incoming obstacles
    private void ObstacleSensor()
    {
        RaycastHit2D sensorHit;
        string hitLayerName;

        //Make a CircleCast, and save its return value (a RaycastHit2D) as a variable
        sensorHit = Physics2D.CircleCast(sensorOrigin.transform.position, 0.25f, Vector2.right, sensorDistance, obstacleLayers);

        //Check if the circle cast returned anything, and make sure we are grounded
        if (isGrounded && sensorHit.collider != null)
        {
            isGrounded = false;
            //Now Check what layer of the object and save the layer name as a string
            hitLayerName = LayerMask.LayerToName(sensorHit.transform.gameObject.layer);

            // The RaycastHit2D always returns null, unless the hit was from the masked layer
            if (hitLayerName == "Big Obstacles")
            {
                print("Big Jump");
                dinoRigidbody.AddForce(new Vector2(0, bigJumpHeight), ForceMode2D.Impulse);
            }

            if (hitLayerName == "Small Obstacles")
            {
                print("Small Jump");
            }
        }
    }

    // Collisions with the ground, obstacles and other dinosaurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionLayerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (collisionLayerName == "Ground")
        {
            print("Collided with ground...");
            isGrounded = true;
        }

        if (collisionLayerName == "Big Obstacles" || collisionLayerName == "Small Obstacles")
        {
            print("Collided with obstacle!");
            dinoRigidbody.isKinematic = true;
            this.transform.SetParent(collision.transform);
        }

        if (collisionLayerName == "Dino")
        {
            dinoRigidbody.AddForce(new Vector2(0, smallJumpHeight), ForceMode2D.Impulse);
        }
    }
}
