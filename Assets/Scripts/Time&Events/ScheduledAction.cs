using System;

public class ScheduledAction
    {
        public Action action;
        public int executeAtHour;
        public ScheduledEventData meta;

        public ScheduledAction(Action action, int executeAtHour, ScheduledEventData meta)
        {
            this.action = action;
            this.executeAtHour = executeAtHour;
            this.meta = meta;
        }
    }