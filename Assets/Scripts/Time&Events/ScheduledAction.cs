using System;

public class ScheduledAction
    {
        public Action action;
        public int executeAtHour;
        public ScheduledEventData scheduledEventData;

        public ScheduledAction(Action action, int executeAtHour, ScheduledEventData scheduledEventData)
        {
            this.action = action;
            this.executeAtHour = executeAtHour;
            this.scheduledEventData = scheduledEventData;
        }
    }