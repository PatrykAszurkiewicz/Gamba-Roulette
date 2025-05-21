using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class CashBalance : MonoBehaviour
{
    public TMP_Text coinsText;
    public float coins = 100f;

    public TMP_InputField coinsInputField;
    private float currentCoinsValue = 0f;

    public TMP_Text redText;
    public TMP_Text blackText;
    public TMP_Text greenText;

    public float redBet = 0f;
    public float blackBet = 0f;
    public float greenBet = 0f;

    void Start()
    {
        UpdateCoinsText();
        redText.text = "";
        blackText.text = "";
        greenText.text = "";
    }

    public void UpdateCoinsText()
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
        UpdateInputCoins();
    }
    public void ChooseBetColor(string color)
    {
        ValueFromInputField();

        if (currentCoinsValue <= 0f || currentCoinsValue > coins)
        {
            Debug.Log("not enough coins");
            return;
        }
        coins = coins - currentCoinsValue;
        UpdateCoinsText();
        switch (color)
        {
            case "Red":
                redBet += currentCoinsValue;
                redText.text = redBet.ToString("0.00");
                break;

            case "Black":
                blackBet += currentCoinsValue;
                blackText.text = blackBet.ToString("0.00");
                break;

            case "Green":
                greenBet += currentCoinsValue;
                greenText.text = greenBet.ToString("0.00");
                break;

            default:
                Debug.LogWarning("Nieznany kolor zak³adu: " + color);
                break;
        }
    }


}
