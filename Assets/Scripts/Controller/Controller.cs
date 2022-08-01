using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Controller : MonoBehaviour
{
    protected abstract IEnumerator Apply(Environment environment);

    public void NewEnvironment(Environment environment)
    {
        StopAllCoroutines();
        StartCoroutine(Apply(environment));
        Debug.Log(environment.environmentName);
    }

}
