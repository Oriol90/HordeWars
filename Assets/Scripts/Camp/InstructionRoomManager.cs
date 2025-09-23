using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InstructionRoomManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private Transform topRightPanel;
    [SerializeField] private Transform bottomRightPanel;

    [Header("Prefabs")]
    [SerializeField] private GameObject instructorIconPrefab;
    [SerializeField] private GameObject panelInstructorData;
    List<InstructorData> instructorDataList = new List<InstructorData>();

    private void Start()
    {
        instructorDataList = StaticDataCamp.GetInstructorList();
        PlaceInstructors(instructorDataList);
    }

    private void PlaceInstructors(List<InstructorData> instructorDataList)
    {
        foreach (var instructor in instructorDataList)
        {
            CreateInstructorIcon(instructor);
        }
    }

    private void CreateInstructorIcon(InstructorData instructor)
    {
        GameObject icon = Instantiate(instructorIconPrefab, topRightPanel);
        Image iconImage = icon.GetComponent<Image>();
        if (iconImage != null)
        {
            iconImage.sprite = Resources.Load<Sprite>($"InstructorIcon");
        }

        InstructorIcon instructorIcon = icon.GetComponent<InstructorIcon>();
        instructorIcon.Initialize(instructor);
    }
}