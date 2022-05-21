using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSafe : MonoBehaviour
{

	[SerializeField]
	GameObject codePanel, closedSafe, openedSafe, brain;

	public static bool isSafeOpened = false;
	public static bool brainActivated;


	// Use this for initialization
	void Start()
	{
		brainActivated = false;
		codePanel.SetActive(false);
		closedSafe.SetActive(true);
		openedSafe.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

		if (isSafeOpened)
		{
			codePanel.SetActive(false);
			closedSafe.SetActive(false);
			openedSafe.SetActive(true);
			brain = GameObject.Find("Brain");

			if (brain != null)
			{
				if (brainActivated == false)
				{
					brainActivated = true;
					brain.transform.position = new Vector3(brain.transform.position.x, brain.transform.position.y - 6, brain.transform.position.z);
				}
			}
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
				if (hit.collider.gameObject.name == "Closed Safe")
				{
					codePanel.SetActive(true);
				}
			}
		}

	}

}
