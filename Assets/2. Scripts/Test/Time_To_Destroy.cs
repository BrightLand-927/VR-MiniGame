using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Time_To_Destroy : MonoBehaviour
{
    public float duration;

    private void OnEnable()
    {
        duration = Random.Range(duration - 10f, duration + 30f);
    }

    float time;
    void Update()
    {
        if (time > duration)
        {
            this.transform.SetParent(Camera.main.transform);
            this.gameObject.SetActive(false);
        }

        time += Time.deltaTime;

        // Debug.Log(time);
    }
}
