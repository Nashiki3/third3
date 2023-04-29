using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{

    private int previousSceneIndex;

    private const string PreviousSceneIndexKey = "PreviousSceneIndex";

    private void Start()
    {
        if (PlayerPrefs.HasKey(PreviousSceneIndexKey))
        {
            previousSceneIndex = PlayerPrefs.GetInt(PreviousSceneIndexKey);
        }
    }

    public void GoToShopScene()
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(PreviousSceneIndexKey, previousSceneIndex);
        SceneManager.LoadScene("ShopScene");
    }

    public void GoBackToPreviousScene()
    {
        previousSceneIndex = PlayerPrefs.GetInt(PreviousSceneIndexKey, 0);
        SceneManager.LoadScene(previousSceneIndex);
    }
}
