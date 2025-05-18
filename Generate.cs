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

        //left side
        for (int i = centerIndex - 1; i >= 0; i--)
        {
            slotSequence.Insert(0, (i % 2 == 0) ? ColorType.Black : ColorType.Red);
        }

        // Green mid
        slotSequence.Insert(centerIndex, ColorType.Green);

        //right side
        for (int i = 0; i < centerIndex; i++)
        {
            slotSequence.Add((i % 2 == 0) ? ColorType.Red : ColorType.Black);
        }
    }

    void ShowSlots()
    {
        float slotWidth = 150f;
        float currentX = 0f;

        foreach (ColorType color in slotSequence)
        {
            GameObject prefab = null;

            switch (color) //choose right prefab
            {
                case ColorType.Red: prefab = redPrefab; break;
                case ColorType.Green: prefab = greenPrefab; break;
                case ColorType.Black: prefab = blackPrefab; break;
            }

            GameObject slot = Instantiate(prefab, slotsContainer);
            RectTransform rt = slot.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(currentX, 0);
            currentX += slotWidth;
        }
        //move contener to left to make green on mid
        int centerIndex = totalSlots / 2;
        float offsetToCenter = -centerIndex * slotWidth;
        slotsContainer.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetToCenter, 0);//-1050x
    }
}
