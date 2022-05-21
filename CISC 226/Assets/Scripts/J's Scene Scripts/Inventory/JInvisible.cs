using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JInvisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Array of all GameObjects
        Object[] objects = FindObjectsOfType(typeof(GameObject));

        // Get inventory items except Needle (Add new inventory item names)
        List<GameObject> items = new List<GameObject>();
        for(int i = 0; i < objects.Length; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if(objects[i].name != "Arrow" && objects[i].name != "Final Arrow")
            {
                if (GameObject.Find("Matching Game") == null || temp.transform.root != GameObject.Find("Matching Game").transform)
                {
                    items.Add((GameObject)objects[i]);
                }
            }
        }

        // Get current scene
        Scene scene = SceneManager.GetActiveScene();

        // If current scene is Circus Scene
        if (scene.name == "Circus Scene")
        {
            // "Activate" Needle (or the gameObject the script is applied to)
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

            // "Activate" inventory items
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].GetComponent<Renderer>() != null)
                {
                    items[i].GetComponent<Renderer>().enabled = true;
                }
                if (items[i].GetComponent<BoxCollider2D>() != null)
                {
                    items[i].GetComponent<BoxCollider2D>().enabled = true;
                }
                if (items[i].name == "Main Camera")
                {
                    items[i].GetComponent<AudioListener>().enabled = true;
                    items[i].GetComponent<AudioSource>().enabled = true;
                }
            }
        }
        // If current scene is not Circus Scene
        else
        {
            // "Deactivate" Needle (or the gameObject the script is applied to)
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // "Deactivate" inventory items
            for(int i = 0; i < items.Count; i++)
            {
                Scene itemScene = items[i].scene;
                if (itemScene.name == "DontDestroyOnLoad")
                {
                    if (items[i].GetComponent<Renderer>() != null)
                    {
                        items[i].GetComponent<Renderer>().enabled = false;
                    }
                    if (items[i].GetComponent<BoxCollider2D>() != null)
                    {
                        items[i].GetComponent<BoxCollider2D>().enabled = false;
                    }
                    if (items[i].name == "Main Camera")
                    {
                        items[i].GetComponent<AudioListener>().enabled = false;
                        items[i].GetComponent<AudioSource>().enabled = false;
                    }
                }
            }
            GameObject menu = GameObject.Find("Skeleton Menu");
            if (menu != null)
            {
                menu.SetActive(false);
            }
            menu = GameObject.Find("Skeleton Menu 2");
            if (menu != null)
            {
                menu.SetActive(false);
            }
        }
    }
}
