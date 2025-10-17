using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public static GameTimeManager GTM { get; private set; }

    private int hoursPerDay = 24;

    public int CurrentTimeInHours { get; private set; } = 0; 
    public int CurrentHour => (int)(CurrentTimeInHours % hoursPerDay);
    public int CurrentDay => (int)(CurrentTimeInHours / hoursPerDay);

    // Eventos
    public event Action<int, int> OnHourPassed; // hora, día
    public event Action<int> OnDayPassed;       // día

    // Acciones programadas
    private List<ScheduledAction> listScheduledAction = new List<ScheduledAction>();

    private void Awake()
    {
        if (GTM != null && GTM != this)
        {
            Destroy(gameObject);
            return;
        }
        GTM = this;
        DontDestroyOnLoad(gameObject);

        CurrentTimeInHours = GC.GET_TOKEN_DATA_LIST.ToList().Find(t => t.token == Token.CurrentTime).value;
    }

    // --- MÉTODOS PRINCIPALES ---

    public void AdvanceHours(int hours)
    {
        for (int i = 0; i < hours; i++)
        {
            CurrentTimeInHours++;
            ProcessScheduledActions();
            CheckHourAndDayEvents();
        }
        TokenData tokenUpdated = GC.GET_TOKEN_DATA_LIST.Find(t => t.token == Token.CurrentTime);
        tokenUpdated.value = CurrentTimeInHours;
        Collections.GetList(DataType.TokenData).Update(tokenUpdated);
    }

    public void AdvanceDays(int days)
    {
        AdvanceHours(days * hoursPerDay);
    }

    // --- PROGRAMAR ACCIONES ---

    public void ScheduleFinishTraining(Action action, TrainingUnitData instructor, int executeAtHour)
    {
        ScheduledEventData scheduledEventData = new ScheduledEventData();
        scheduledEventData.SetFinishTraining(executeAtHour, instructor);
        Collections.GetList(DataType.ScheduledEventData).Add(scheduledEventData);

        ScheduledAction scheduledAction = new ScheduledAction(action, executeAtHour, scheduledEventData);
        listScheduledAction.Add(scheduledAction);
    }

    private void ProcessScheduledActions()
    {
        for (int i = listScheduledAction.Count - 1; i >= 0; i--)
        {
            ScheduledAction scheduledAction = listScheduledAction[i];
            if (CurrentTimeInHours >= scheduledAction.executeAtHour)
            {
                scheduledAction.action?.Invoke();
                listScheduledAction.RemoveAt(i);
                Collections.GetList(DataType.ScheduledEventData).Delete(scheduledAction.scheduledEventData.id);
            }
        }
    }

    private void CheckHourAndDayEvents()
    {
        OnHourPassed?.Invoke(CurrentHour, CurrentDay);
        if (CurrentHour == 0)
            OnDayPassed?.Invoke(CurrentDay);
    }

    // ==========================================
    // 🔽 SAVE / LOAD SYSTEM
    // ==========================================

    public void LoadEventsFromJSON()
    {
        listScheduledAction.Clear();
        foreach (ScheduledEventData scheduledEvent in GC.GET_SCHEDULED_EVENT_LIST)
        {
            if (scheduledEvent.ExecuteAtHour <= 0){
                ExecuteScheduledEventNow(scheduledEvent);
            } else {
                ScheduleEventAgain(scheduledEvent);
            }
        }
    }

    private void ExecuteScheduledEventNow(ScheduledEventData scheduledEventData)
    {
        switch (scheduledEventData.EventType)
        {
            case EventType.FinishTraining:
                EventExecutor.FinishTraining(scheduledEventData.TrainingUnitData);
                break;

            case EventType.RandomEvent:
                Debug.Log("⚠ Evento RandomEvent ejecutado");
                break;

            default:
                Debug.LogWarning($"⚠ Evento desconocido: {scheduledEventData.EventType}");
                break;
        }
    }

    private void ScheduleEventAgain(ScheduledEventData scheduledEventData)
    {
        switch (scheduledEventData.EventType)
        {
            case EventType.FinishTraining:
                TrainingUnitData trainingUnitData = scheduledEventData.TrainingUnitData;
                ScheduleFinishTraining(() => EventExecutor.FinishTraining(trainingUnitData), trainingUnitData, scheduledEventData.ExecuteAtHour);
                break;

            case EventType.RandomEvent:
                Debug.Log("⚠ Evento RandomEvent ejecutado");
                break;

            default:
                Debug.LogWarning($"⚠ Evento desconocido: {scheduledEventData.EventType}");
                break;
        }
    }



    // --- PERSISTENCIA ---

    public int GetTimeForSave() => CurrentTimeInHours;

    public void LoadTime(int savedTotalHours)
    {
        CurrentTimeInHours = savedTotalHours;
    }
}
