using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreScoreNoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        if (GoldKazoo.haveGoldKazoo == false)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.ExtraScoreNoteHit();
            }
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
                GameManager.instance.ExtraScoreNoteMissed();
            }
        }

    }
}