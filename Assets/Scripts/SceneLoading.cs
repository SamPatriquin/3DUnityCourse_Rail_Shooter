﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Invoke("LoadFirstScene", 5f);
    }

    void LoadFirstScene() {
        SceneManager.LoadScene(1);
    }
}
