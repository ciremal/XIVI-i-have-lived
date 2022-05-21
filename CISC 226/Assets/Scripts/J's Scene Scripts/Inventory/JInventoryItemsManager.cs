using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JInventoryItemsManager : MonoBehaviour
{
    public static JInventoryItemsManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] itemNumber = new GameObject[6];
        itemNumber[0] = GameObject.Find("Needle");
        itemNumber[1] = GameObject.Find("Blue Block");
        itemNumber[2] = GameObject.Find("Key");
        itemNumber[3] = GameObject.Find("Small Key");
        itemNumber[4] = GameObject.Find("Red Block");
        itemNumber[5] = GameObject.Find("Green Block");

        foreach (GameObject i in itemNumber){
            if (i != null) {
                i.transform.position  = new Vector2(15f, 0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        // Array of all GameObjects
        Object[] objects = FindObjectsOfType(typeof(GameObject));

        // Get inventory items except Needle (Add new inventory item names)
        List<GameObject> items = new List<GameObject>();
        for(int i = 0; i < objects.Length; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if(objects[i].name != "EventSystem" && objects[i].name != "Pause Menu" && temp.transform.root == temp.transform)
            {
                items.Add((GameObject)objects[i]);
            }
        }

        // Has this script has been run before? (i.e. detect scene change)
        if (Instance != null)
        {
            Debug.Log("Count:" + items.Count);
            // Delete "duplicate" inventory items
            for(int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].scene.name != "DontDestroyOnLoad" && items[i].name != "EventSystem")
                {
                    Destroy(items[i]);
                }
            }
            // Delete "duplicate" Needle (or the gameObject the script is applied to)
            Destroy(gameObject);
            return;
        }

        // This script has not been run before, "record" this run in case of scene change
        Instance = this;
        
        // Don't destroy inventory items when scene changes
        for(int i = 0; i < items.Count; i++)
        {
            DontDestroyOnLoad(items[i]);
        }
        // Don't destroy Needle (or the gameObject the script is applied to) when scene changes
        DontDestroyOnLoad(gameObject);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Circus Scene" && scene.name != "Circus Rhythm") {
            Destroy(Instance.gameObject);
            Debug.Log(items.Count);
            for (int i = 0; i < items.Count; i++) {
                Destroy(items[i]);
            }
        }
    }
}
