using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFinalNoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public BlockManager manager;
    public float startHeight;
    public BeatScroller beatS;
    public string block;

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
                if (block == "red")
                {
                    BlockManager.redBlockWin = true;
                }
                if (block == "blue")
                {
                    BlockManager.blueBlockWin = true;
                }
                if (block == "needle")
                {
                    BlockManager.needleWin = true;
                }
                if (block == "heart")
                {
                    BlockManager.heartWin = true;
                }
                if (block == "brain")
                {
                    BlockManager.brainWin = true;
                }
                if (block == "dolleye")
                {
                    BlockManager.dollEyeWin = true;
                }
                if (block == "torch")
                {
                    BlockManager.torchWin = true;
                }
                if (block == "fireRing")
                {
                    BlockManager.fireRingWin = true;
                }
                if (block == "wand")
                {
                    BlockManager.wandWin = true;
                }
                if (block == "banana")
                {
                    BlockManager.bananaWin = true;
                }
                if (block == "kazoo")
                {
                    BlockManager.kazooKeyWin = true;
                }
                if (block == "lighter")
                {
                    BlockManager.lighterWin = true;
                }
                if (block == "locked book key")
                {
                    BlockManager.lockedBookKeyWin = true;
                }
                manager.DestroyRhythm();
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

            if (gameObject.active)
            {
                manager.DestroyRhythm();
            }

        }

    }
}