using UnityEngine;

public class Arrow : MonoBehaviour
{
    public RectTransform slotsContainer;
    public Camera uiCamera;

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
        }
        else
        {
            Debug.LogWarning("Nie znaleziono slotu pod strza³k¹!");
        }
    }
}
