using UnityEngine;

public class PrefabLoader : MonoBehaviour
{
    public GameObject LeafArcherPrefab;
    public GameObject ArcherPrefab;
    public GameObject GirlKnightPrefab;

    public GameObject GetLeafArcherPrefab()
    {
        return LeafArcherPrefab;
    }

    public GameObject GetArcherPrefab()
    {
        return ArcherPrefab;
    }

    public GameObject GetGirlKnightPrefab()
    {
        return GirlKnightPrefab;
    }
}