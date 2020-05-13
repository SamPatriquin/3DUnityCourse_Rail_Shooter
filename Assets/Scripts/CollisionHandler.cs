using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Only script that is loading scenes so it's ok

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelResetDelay = 2f;
    [SerializeField] GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        proccessDeath();
    }


    // Update is called once per frame
    void Update()
    {
    
    }
    private void proccessDeath() {
        SendMessage("onPlayerDeath"); //Calls function in other scripts within the game object
        deathEffect.SetActive(true);
        Invoke("resetLevel", levelResetDelay);
    }

    private void resetLevel() {
        SceneManager.LoadScene(1);
    }
}
