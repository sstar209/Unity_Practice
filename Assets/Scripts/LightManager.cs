using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightManager : MonoBehaviour
{
    private Light theLight;

    private float targetIntensity;
    private float currentIntensity;


    void Start()
    {
        theLight = GetComponent<Light>();
        currentIntensity = theLight.intensity;
        targetIntensity = 1f;
    }

    void Update()
    {
        if (BossSpawn.instance2.bossAppear == true)
        {
            currentIntensity -= Time.deltaTime * 0.25f;

            if(currentIntensity == 0)
            {
                currentIntensity = 0;
            }
        }
      
        theLight.intensity = currentIntensity;
    }
}
