using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("Death effect")][SerializeField]private GameObject deathFX;
    
    void OnTriggerEnter(Collider collider)
    {
        StartDeath();
        Invoke("LoadScene", 1f);
    }

    private void StartDeath()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
    }
    private void LoadScene(){
        SceneManager.LoadScene(1);
    }
}
