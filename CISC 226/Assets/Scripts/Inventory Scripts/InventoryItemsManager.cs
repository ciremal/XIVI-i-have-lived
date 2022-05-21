using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemsManager : MonoBehaviour
{
    public static InventoryItemsManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        
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

        // Has this script has been run before? (i.e. detect scene change)
        if (Instance != null)
        {
            // Delete "duplicate" inventory items
            for(int i = items.Count - 1; i >= (items.Count) / 2; i--)
            {
                Destroy(items[i]);
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
    }
}
