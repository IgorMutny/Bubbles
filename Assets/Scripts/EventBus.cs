using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<string, List<object>> _eventActions = new();

    public static void Subscribe<T>(Action<T> action) where T : IEvent
    {
        string key = typeof(T).Name;

        if (_eventActions.ContainsKey(key))
        {
            _eventActions[key].Add(action);
        }
        else
        {
            List<object> actions = new() { action };
            _eventActions.Add(key, actions);
        }
    }

    public static void Unsubscribe<T>(Action<T> action) where T : IEvent
    {
        string key = typeof(T).Name;

        if (_eventActions.ContainsKey(key))
        {
            _eventActions[key].Remove(action);
        }
    }

    public static void Invoke<T>(T arguments) where T : IEvent
    {
        string key = typeof(T).Name;

        if (_eventActions.ContainsKey(key))
        {
            List<object> actions = new(_eventActions[key]);

            foreach (var action in actions)
            {
                ((Action<T>)action)?.Invoke(arguments);
            }
        }
    }
}