using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpNoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        if (SafetyKazoo.haveSafetyKazoo == false)
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
                //gameObject.SetActive(false);
                gameObject.GetComponent<Renderer>().enabled = false;

                PowerUpNoteHit();
            }
        }
    }

    public IEnumerator PowerUpNoteHit()
    {
        Debug.Log("Hit Power Up ");
        GameManager.instance.noScoreLoss = true;
        yield return new WaitForSeconds(2f);
        GameManager.instance.noScoreLoss = false;
        Debug.Log("Hit Power Time's Up ");
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
            //StartCoroutine(GameManager.instance.PowerUpNoteHit());
            StartCoroutine(PowerUpNoteHit());

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

        }

    }
}
