using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invisible : MonoBehaviour
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
            if(objects[i].name == "Blue Block")
            {
                items.Add((GameObject)objects[i]);
            } 
            else if (objects[i].name == "Key")
            {
                items.Add((GameObject)objects[i]);
            }
            else if (objects[i].name == "Small Key")
            {
                items.Add((GameObject)objects[i]);
            }
            else if (objects[i].name == "Red Block")
            {
                items.Add((GameObject)objects[i]);
            }
            else if (objects[i].name == "Green Block")
            {
                items.Add((GameObject)objects[i]);
            }
        }

        // Get current scene
        Scene scene = SceneManager.GetActiveScene();

        // If current scene is DemoScene
        if (scene.name == "DemoScene")
        {
            // "Activate" Needle (or the gameObject the script is applied to)
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

            // "Activate" inventory items
            for(int i = 0; i < items.Count; i++)
            {
                items[i].GetComponent<Renderer>().enabled = true;
                items[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        // If current scene is not DemoScene
        else
        {
            // "Deactivate" Needle (or the gameObject the script is applied to)
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // "Deactivate" inventory items
            for(int i = 0; i < items.Count; i++)
            {
                items[i].GetComponent<Renderer>().enabled = false;
                items[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
