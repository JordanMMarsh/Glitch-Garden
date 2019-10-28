using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [SerializeField]
    int livesLostFromAttacker = 10;
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Start()
    {
        FindObjectOfType<LevelController>().AddAttacker();
    }

    void Update ()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
	}

    void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget){return;}
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LoseCollider>())
        {
            Debug.Log("Lose Lives");
            var playerLives = FindObjectOfType<Lives>();
            playerLives.LoseLives(livesLostFromAttacker);
            FindObjectOfType<LevelController>().KillAttacker();
            Destroy(gameObject);
        }       
    }
}
