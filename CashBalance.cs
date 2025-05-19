using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashBalance : MonoBehaviour
{
    public TMP_Text coinsText;
    public float coins = 999.5f;

    public TMP_InputField coinsInputField;


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
        coinsText.text = "Coins: " + coins.ToString("0.00");
    }
    public void BetButton()
    {
        float value;
        if (float.TryParse(coinsInputField.text, out value))
        {
            if (value <= coins)
            {
                coins = coins - value;
                UpdateCoinsText();
            }
            else
            {
                Debug.Log("za ma³o coins");
            }
        }
        
    }

}
