using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingCode : MonoBehaviour
{

	[SerializeField]
	Text codeText;
	public static string codeTextValue = "";
	bool enter = false;

	// Update is called once per frame
	void Update()
	{
		codeText.text = codeTextValue;
		if (enter){
			if (codeTextValue == "69185")
			{
				VendingMachine.getLighter = true;
			}

			else if (codeTextValue == "7239")
			{
				VendingMachine.getKey = true;
			}

            else if (codeTextValue == "6233"){
                VendingMachine.getKazooKey = true;
            }

			else
			{
				codeTextValue = "";
			}
			enter = false;
		}
	}

	public void AddDigit(string digit)
	{
		if (digit != "ENTER"){
			codeTextValue += digit;
		}
		else if (digit == "ENTER"){
			enter = true;
		}
	}

}
