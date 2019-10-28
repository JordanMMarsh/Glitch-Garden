using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            if (GetComponent<Attacker>())
            {
                FindObjectOfType<LevelController>().KillAttacker();
            }
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        var particles = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }
}
