using System;
using System.Collections;
using UnityEngine;

public class ActionCooldown
{
    public float duration;
    public MonoCoroutineData monoCoroutine;
    float time;
    public bool onCooldown { get; private set; }

    public float remaining { get; private set; }

    public void StartCooldown()
    {
        monoCoroutine.data.StartCoroutine(Cooldown());
    }

    public void ClearCooldown()
    {
        monoCoroutine.data.StopCoroutine(Cooldown());
    }

    public IEnumerator Cooldown()
    {
        time = 0;
        remaining = duration;
        onCooldown = true;
        yield return null;

        while (time <= duration)
        {
            time += Time.deltaTime;
            remaining = (float)Math.Round(Mathf.Clamp(duration - time, 0, duration), 1);
            yield return null;
        }

        remaining = 0;
        time = 0;
        onCooldown = false;
    }
}