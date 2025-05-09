using UnityEngine;

public class Generate : MonoBehaviour
{
    public enum ColorType { Red, Black, Green }

    [System.Serializable]
    public class RollSlot
    {
        public ColorType color;
        public Sprite icon; // np. czerwone/czarne/zielone pole
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
