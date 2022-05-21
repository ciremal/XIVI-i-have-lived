using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyScript1 : MonoBehaviour
{
    public JIsInInventory other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get Mouse position in 2D
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickPos.x, clickPos.y);
        
            // Used to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);

            if (hit.collider != null) {
                // Get item that is clicked on
                GameObject item = GameObject.Find(hit.collider.gameObject.name);
                GameObject monkey = GameObject.Find("Monkey");
                if (monkey != null && item == monkey) {
                    other = gameObject.GetComponent<JIsInInventory>();
                    GameObject bananas = GameObject.Find("Bananas");
                    if (other.InInventory(bananas)) {
                        GameObject maze = GameObject.Find("Maze");
                        maze.transform.position = new Vector2(0, 0);
                        this.enabled = false;
                    } else {
                        DialogueTrigger dialogue = gameObject.GetComponent<DialogueTrigger>();
                        dialogue.TriggerDialogue();
                    }
                }
            }
        }
    }
}
