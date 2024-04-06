using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        StartDeath();
    }

    private void StartDeath()
    {
        print("collision something");
        SendMessage("OnPlayerDeath");
    }
}
