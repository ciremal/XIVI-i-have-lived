using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateColliders : MonoBehaviour
{
    public bool track;
    public Object[] objects;
    public List<GameObject> items;
    public GameObject player;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        track = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Array of all GameObjects
        objects = FindObjectsOfType(typeof(GameObject));

        // Get all items with collider except pumpkins in Word Puzzle
        items = new List<GameObject>();
        foreach (Object i in objects) {
            GameObject j = GameObject.Find(i.name);
            if (j.GetComponent<BoxCollider2D>() != null) {
                if (!(j.name == "W" || j.name == "A" || j.name == "N" || j.name == "D")) {
                    items.Add(j);
                }
            }
        }
        
        GameObject word = GameObject.Find("Word Puzzle");
        if (word == null) {
            Debug.Log("On");
            GameObject torch = GameObject.Find("Torch");
            torch.GetComponent<JInvisible>().enabled = true;
            foreach (GameObject i in items) {
                i.GetComponent<BoxCollider2D>().enabled = true;
            }
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerMovement>().enabled = true;
            GameObject canvas = GameObject.Find("Canvas");
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            this.enabled = false;

        } else if (word.transform.position.y > 0 && !(track)) {
            Debug.Log("Off");
            GameObject torch = GameObject.Find("Torch");
            torch.GetComponent<JInvisible>().enabled = false;
            foreach (GameObject i in items) {
                i.GetComponent<BoxCollider2D>().enabled = false;
            }
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerMovement>().enabled = false;
            GameObject canvas = GameObject.Find("Canvas");
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            player.GetComponent<Animator>().SetBool("run", false);
            track = true;
        }
    }
}
