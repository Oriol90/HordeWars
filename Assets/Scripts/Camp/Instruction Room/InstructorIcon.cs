using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructorIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image background;
    public Image instructorImage;
    public PanelTooltip instructorTooltipPanel;

    private InstructorData instructorData;
    private TooltipObj tooltipUnit;
    private bool isPointerOver;

    public void SetUp(InstructorData instructorData)
    {
        this.instructorData = instructorData;
        background.color = Utils.GetColorByRarity(instructorData.rarity);
        instructorImage.sprite = Resources.Load<Sprite>(instructorData.spritePath);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (instructorData != null && !isPointerOver)
        {
            isPointerOver = true;

            tooltipUnit = new TooltipObj(instructorData.instructorName, instructorData.GetInfo(), TooltipType.UnitCourtyard, transform.position);
            instructorTooltipPanel.ShowTooltip(tooltipUnit);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        instructorTooltipPanel.HideTooltip();
    }
    
    public InstructorData GetInstructorData()
    {
        return instructorData;
    }
}
