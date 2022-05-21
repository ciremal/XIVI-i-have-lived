using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlockManager : MonoBehaviour
{
    public static RedBlockManager instance;
    public static bool redBlockWin = false;
    public GameObject redBlockRhythm;
    public BeatScroller beatS;

    // Start is called before the first frame update
    void Start()
    {
        redBlockRhythm = GameObject.Find("Red Block Rhythm");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DestroyRhythm()
    {
        redBlockRhythm.SetActive(false);
        beatS.hasStarted = false;
        beatS.transform.position = new Vector3(-6f, 4f, 0f);
    }
}
