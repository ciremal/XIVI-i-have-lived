using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LibrarySceneSwitcher : MonoBehaviour
{
    public LibraryIsInInventory inventory;
    public GameObject specialBook;

    public void goToRhythm()
    {
        specialBook = GameObject.Find("Special Book");
        if (inventory.InInventory(specialBook)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
