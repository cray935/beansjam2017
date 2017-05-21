using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour
{
	public GameObject dialogBox;
	public Text txtComponent;
	public TextAsset textFile;
	public float typeSpeedSec;

	private string[] textLines;
	private int currentLine;
	private int lastLine;

	private bool active;
	private bool typing;
	private bool cancelTyping;

	void Start ()
	{
		disableDialogBox ();
		loadText ();
	}

	void Update ()
	{
		if (!active) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.Return)) {

			if (!typing) {

				currentLine++;

				if (currentLine > lastLine) {
					disableDialogBox ();
				} else {
					StartCoroutine (typeText (textLines [currentLine]));
				}

			} else if (typing && !cancelTyping) {
				cancelTyping = true;
			}

			if (currentLine > lastLine) {
				disableDialogBox ();
			}
		}
	}

	public void enableDialogBox ()
	{
		dialogBox.gameObject.SetActive (true);
		this.active = true;

		StartCoroutine (typeText (textLines [currentLine]));
	}

	public void disableDialogBox ()
	{
		dialogBox.gameObject.SetActive (false);
		this.active = false;
	}

	private void loadText ()
	{
		if (textFile != null) {
			textLines = textFile.text.Split ('\n');
			currentLine = 0;
			lastLine = textLines.Length - 1;
		}
	}

	private IEnumerator typeText (string text)
	{
		int letter = 0;
		txtComponent.text = "";
		typing = true;
		cancelTyping = false;

		while (typing && !cancelTyping && (letter < text.Length - 1)) {
			txtComponent.text += text [letter++];
			yield return new WaitForSeconds (typeSpeedSec);
		}

		txtComponent.text = text;
		typing = false;
		cancelTyping = false;
	}
}
