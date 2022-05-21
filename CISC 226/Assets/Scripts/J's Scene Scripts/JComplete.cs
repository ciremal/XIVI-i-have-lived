using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JComplete : MonoBehaviour
{
    public SceneSwitcher sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.circusCompleted) {
            GameObject torch = GameObject.Find("Torch");
            torch.GetComponent<JInvisible>().enabled = true;
            Object[] objects = FindObjectsOfType(typeof(GameObject), true);
            for(int i = 0; i < objects.Length; i++)
            {
                GameObject temp = (GameObject)objects[i];
                if (temp.scene.name == "DontDestroyOnLoad" && temp.transform.root == temp.transform)
                {
                    SceneManager.MoveGameObjectToScene(temp, SceneManager.GetActiveScene());
                }
            }
            SceneManager.LoadScene("Levels Scene");
        }
    }
}
