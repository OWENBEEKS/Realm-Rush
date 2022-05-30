using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitpoints = 5;
    
    [Tooltip("Adds amount to maxHitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitpoints = 0;

    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitpoints = maxHitpoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitpoints--;

        if (currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitpoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
