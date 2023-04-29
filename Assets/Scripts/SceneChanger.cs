using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    void Start()
    {

        Invoke("LoadScene", 5.2f);


    }

    void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
