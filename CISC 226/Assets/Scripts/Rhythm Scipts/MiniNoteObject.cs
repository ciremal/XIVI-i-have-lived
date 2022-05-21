using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniNoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public BlockManager manager;
    public float startHeight;
    public BeatScroller beatS;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                GetComponent<Renderer>().enabled = false;

            }
        }

        if (beatS.hasStarted == false)
        {
            GetComponent<Renderer>().enabled = true;
            transform.position = new Vector3(transform.position.x, startHeight, transform.position.z);

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            if (GetComponent<Renderer>().enabled == true)
            {
                manager.DestroyRhythm();
            }

        }

    }
}