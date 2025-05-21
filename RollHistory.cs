using UnityEngine;

public class RollHistory : MonoBehaviour
{
    public Transform historyContainer;
    public GameObject redIconPrefab;
    public GameObject blackIconPrefab;
    public GameObject greenIconPrefab;

    public int maxHistory = 5;

    public void AddRoll(string slotName)
    {
        GameObject iconToInstantiate = null;

        switch (slotName)
        {
            case "Red(Clone)":
                iconToInstantiate = redIconPrefab;
                break;
            case "Black(Clone)":
                iconToInstantiate = blackIconPrefab;
                break;
            case "Green(Clone)":
                iconToInstantiate = greenIconPrefab;
                break;
            default:
                Debug.LogWarning("Nieznana nazwa slotu: " + slotName);
                return;
        }

        if (iconToInstantiate != null)
        {

            if (historyContainer.childCount >= maxHistory)
            {
                Destroy(historyContainer.GetChild(0).gameObject);
            }

            Instantiate(iconToInstantiate, historyContainer);
            //Debug.Log(historyContainer.childCount);
        }

    }
}
