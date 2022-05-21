using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeClownFace : MonoBehaviour
{
    public GameObject[] faceObject;
    public GameObject[] setFace;
    private int complete;
    public GameObject blue;
    public static bool havePowerUp = false;
    public Transform player;
    public PlayerMovement p;
    [SerializeField] public float dist;
    [SerializeField] public float speed;
    [SerializeField] public float pickUpDelay;
    float moveAccuracy = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        // Face is empty, set to zero
        complete = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get Mouse position in 2D
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickPos.x, clickPos.y);

            // Used to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);

            // A collider is clicked
            if (hit.collider != null)
            {
                // Array of items on "face" (MUST have collider component)
                faceObject = new GameObject[4];
                faceObject[0] = GameObject.Find("Eyes");
                faceObject[1] = GameObject.Find("Hat");
                faceObject[2] = GameObject.Find("Nose And Mouth");
                faceObject[3] = GameObject.Find("Hair");

                // Find face
                GameObject face = GameObject.Find("Head");

                // Array of items to be set on face
                setFace = new GameObject[4];
                setFace[0] = face.transform.Find("Placed Eyes").gameObject;
                setFace[1] = face.transform.Find("Placed Hat").gameObject;
                setFace[2] = face.transform.Find("Placed Nose And Mouth").gameObject;
                setFace[3] = face.transform.Find("Placed Hair").gameObject;


                // Get item that is clicked on
                GameObject item = GameObject.Find(hit.collider.gameObject.name);

                // Used to track face item number
                int num = -1;

                //Checks distance between player and face item
                //If distance is in range, perform the following actions
                if (Mathf.Abs(player.position.x - item.transform.position.x) < dist){

                    // Check if item can be on face
                    for (int i = 0; i < faceObject.Length; i++)
                    {
                        if (item == faceObject[i]) 
                        {
                            {
                                StartCoroutine(MoveToPoint(item.transform.position));
                                num = i;
                            } 
                        }
                    }
                }

                // Apply item to face
                if (num >= 0)
                {
                    faceObject[num].SetActive(false);
                    setFace[num].SetActive(true);
                    complete++;
                }

                // Find Blue Block
                blue = GameObject.Find("Blue Block");

                // Check if face is complete and show Blue Block
                if (complete == faceObject.Length)
                {
                    blue.transform.position = new Vector3(3.1f, -0.7f, 0f);
                    this.GetComponent<MakeClownFace>().enabled = false;
                }
            }
        }
    }
    public IEnumerator MoveToPoint(Vector2 point)
    {
        Vector2 positionDifference = point - (Vector2)player.position;
        while(positionDifference.magnitude > moveAccuracy)
        {
            player.Translate(speed * positionDifference.normalized * Time.deltaTime);
            p.anim.SetBool("run", true);
            positionDifference = point - (Vector2)player.position;
            yield return null;
        }
        player.position = point;
        yield return null;
    }
}
