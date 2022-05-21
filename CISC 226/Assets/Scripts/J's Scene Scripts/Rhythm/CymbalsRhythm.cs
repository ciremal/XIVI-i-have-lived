using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CymbalsRhythm : MonoBehaviour
{
    public GameObject cymbals;

    // Update is called once per frame
    void Update()
    {
        cymbals = GameObject.Find("Cymbals");
        if (CymbalScript.hasCymbal == true)
        {
            cymbals.GetComponent<Renderer>().enabled = true;
        } else
        {
            cymbals.GetComponent<Renderer>().enabled = false;
        }

    }
}
