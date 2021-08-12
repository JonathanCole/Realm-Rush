using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 2;

    [Tooltip("Adds amount to max hit points when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    
    int currentHealth = 0;

    Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();    
    }
    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            enemy.rewardGold();
            maxHealth += difficultyRamp;
        }
    }
}
