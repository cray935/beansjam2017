﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

    public void GoBock(int LevelIndex)
    {
        Application.LoadLevel(LevelIndex);
    }

}

