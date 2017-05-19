using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour {

    public void GoGame(int LevelIndex)
    {
        Application.LoadLevel(LevelIndex);
    }


}
