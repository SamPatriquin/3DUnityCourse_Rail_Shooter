using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform place;
    [SerializeField] int scoreValue = 12;
    [SerializeField] int hits = 10;

    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;

        // Is a reference to the scoreBoard class in the game
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other) {
        hits--;
        if (hits <= 1) {  
            Destroy(gameObject);
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = place;
            scoreBoard.scoreHit(scoreValue);
        }
    }
}
