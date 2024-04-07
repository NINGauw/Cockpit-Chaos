using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private GameObject deathFXPrefab;
    [SerializeField]private Transform parent;
    private Collider enemyCollider;
    void Start()
    {
        enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other){
        GameObject fx = Instantiate(deathFXPrefab, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
