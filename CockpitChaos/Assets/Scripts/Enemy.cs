using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private GameObject deathFXPrefab;
    [SerializeField]private Transform parent;
    [SerializeField]private int scorePoint;
    [SerializeField]private int healthPoint;
    const int HelthPointPerHit = 10;
    private Collider enemyCollider;
    private ScoreBoard scoreBoard;
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        healthPoint-=HelthPointPerHit;
        if(healthPoint <= 0){
           KillEnemy(); 
        }
        
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFXPrefab, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        scoreBoard.ScoreHit(scorePoint);
    }
}
