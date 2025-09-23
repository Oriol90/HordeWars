using UnityEngine;

public class CampManager : MonoBehaviour
{
    public static CampManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}