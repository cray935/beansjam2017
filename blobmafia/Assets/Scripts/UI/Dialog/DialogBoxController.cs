using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour
{
	public GameObject dialogBox;
	public Text txtComponent;
	public TextAsset textFile;

	private string[] textLines;
	private int currentLine;
	private int lastLine;

	// Use this for initialization
	void Start ()
	{
		loadText ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentLine > lastLine) {
			return;
		}

		txtComponent.text = textLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Return)) {
			currentLine++;
		}

		if (currentLine > lastLine) {
			dialogBox.SetActive (false);
		}
	}

	private void loadText ()
	{
		if (textFile != null) {
			textLines = textFile.text.Split ('\n');
			currentLine = 0;
			lastLine = textLines.Length - 1;
		}

		dialogBox.SetActive (true);
	}
}
