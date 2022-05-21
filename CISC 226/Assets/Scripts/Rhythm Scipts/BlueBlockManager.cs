using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlockManager : MonoBehaviour
{
    public static BlueBlockManager instance;
    public static bool blueBlockWin = false;
    public GameObject blueBlockRhythm;
    public BeatScroller beatS;

    // Start is called before the first frame update
    void Start()
    {
        blueBlockRhythm = GameObject.Find("Blue Block Rhythm");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DestroyRhythm()
    {
        blueBlockRhythm.SetActive(false);
        beatS.hasStarted = false;
        beatS.transform.position = new Vector3(2f, 4f, 0f);
    }
}

