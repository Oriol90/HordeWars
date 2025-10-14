using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitsTrainingPanel : MonoBehaviour
{
    public Image unitTypeImage;
    public InstructorIcon instructorIcon;
    public TMP_Text infoTrainingUnitText;
    public GenericProgressBar trainingProgressBar;

    public void SetUp(TrainingUnitData trainingUnitData, InstructorData instructorData)
    {
        unitTypeImage.sprite = ResourcePathDBStatic.Get(instructorData.trainableUnit);
        instructorIcon.SetUp(instructorData);
        infoTrainingUnitText.text = trainingUnitData.GetInfo();
        trainingProgressBar.SetMaxValue(trainingUnitData.finishAT);
        trainingProgressBar.SetMinValue(trainingUnitData.startedAT);
        trainingProgressBar.SetValue(trainingUnitData.finishAT - trainingUnitData.timeLeft);
    }
}