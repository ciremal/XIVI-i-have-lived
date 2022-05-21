using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelpScript : MonoBehaviour
{
    public int counter = -1;
    public bool track = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!track && gameObject.transform.position.x == 0)
        {
            gameObject.transform.GetChild(8).gameObject.SetActive(false);
            gameObject.transform.GetChild(9).gameObject.SetActive(true);
            track = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(counter);
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickPos.x, clickPos.y);
        
            // Used to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);

            if (hit.collider != null) {
                // Get item that is clicked on
                GameObject item = GameObject.Find(hit.collider.gameObject.name);
                if (item.name == "Right") {
                    if (counter < 7) {
                        gameObject.transform.GetChild(8).gameObject.SetActive(true);
                        counter = counter + 1;
                        gameObject.transform.GetChild(counter).gameObject.SetActive(true);
                        if (counter > 0) {
                            gameObject.transform.GetChild(counter - 1).gameObject.SetActive(false);
                        }
                        if (counter == 7) {
                            gameObject.transform.GetChild(9).gameObject.SetActive(false);
                        }
                    }
                }
                else if (item.name == "Left") {
                    if (counter > -1) {
                        gameObject.transform.GetChild(9).gameObject.SetActive(true);
                        counter = counter - 1;
                        gameObject.transform.GetChild(counter + 1).gameObject.SetActive(false);
                        if (counter == -1) {
                            gameObject.transform.GetChild(8).gameObject.SetActive(false);
                        }
                        else if (counter < 7) {
                            gameObject.transform.GetChild(counter).gameObject.SetActive(true);
                        }
                    }
                }
                else if (item.name == "Exit") {
                    for (int i = 0; i < 7; i++) {
                        gameObject.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    counter = -1;
                    gameObject.transform.position = new Vector2(19.8f, -11.1f);
                    track = false;
                    GameObject button = GameObject.Find("Levels Button");
                    button.GetComponent<BoxCollider2D>().enabled = true;
                    button = GameObject.Find("Help Button");
                    button.GetComponent<BoxCollider2D>().enabled = true;
                    GameObject canvas = GameObject.Find("Canvas");
                    canvas.GetComponent<Canvas>().enabled = true;
                }
            }
        }
    }
}
