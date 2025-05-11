using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RouletteScroll : MonoBehaviour
{
    public RectTransform slotsContainer;

    public float scrollSpeed = 500f;
    public float slotWidth = 150f;
    public Button startButton;

    private bool isScrolling = false;
    private float distanceToScroll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartScroll()
    {
        if(isScrolling) return;

        distanceToScroll = Random.Range(3000f, 6000f);
        StartCoroutine(ScrollRoutine());
    }
    IEnumerator ScrollRoutine()
    {
        isScrolling = true;
        float scrolled = 0f;

        while(scrolled < distanceToScroll)
        {
            float delta = scrollSpeed * Time.deltaTime;
            scrolled += delta;

            slotsContainer.anchoredPosition -= new Vector2(delta, 0f);

            LoopSlotsIfNeed();

            yield return null;
        }

        isScrolling = false;
    }

    void LoopSlotsIfNeed()
    {
        float containerOffsetX = slotsContainer.anchoredPosition.x;

        for (int i = 0; i < slotsContainer.childCount; i++)
        {
            RectTransform slot = slotsContainer.GetChild(i) as RectTransform;

            float slotXInContainer = slot.anchoredPosition.x + containerOffsetX;
            float rightEdge = slotXInContainer + slotWidth / 2f;

            if (rightEdge < -slotWidth)
            {
                // znajdŸ ostatni slot
                RectTransform lastSlot = slotsContainer.GetChild(slotsContainer.childCount - 1) as RectTransform;
                float newX = lastSlot.anchoredPosition.x + slotWidth;

                slot.SetAsLastSibling();
                slot.anchoredPosition = new Vector2(newX, 0f);
            }
        }
    }


}
