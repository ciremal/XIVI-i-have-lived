using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                if (item.name == "Theatre Button")
                {
                    SceneManager.LoadScene("DemoScene");
                } else if (item.name == "Doll House Button") {
                    SceneManager.LoadScene("Dollhouse Scene");
                } else if (item.name == "Circus Button") {
                    SceneManager.LoadScene("Circus Scene");
                } else if (item.name == "Library Button") {
                    SceneManager.LoadScene("Library Level");
                } else if (item.name == "Quit Button") {
                    SceneManager.LoadScene("Menu");
                }
            }
        }

        if (GameManager.circusCompleted) 
        {
            GameObject circus = GameObject.Find("Circus Button");
            circus.GetComponent<BoxCollider2D>().enabled = false;
            circus.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManager.theatreCompleted) 
        {
            GameObject theatre = GameObject.Find("Theatre Button");
            theatre.GetComponent<BoxCollider2D>().enabled = false;
            theatre.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManager.dollHouseCompleted) 
        {
            GameObject dollHouse = GameObject.Find("Doll House Button");
            dollHouse.GetComponent<BoxCollider2D>().enabled = false;
            dollHouse.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManager.libraryCompleted) 
        {
            GameObject library = GameObject.Find("Library Button");
            library.GetComponent<BoxCollider2D>().enabled = false;
            library.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManager.circusCompleted && GameManager.theatreCompleted && GameManager.dollHouseCompleted && GameManager.libraryCompleted)
        {
            GameObject canvas = GameObject.Find("Canvas");
            canvas.transform.GetChild(5).gameObject.SetActive(true);
        }
    }
}
