using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        // Left Mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Get Mouse position in 2D
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickPos.x, clickPos.y);
        
            // Used to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);
        
            // A collider is clicked
            if (hit.collider != null)
            {
                // Get item that is clicked on
                GameObject item = GameObject.Find(hit.collider.gameObject.name);
                if (item.name == "Levels Button") {
                    SceneManager.LoadScene("Levels Scene");
                } else if (item.name == "Help Button") {
                    GameObject button = GameObject.Find("Levels Button");
                    button.GetComponent<BoxCollider2D>().enabled = false;
                    button = GameObject.Find("Help Button");
                    button.GetComponent<BoxCollider2D>().enabled = false;
                    GameObject canvas = GameObject.Find("Canvas");
                    canvas.GetComponent<Canvas>().enabled = false;
                    GameObject tutorial = GameObject.Find("Help Scene");
                    tutorial.transform.position = new Vector2(0f, 0f);
                }
            }
        }
    }
}
