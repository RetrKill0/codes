using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//By RetrKill0
public class CoresVeiculos : MonoBehaviour
{
    
    public Color[] cores;
    public Material material; 
    [FormerlySerializedAs("renderer")]
    public Renderer BodyRenderer; 
    public Renderer[] Renderers; 

    void Start()
    {
        if (cores.Length == 0)
        {
            //Debug.LogWarning("Crie uma ou mais cores na lista.");
            return;
        }
        Color c = cores[Random.Range(0, cores.Length - 1)];

        foreach(Renderer _rend in Renderers)
        {
            _rend.material.color = c;
        }

        if(BodyRenderer != null)
        {
            BodyRenderer.material.color = c;
            return;
        }

        if(TryGetComponent(out Renderer rend))
        {
            rend.material.color = c;
        } else
        {
            if(GetComponentInChildren<Renderer>() != null)
                GetComponentInChildren<Renderer>().material.color = c;
        }

    }
}
