using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
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
    }
}
