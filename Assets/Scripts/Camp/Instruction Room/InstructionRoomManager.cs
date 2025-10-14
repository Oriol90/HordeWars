using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

public class InstructionRoomManager : MonoBehaviour
{
    public Transform instructorGrid;
    public GameObject instructorIconPrefab;
    
    public InstructorIcon instructorSelected;
    public TextMeshProUGUI infoInstructorTrainingText;
    public Slider numUnitsToTrainSlider;
    public Button trainUnitButton;
    public Transform trainingUnitsGrid;
    public GameObject trainingUnitPrefab;

    private TrainingUnitData trainingUnitData;
    private InstructorData instructorData;

    List<InstructorData> instructorDataList = new List<InstructorData>();
    List<TrainingUnitData> trainingUnitDataList = new List<TrainingUnitData>();

    private void Start()
    {
        instructorDataList = GameSaveManager.Load<List<InstructorData>>(DataType.InstructorData);
        trainingUnitDataList ??= new List<TrainingUnitData>();

        PopulateInstructors();
        PopulateTrainingUnits();
        numUnitsToTrainSlider.onValueChanged.AddListener(OnValueNumUnitsChanged);
    }

    private void Clear()
    {
        instructorSelected.gameObject.SetActive(false);
        numUnitsToTrainSlider.gameObject.SetActive(false);
        trainUnitButton.gameObject.SetActive(false);
        infoInstructorTrainingText.text = "";
    }

    private void PopulateInstructors()
    {

        foreach (Transform child in instructorGrid)
        {
            Destroy(child.gameObject);
        }

        foreach (var instructor in instructorDataList)
        {
            CreateInstructorEntry(instructor);
        }
    }
    
    private void PopulateTrainingUnits()
    {
        trainingUnitDataList = GameSaveManager.Load<List<TrainingUnitData>>(DataType.TrainingUnitData);

        foreach (Transform child in trainingUnitsGrid)
        {
            Destroy(child.gameObject);
        }

        foreach (var trainingUnitData in trainingUnitDataList)
        {
            CreateTrainingUnitEntry(trainingUnitData, trainingUnitData.instructorData);
        }
    }

    private void CreateInstructorEntry(InstructorData instructor)
    {
        GameObject instructorIconGO = Instantiate(instructorIconPrefab, instructorGrid);
        InstructorIcon instructorIcon = instructorIconGO.GetComponent<InstructorIcon>();

        instructorIcon.SetUp(instructor);

        Button btn = instructorIconGO.GetComponent<Button>();
        btn.onClick.AddListener(() => OnInstructorClicked(instructor));
    }

    private void CreateTrainingUnitEntry(TrainingUnitData trainingUnitData, InstructorData instructorData)
    {
        GameObject trainingUnitPanelGO = Instantiate(trainingUnitPrefab, trainingUnitsGrid);
        UnitsTrainingPanel unitTrainingPanel = trainingUnitPanelGO.GetComponent<UnitsTrainingPanel>();

        trainingUnitData.UpdateTimeLeft();
        unitTrainingPanel.SetUp(trainingUnitData, instructorData);
    }

    private void OnInstructorClicked(InstructorData instructor)
    {
        instructorSelected.SetUp(instructor);
        numUnitsToTrainSlider.value = 1;
        numUnitsToTrainSlider.gameObject.SetActive(true);
        instructorSelected.gameObject.SetActive(true);
        trainUnitButton.gameObject.SetActive(true);
        UpdateinstructorTrainingText(1);
    }

    private void OnValueNumUnitsChanged(float value)
    {
        int intValue = Mathf.RoundToInt(value);
        UpdateinstructorTrainingText(intValue);
    }

    private void UpdateinstructorTrainingText(int value)
    {
        instructorData = instructorSelected.GetComponent<InstructorIcon>().GetInstructorData();
        infoInstructorTrainingText.text =
            $"{value} {instructorData.trainableUnit}\n" +
            $"{value * instructorData.trainingCost} gold\n" +
            $"{Utils.BeautifyTime(value * instructorData.trainingTime)}";
    }

    public void TrainUnits()
    {
        instructorData = instructorSelected.GetComponent<InstructorIcon>().GetInstructorData();
        trainingUnitData = new TrainingUnitData(instructorData, Mathf.RoundToInt(numUnitsToTrainSlider.value), instructorData.trainingCost, instructorData.trainingTime);
        CreateTrainingUnitEntry(trainingUnitData, instructorData);
        trainingUnitDataList.Add(trainingUnitData);
        Clear();
        PopulateTrainingUnits();
        
        GameTimeManager.GTM.ScheduleFinishTraining(() => EventExecutor.FinishTraining(trainingUnitData), trainingUnitData, trainingUnitData.finishAT);
        GameSaveManager.Save(trainingUnitDataList, DataType.TrainingUnitData);
    }
}