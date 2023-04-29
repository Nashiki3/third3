using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeStart : MonoBehaviour
{
    public void Go()
    {
        SceneManager.LoadScene(1);
    }
}
