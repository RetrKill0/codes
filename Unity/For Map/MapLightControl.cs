using UnityEngine;

//By RetrKill0
public class MapLightControl : MonoBehaviour
{
    public Light[] lightsToControl;
    public GameObject[] lightsPrefabs; 
    public bool activateEmissionOnObject = false;
   // private EnviroSkyMgr EnviroSkyMgr;
    public Material[] emissionMaterials;

    void Start()
    {
        lightsToControl = GetComponentsInChildren<Light>();
       // EnviroSkyMgr = EnviroSkyMgr.instance;
       // if (EnviroSkyMgr.instance == null) return;
    }

    //void Update()
    //{
    //    if (EnviroSkyMgr.instance == null) return;

    //    if (EnviroSkyMgr.GetTimeOfDay() >= 6f && EnviroSkyMgr.GetTimeOfDay() <= 18f)
    //    {
    //        foreach (Light light in lightsToControl)
    //        {
    //            light.enabled = false;
    //        }
    //        DeactivateEmission();
    //    }
    //    else
    //    {
    //        foreach (Light light in lightsToControl)
    //        {
    //            light.enabled = true;
    //        }
    //        ActivateEmission();
    //    }
    //}

    void ActivateEmission()
    {
        foreach (Material emissionMaterial in emissionMaterials)
        {
            emissionMaterial.EnableKeyword("_EMISSION");
        }
    }

    void DeactivateEmission()
    {
        foreach (Material emissionMaterial in emissionMaterials)
        {
            emissionMaterial.DisableKeyword("_EMISSION");
        }
    }
}
