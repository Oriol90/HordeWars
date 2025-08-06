using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentArrow : MonoBehaviour
{
    public RectTransform origin;
    public RectTransform target;
    public LineRenderer line;

    void Start()
    {
        if (origin == null || target == null || line == null)
            return;

        Vector3 startPos = GetWorldCenter(origin);
        Vector3 endPos = GetWorldCenter(target);

        line.positionCount = 2;
        line.SetPosition(0, startPos);
        line.SetPosition(1, endPos);

    }

    Vector3 GetWorldCenter(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        return (corners[0] + corners[2]) / 2f; // centro del RectTransform
    }
}
