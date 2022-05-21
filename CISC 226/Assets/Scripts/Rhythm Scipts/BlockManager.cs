using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager instance;
    public static bool redBlockWin = false;
    public static bool blueBlockWin = false;
    public static bool needleWin = false;

    public static bool brainWin = false;
    public static bool heartWin = false;
    public static bool dollEyeWin = false;

    public static bool torchWin = false;
    public static bool fireRingWin = false;
    public static bool wandWin = false;
    public static bool bananaWin = false;

    public static bool lighterWin = false;
    public static bool kazooKeyWin = false;
    public static bool lockedBookKeyWin = false;


    public GameObject BlockRhythm;
    public BeatScroller beatS;

    // Start is called before the first frame update
    void Start()
    {
        //redBlockRhythm = GameObject.Find("Red Block Rhythm");
    }


    public void DestroyRhythm()
    {
        BlockRhythm.SetActive(false);
        beatS.hasStarted = false;
        beatS.transform.position = new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z);
    }
}
