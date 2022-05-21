using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealFaceItems : MonoBehaviour
{
    public GameObject[] faceObject;
    public GameObject balloon;
    // Start is called before the first frame update
    void Start()
    {
        // Array of items on "face" (MUST have collider component)
        faceObject = new GameObject[4];
        faceObject[0] = GameObject.Find("Eyes");
        faceObject[1] = GameObject.Find("Hat");
        faceObject[2] = GameObject.Find("Nose And Mouth");
        faceObject[3] = GameObject.Find("Hair");
        for (int i = 0; i < faceObject.Length; i++)
        {
            faceObject[i].transform.Translate(0,12,0);
        }

        // Find balloon to trigger face puzzle
        balloon = GameObject.Find("Balloon");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!(balloon.activeInHierarchy))
        {
            for (int i = 0; i < faceObject.Length; i++)
            {
                faceObject[i].transform.Translate(0,-12,0);
                this.enabled = false;
            }

        }
        
    }
}
