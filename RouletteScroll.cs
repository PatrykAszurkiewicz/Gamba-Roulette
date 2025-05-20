using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RouletteScroll : MonoBehaviour
{
    public RectTransform slotsContainer;
    public float minScrollSpeed = 500f;
    public float maxScrollSpeed = 1000f;
    
    public float slotWidth = 150f;
    public Button startButton;

    private bool isScrolling = false;
    //private float distanceToScroll;

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

        //tutaj logika obstawianka
        StartCoroutine(ScrollRoutine());
    }
    IEnumerator ScrollRoutine()
    {
        
        isScrolling = true;

        float duration = Random.Range(3f, 5f); // total scrolling time
        float accelTime = Random.Range(0.5f, 1f);
        float decelTime = Random.Range(1f, 2f);
        float elapsed = 0f;

        float scrollSpeed = Random.Range(minScrollSpeed, maxScrollSpeed);
        float maxSpeed = scrollSpeed; //max speed
        float currentSpeed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed;

            // Faza przyspieszenia
            if (t < accelTime)
            {
                float a = t / accelTime;
                currentSpeed = Mathf.Lerp(0f, maxSpeed, EaseOutCubic(a));
            }
            // Faza zwolnienia
            else if (t > duration - decelTime)
            {
                float d = (t - (duration - decelTime)) / decelTime;
                currentSpeed = Mathf.Lerp(maxSpeed, 0f, EaseInCubic(d));
            }
            // Sta³a prêdkoœæ
            else
            {
                currentSpeed = maxSpeed;
            }

            float delta = currentSpeed * Time.deltaTime;
            slotsContainer.anchoredPosition -= new Vector2(delta, 0f);
            LoopSlotsIfNeed();

            elapsed += Time.deltaTime;
            yield return null;
        }

        isScrolling = false;

        FindObjectOfType<Arrow>().CheckWinner();
    }


    void LoopSlotsIfNeed()
    {
        float leftEdgeWorld = slotsContainer.parent.TransformPoint(Vector3.zero).x - 1080;

        for (int i = 0; i < slotsContainer.childCount; i++)
        {
            RectTransform slot = slotsContainer.GetChild(i) as RectTransform;
            float slotWorldX = slot.TransformPoint(Vector3.zero).x;

            float rightEdge = slotWorldX + slotWidth / 2f;

            if (rightEdge < leftEdgeWorld)
            {
                // ZnajdŸ najbardziej prawy slot
                float maxAnchoredX = float.MinValue;
                for (int j = 0; j < slotsContainer.childCount; j++)
                {
                    if (j == i) continue;
                    float x = (slotsContainer.GetChild(j) as RectTransform).anchoredPosition.x;
                    if (x > maxAnchoredX)
                        maxAnchoredX = x;
                }

                float newX = maxAnchoredX + slotWidth;
                slot.SetAsLastSibling();
                slot.anchoredPosition = new Vector2(newX, 0f);
            }
        }
    }

    // Szybki start, wolne zakoñczenie (do przyspieszania)
    float EaseOutCubic(float t)
    {
        return 1f - Mathf.Pow(1f - t, 3);
    }

    // Wolny start, szybkie zakoñczenie (do zwalniania)
    float EaseInCubic(float t)
    {
        return t * t * t;
    }




}
