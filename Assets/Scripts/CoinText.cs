using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text CoinTexts; 
    public static int Coin;
    // Start is called before the first frame update
    void Start()
    {
        CoinTexts = GetComponent<Text>();
        Coin = PlayerPrefs.GetInt("Coins", Coin);
    }

    // Update is called once per frame
    void Update()
    {
        CoinTexts.text = Coin.ToString();
    }
}
