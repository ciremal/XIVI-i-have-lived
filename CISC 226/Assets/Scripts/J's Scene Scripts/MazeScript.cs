using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x == 0) {
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
                    GameObject maze = GameObject.Find("Maze");
                    if (item == maze) {
                        StartCoroutine(Correct(maze));
                    } else if (item.name != "Resume") {
                        StartCoroutine(Incorrect());
                    }
                }
            }
        }
    }

    IEnumerator Incorrect()
    {
        gameObject.transform.GetChild(4).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
    }

    IEnumerator Correct(GameObject maze)
    {
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        maze.SetActive(false);
    }
}
