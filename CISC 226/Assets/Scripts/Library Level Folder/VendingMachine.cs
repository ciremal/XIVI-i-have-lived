using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{

	[SerializeField]
	GameObject codePanel, vendingMachine, lighter, key, kazooKey;

	public static bool getLighter = false;
    public static bool getKey = false;
	public static bool getKazooKey = false;
	public static bool lighterActivated;
    public static bool keyActivated;
	public static bool kazooKeyActivated;


	// Use this for initialization
	void Start()
	{
		lighterActivated = false;
        keyActivated = false;
		kazooKeyActivated = false;
		codePanel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

		if (getLighter)
		{
			codePanel.SetActive(false);
			lighter = GameObject.Find("Lighter");

			if (lighter != null)
			{
				if (lighterActivated == false)
				{
					lighterActivated = true;
					lighter.transform.position = new Vector3(lighter.transform.position.x, lighter.transform.position.y - 10, lighter.transform.position.z);
				}
			}
			getLighter = false;
			VendingCode.codeTextValue = "";
		}

        else if (getKey)
        {
            codePanel.SetActive(false);
			key = GameObject.Find("Locked Book Key");

			if (key != null)
			{
				if (keyActivated == false)
				{
					keyActivated = true;
					key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y - 10, key.transform.position.z);
				}
			}
			getKey = false;
			VendingCode.codeTextValue = "";
        }

		else if (getKazooKey)
        {
            codePanel.SetActive(false);
			kazooKey = GameObject.Find("Kazoo Book Key");

			if (kazooKey != null)
			{
				if (kazooKeyActivated == false)
				{
					kazooKeyActivated = true;
					kazooKey.transform.position = new Vector3(kazooKey.transform.position.x, kazooKey.transform.position.y - 10, kazooKey.transform.position.z);
				}
			}
			getKazooKey = false;
			VendingCode.codeTextValue = "";
        }

		if (Input.GetMouseButtonDown(0))
		{
			Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 click2D = new Vector2(clickPos.x, clickPos.y);

			// Used to detect what is clicked
			RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);

			// A collider is clicked
			if (hit.collider != null)
			{
				Debug.Log(hit.collider.gameObject.name);
				if (hit.collider.gameObject.name == "Vending Machine")
				{
					codePanel.SetActive(true);
				}
			}
		}

	}
}
