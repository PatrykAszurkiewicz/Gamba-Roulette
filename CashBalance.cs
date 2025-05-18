using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashBalance : MonoBehaviour
{
    public TMP_Text coinsText;
    public float coins = 999.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinsText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + coins;
    }
}
