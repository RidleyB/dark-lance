using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace arg.events
{
    public abstract class EventObjectBase : SerializedScriptableObject
    {
        protected List<IEventListener> listeners = new List<IEventListener>();

        public void AddListener(IEventListener a_eventListener)
        {
            if (a_eventListener == null)
            {
                Debug.LogError("Event listener was null");
                return;
            }

            if (listeners.Contains(a_eventListener))
            {
                Debug.LogError("Event listener is already contained within event list.");
                return;
            }

            listeners.Add(a_eventListener);
        }

        public void RemoveListener(IEventListener a_eventListener)
        {
            if (a_eventListener == null)
            {
                Debug.LogError("Event listener was null");
                return;
            }

            if (!listeners.Contains(a_eventListener))
            {
                Debug.LogError("Event listener is not in event list.");
                return;
            }

            listeners.Remove(a_eventListener);
        }

        protected void _Invoke()
        {
            if (listeners.Count == 0)
            {
                // Debug.Log("No invocations in list.");
                return;
            }

            foreach (IEventListener eventListener in listeners)
            {
                eventListener.InvokeCallback();
            }
        }

        internal abstract object[] GetEventParameters();
    }


    [CreateAssetMenu(menuName = "ARG/Events/Event")]
    public class EventObject : EventObjectBase
    {
        [Button]
        public void Invoke() => _Invoke();

        internal override object[] GetEventParameters()
        {
            return new object[0];
        }
    }

    [CreateAssetMenu(menuName = "ARG/Events/Event 1 Arg")]
    public class EventObject<T1> : EventObjectBase
    {
        public T1 arg1;

        [Button]
        public void Invoke(T1 a_arg1)
        {
            arg1 = a_arg1;
            _Invoke();
            arg1 = default;
        }

        internal override object[] GetEventParameters()
        {
            return new object[] { arg1 };
        }
    }

    [CreateAssetMenu(menuName = "ARG/Events/Event 2 Args")]
    public class EventObject<T1, T2> : EventObjectBase
    {
        public T1 arg1;
        public T2 arg2;

        [Button]
        public void Invoke(T1 a_arg1, T2 a_arg2)
        {
            arg1 = a_arg1;
            arg2 = a_arg2;
            _Invoke();
            arg1 = default;
            arg2 = default;
        }

        internal override object[] GetEventParameters()
        {
            return new object[] { arg1, arg2 };
        }
    }

    [CreateAssetMenu(menuName = "ARG/Events/Event 3 Args")]
    public class EventObject<T1, T2, T3> : EventObjectBase
    {
        public T1 arg1;
        public T2 arg2;
        public T3 arg3;

        [Button]
        public void Invoke(T1 a_arg1, T2 a_arg2, T3 a_arg3)
        {
            arg1 = a_arg1;
            arg2 = a_arg2;
            arg3 = a_arg3;
            _Invoke();
            arg1 = default;
            arg2 = default;
            arg3 = default;
        }

        internal override object[] GetEventParameters()
        {
            return new object[] { arg1, arg2, arg3 };
        }
    }
}