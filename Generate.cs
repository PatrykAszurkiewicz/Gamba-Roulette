using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject redPrefab;
    public GameObject greenPrefab;
    public GameObject blackPrefab;

    public Transform slotsContainer;

    public int totalSlots = 15; //odd amount so green is in middle 

    private List<ColorType> slotSequence = new();

    public enum ColorType
    {
        Red,
        Green,
        Black
    }

    void Start()
    {
        GenerateSlots();
        ShowSlots();
    }

    void GenerateSlots()
    {
        int centerIndex = totalSlots / 2;

        // Lewa strona (w odwrotnej kolejnoœci bo idziemy w lewo)
        for (int i = centerIndex - 1; i >= 0; i--)
        {
            slotSequence.Insert(0, (i % 2 == 0) ? ColorType.Black : ColorType.Red);
        }

        // Green na œrodku
        slotSequence.Insert(centerIndex, ColorType.Green);

        // Prawa strona
        for (int i = 0; i < centerIndex; i++)
        {
            slotSequence.Add((i % 2 == 0) ? ColorType.Red : ColorType.Black);
        }
    }

    void ShowSlots()
    {
        float slotWidth = 150f;
        float currentX = 0f;

        foreach (Transform child in slotsContainer)
            Destroy(child.gameObject);

        foreach (ColorType color in slotSequence)
        {
            GameObject prefab = null;
            switch (color)
            {
                case ColorType.Red: prefab = redPrefab; break;
                case ColorType.Green: prefab = greenPrefab; break;
                case ColorType.Black: prefab = blackPrefab; break;
            }
            GameObject slot = Instantiate(prefab, slotsContainer);
            RectTransform rt = slot.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(currentX, 0);
            currentX += slotWidth; //100 bylo
        }
        int centerIndex = totalSlots / 2;
        float offsetToCenter = -centerIndex * slotWidth;
        slotsContainer.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetToCenter, 0);
    }
}
