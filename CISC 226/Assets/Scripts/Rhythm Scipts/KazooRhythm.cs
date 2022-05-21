using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KazooRhythm : MonoBehaviour
{
    public GameObject goldKazoo;
    public GameObject coldKazoo;
    public GameObject safetyKazoo;

    // Update is called once per frame
    void Update()
    {
        goldKazoo = GameObject.Find("Gold Kazoo");
        coldKazoo = GameObject.Find("Cold Kazoo");
        safetyKazoo = GameObject.Find("Safety Kazoo");
        if (GoldKazoo.haveGoldKazoo == true)
        {
            goldKazoo.GetComponent<Renderer>().enabled = true;
        } else
        {
            goldKazoo.GetComponent<Renderer>().enabled = false;
        }

        if (ColdKazoo.haveColdKazoo == true)
        {
            coldKazoo.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            coldKazoo.GetComponent<Renderer>().enabled = false;
        }
        if (SafetyKazoo.haveSafetyKazoo == true)
            {
                safetyKazoo.GetComponent<Renderer>().enabled = true;
            }
        else
            {
                safetyKazoo.GetComponent<Renderer>().enabled = false;
            }
    }
}
