using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoywhendon : MonoBehaviour
{
    private float Duration;
    private float startTime;

    private void Awake()
    {
        startTime = Time.time;
    }
    [System.Obsolete]
    void Start()
    {
        
        Duration = GetComponent<ParticleSystem>().duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > Duration-0.2f)
        {
            Destroy(gameObject);
        }
    }
}
