using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField] float fallSpeed = 1f;
    public bool isFalling = true;
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
        //Make sure the Button has not yet reached the bottom && that the Exit has been triggered by the top collider of another button
        if (reachedBottom == false && col.gameObject.layer == LayerMask.NameToLayer("Button Top"))
        {
            isFalling = true;
        }
    }

    //This is a "SendMessage" from the button component
    void ClickSignal()
    {
        // Remove this button from the Singelton button counter
        Global.ButtonCounter--;
        // And commit sudoku
        Destroy(this.gameObject);
    }
}
