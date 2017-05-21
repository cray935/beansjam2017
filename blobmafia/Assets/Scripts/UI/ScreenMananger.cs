using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMananger : MonoBehaviour {

    static ScreenMananger Instance;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Application.LoadLevel("Level3Start");
        }
    }
		
	}

