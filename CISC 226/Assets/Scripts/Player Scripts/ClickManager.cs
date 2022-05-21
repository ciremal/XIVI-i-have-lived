using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Transform player;
    public PlayerMovement p;
    [SerializeField] public float dist;
    [SerializeField] public float speed;
    float moveAccuracy = 0.15f;

    public void GoToItem(ItemData item){
        if (Mathf.Abs(player.position.x - item.goToPoint.position.x) < dist){
            StartCoroutine(MoveToPoint(item.goToPoint.position));
        }
    }

    public void setMenuActive(GameObject obj)
    { 
        if (obj.activeSelf == false){
                obj.SetActive(true);
         }
    }

    public void setMenuActiveDist(GameObject obj)
    { 
        if (Mathf.Abs(player.position.x + obj.transform.position.x) < dist || (player.position.x - obj.transform.position.x) < dist) {
            if (Mathf.Abs(player.position.y - obj.transform.position.y) < dist){
                if (obj.activeSelf == false){
                    obj.SetActive(true);
                }
            }
        }
    }

    public void setMenuInactiveDist(GameObject obj)
    {
        if (Mathf.Abs(player.position.x - obj.transform.position.x) < dist) {
            if (obj.activeSelf == true)
            {
                obj.SetActive(false);
            }
        }
    }

    public void setMenuInactive(GameObject obj)
    {
        if (obj.activeSelf == true)
        {
            obj.SetActive(false);
        }
    }

    public void setInvisible(GameObject obj)
    {
        obj.GetComponent<Renderer>().enabled = false;
    }

    public void setVisible(GameObject obj)
    {
        obj.GetComponent<Renderer>().enabled = true;

    }

    public void setCollidable(GameObject obj)
    {
        obj.GetComponent<Collider>().enabled = true;
    }

    public void setUncollidable(GameObject obj)
    {
        obj.GetComponent<Collider>().enabled = false;

    }


    public IEnumerator MoveToPoint(Vector2 point){
        Vector2 positionDifference = point - (Vector2)player.position;
        while(positionDifference.magnitude > moveAccuracy){
            player.Translate(speed * positionDifference.normalized * Time.deltaTime);
            p.anim.SetBool("run", true);
            positionDifference = point - (Vector2)player.position;
            yield return null;
        }
        player.position = point;
        yield return null;
    }
}
