using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField] float fallSpeed = 1f;
    public bool isFalling = true;
    private int collisionCounter = 0;
    private bool reachedBottom = false;

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
        //else print("Not Falling");

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print(col.gameObject.layer);

        //Layer 9 is the layer for Button Catcher
        if (col.gameObject.layer == 9)
        {
            //print("Touched Ground!");
            reachedBottom = true;
        }
        isFalling = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (reachedBottom == false)
        {
            isFalling = true;
        }
    }

    void ClickSignal()
    {
        Global.ButtonCounter--;
        Destroy(this.gameObject);
    }
}
