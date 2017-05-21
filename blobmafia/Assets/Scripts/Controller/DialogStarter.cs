using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : MonoBehaviour
{
	public DialogBoxController dialogController;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "GohstWall")
			dialogController.enableDialogBox ();
	}
}
