using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(0f,100f)]
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float projectileDamage = 50f;

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }        
    }
}
