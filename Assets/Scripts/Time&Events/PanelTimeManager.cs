using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelTimeManager : MonoBehaviour
{
    public TMP_Text timeText;
    public Button buttonAdvanceHour;
    public Button buttonAdvanceDay;

    private int currentTimeInHours;

    private void Start()
    {
        buttonAdvanceHour.onClick.AddListener(OnAdvanceHourClicked);
        buttonAdvanceDay.onClick.AddListener(OnAdvanceDayClicked);
    }

    private void Update()
    {
        currentTimeInHours = GameTimeManager.GTM.CurrentTimeInHours;
        timeText.text = Utils.ShowTime(currentTimeInHours);
    }

    private void OnAdvanceHourClicked()
    {
        GameTimeManager.GTM.AdvanceHours(1);
    }
    private void OnAdvanceDayClicked()
    {
        GameTimeManager.GTM.AdvanceHours(24);
    }
}