using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour {


    public void GoCredit(int LevelIndex)
    {
        Application.LoadLevel(LevelIndex);
    }


}
