using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour
{

    void Start()
    {
        Invoke("LoadFirstScene", 5f);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
