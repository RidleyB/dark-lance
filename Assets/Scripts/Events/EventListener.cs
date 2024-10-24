using System;
using UnityEngine;

namespace arg.events
{
    public interface IEventListener
    {
        void InvokeCallback();
    }

    public class EventListener : IEventListener
    {
        private EventObjectBase eventObject;
        private Action eventCallback;

        public void Sub(EventObjectBase a_event, Action a_callback)
        {
            if (!Validate(a_event, a_callback))
                return;

            eventObject = a_event;
            eventCallback = a_callback;
            eventObject.AddListener(this);
        }

        public void Unsub()
        {
            if (!Validate(eventObject, eventCallback))
                return;

            eventObject.RemoveListener(this);
            eventCallback = null;
            eventObject = null;
        }

        public void InvokeCallback()
        {
            if (!Validate(eventObject, eventCallback))
                return;

            eventCallback();
        }

        private bool Validate(EventObjectBase a_event, Action a_callback)
        {
            if (a_event == null)
            {
                Debug.LogError("Event was null");
                return false;
            }

            if (a_callback == null)
            {
                Debug.LogError("Callback was null");
                return false;
            }

            return true;
        }
    }

    public class EventListener<T1> : IEventListener
    {
        private EventObject<T1> eventObject;
        private Action<T1> eventCallback;

        public void Sub(EventObject<T1> a_event, Action<T1> a_callback)
        {
            if (!Validate(a_event, a_callback))
                return;

            eventObject = a_event;
            eventCallback = a_callback;
            eventObject.AddListener(this);
        }

        public void Unsub()
        {
            if (!Validate(eventObject, eventCallback))
                return;

            eventObject.RemoveListener(this);
            eventCallback = null;
            eventObject = null;
        }

        public void InvokeCallback()
        {
            if (!Validate(eventObject, eventCallback))
                return;

            object[] parameters = eventObject.GetEventParameters();
            eventCallback((T1)parameters[0]);
        }

        private bool Validate(EventObject<T1> a_event, Action<T1> a_callback)
        {
            if (a_event == null)
            {
                Debug.LogError("Event was null");
                return false;
            }

            if (a_callback == null)
            {
                Debug.LogError("Callback was null");
                return false;
            }

            return true;
        }
    }

    public class EventListener<T1, T2> : IEventListener
    {
        private EventObject<T1, T2> eventObject;
        private Action<T1, T2> eventCallback;

        public void Sub(EventObject<T1, T2> a_event, Action<T1, T2> a_callback)
        {
            if (!Validate(a_event, a_callback))
                return;

            eventObject = a_event;
            eventCallback = a_callback;
            eventObject.AddListener(this);
        }

        public void Unsub()
        {
            if (!Validate(eventObject, eventCallback))
                return;

            eventObject.RemoveListener(this);
            eventCallback = null;
            eventObject = null;
        }

        public void InvokeCallback()
        {
            if (!Validate(eventObject, eventCallback))
                return;

            object[] parameters = eventObject.GetEventParameters();
            eventCallback((T1)parameters[0], (T2)parameters[1]);
        }

        private bool Validate(EventObject<T1, T2> a_event, Action<T1, T2> a_callback)
        {
            if (a_event == null)
            {
                Debug.LogError("Event was null");
                return false;
            }

            if (a_callback == null)
            {
                Debug.LogError("Callback was null");
                return false;
            }

            return true;
        }
    }

    public class EventListener<T1, T2, T3> : IEventListener
    {
        private EventObject<T1, T2, T3> eventObject;
        private Action<T1, T2, T3> eventCallback;

        public void Sub(EventObject<T1, T2, T3> a_event, Action<T1, T2, T3> a_callback)
        {
            if (!Validate(a_event, a_callback))
                return;

            eventObject = a_event;
            eventCallback = a_callback;
            eventObject.AddListener(this);
        }

        public void Unsub()
        {
            if (!Validate(eventObject, eventCallback))
                return;

            eventObject.RemoveListener(this);
            eventCallback = null;
            eventObject = null;
        }

        public void InvokeCallback()
        {
            if (!Validate(eventObject, eventCallback))
                return;

            object[] parameters = eventObject.GetEventParameters();
            eventCallback((T1)parameters[0], (T2)parameters[1], (T3)parameters[2]);
        }

        private bool Validate(EventObject<T1, T2, T3> a_event, Action<T1, T2, T3> a_callback)
        {
            if (a_event == null)
            {
                Debug.LogError("Event was null");
                return false;
            }

            if (a_callback == null)
            {
                Debug.LogError("Callback was null");
                return false;
            }

            return true;
        }
    }
}