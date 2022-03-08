using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pterodactylus : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    private float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        yOffset = Random.Range(0f, 0.5f);
        transform.localPosition = new Vector2(0, yOffset);
        //GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }
}
