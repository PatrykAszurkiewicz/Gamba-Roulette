using UnityEngine;

public class Arrow : MonoBehaviour
{
    public RectTransform slotsContainer;
    public Camera uiCamera;

    CashBalance cb;

    void Start()
    {
        cb = FindObjectOfType<CashBalance>();
    }
    public void CheckWinner()
    {
        Vector3 arrowScreenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, transform.position);
        float minDistance = float.MaxValue;
        RectTransform winningSlot = null;

        for (int i = 0; i < slotsContainer.childCount; i++)
        {
            RectTransform slot = slotsContainer.GetChild(i) as RectTransform;
            Vector3 slotScreenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, slot.position);

            float distance = Mathf.Abs(slotScreenPos.x - arrowScreenPos.x);
            if (distance < minDistance)
            {
                minDistance = distance;
                winningSlot = slot;
            }
        }

        if (winningSlot != null)
        {
            Debug.Log("Winning slot: " + winningSlot.name);

            switch(winningSlot.name)
            {
                case "Black(Clone)":
                    cb.coins = cb.coins + (cb.blackBet * 2);
                    ClearBets();
                    break;
                case "Red(Clone)":
                    cb.coins = cb.coins + (cb.redBet * 2);
                    ClearBets();
                    break;
                case "Green(Clone)":
                    cb.coins = cb.coins + (cb.greenBet * 14);
                    ClearBets();
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Nie znaleziono slotu pod strza³k¹!");
        }
    }
    public void ClearBets()
    {
        cb.redBet = 0f;
        cb.redText.text = "";
        cb.blackBet = 0f;
        cb.blackText.text = "";
        cb.greenBet = 0f;
        cb.greenText.text = "";
        cb.UpdateCoinsText();
    }
}
