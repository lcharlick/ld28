﻿using System.Collections;
using Annotations;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public SpawnPointManager SpawnManager;

    public void Detonate()
    {
        this.GetComponent<Animator>().SetTrigger("Exploding");
        this.transform.parent = null;

        // Don't spawn any more enemies
        this.SpawnManager.enabled = false;
    }

    // Called by animation event
    [UsedImplicitly] private void DetonationFinished()
    {
        Object.Destroy(this.gameObject);
    }

    [UsedImplicitly] private void OnTriggerEnter2D(Collider2D other)
    {
        var enemyScript = other.GetComponent<Enemy>();
        enemyScript.Destroy(other.transform.position - this.transform.position);
    }
}