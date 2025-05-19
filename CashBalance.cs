using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class CashBalance : MonoBehaviour
{
    public TMP_Text coinsText;
    public float coins = 999.5f;

    public TMP_InputField coinsInputField;
    private float currentCoinsValue = 0f;


    void Start()
    {
        UpdateCoinsText();
    }

    void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + coins.ToString("0.00");
    }
    void UpdateInputCoins()
    {
        coinsInputField.text = currentCoinsValue.ToString("0.00");
    }

    public void ValueFromInputField()
    {
        if (float.TryParse(coinsInputField.text, out float value))
        {
            currentCoinsValue = value;
        }
    }

    public void BetButton()
    {
        ValueFromInputField();
        if (currentCoinsValue <= coins)
        {
            Debug.Log(currentCoinsValue);
            coins = coins - currentCoinsValue;
            UpdateCoinsText();
        }
        else
        {
            Debug.Log(coins);
            Debug.Log("za ma³o coins");
        }
        
    }
    public void Betx2()
    {
        ValueFromInputField();
        currentCoinsValue *= 2;
        UpdateInputCoins();
    }
    public void BetHalf()
    {
        ValueFromInputField();
        currentCoinsValue /= 2;
    }

}
