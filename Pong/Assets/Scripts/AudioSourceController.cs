using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    Coroutine coroutine;
    void OnEnable()
    {
        coroutine = StartCoroutine(autoDestruct());
    }

    void OnDisable()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator autoDestruct()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}

