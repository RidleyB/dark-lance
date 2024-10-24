using System;
using UnityEngine.Events;

[Serializable]
public class IntUnityEvent : UnityEvent<int> { }

[Serializable]
public class FloatUnityEvent : UnityEvent<float> { }

[Serializable]
public class StringUnityEvent : UnityEvent<string> { }

[Serializable]
public class BoolUnityEvent : UnityEvent<bool> { }