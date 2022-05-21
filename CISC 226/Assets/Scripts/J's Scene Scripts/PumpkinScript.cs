using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScript : MonoBehaviour
{
    public int counter = 0;
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
                GameObject skeleton = GameObject.Find("Skeleton");
                if (item.name == "W Pumpkin") {
                    item.SetActive(false);
                    skeleton.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    counter++;
                } else if (item.name == "N Pumpkin") {
                    item.SetActive(false);
                    skeleton.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    counter++;
                } else if (item.name == "D Pumpkin") {
                    item.SetActive(false);
                    skeleton.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                    counter++;
                } else if (item.name == "A Pumpkin") {
                    item.SetActive(false);
                    skeleton.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                    counter++;
                }
                if (counter == 4) {
                    StartCoroutine(Puzzle(skeleton));
                }
            }
        }        
    }
    IEnumerator Puzzle(GameObject skeleton) 
    {
        yield return new WaitForSeconds(1f);
        GameObject word = GameObject.Find("Word Puzzle");
        word.transform.position = new Vector2(1.267148f, 0.642014f);
        skeleton.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        skeleton.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        skeleton.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        skeleton.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
        this.enabled = false;
    }
}
