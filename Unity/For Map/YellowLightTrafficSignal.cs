using UnityEngine;
using System.Collections;

//By RetrKill0
public class YellowLightTrafficSignal : MonoBehaviour
{
    public Renderer[] targetRenderers; 
    public string emissionColorProperty = "_EmissionColor"; 
    public Color emissionColor = Color.yellow; 
    public float toggleInterval = 1.0f; 

    private Material[] targetMaterials; 
    private bool emissionEnabled = false; 

    void Start()
    {
        targetMaterials = new Material[targetRenderers.Length];
        for (int i = 0; i < targetRenderers.Length; i++)
        {
            if (targetRenderers[i] != null)
            {
                targetMaterials[i] = targetRenderers[i].material; 
            }
        }
        StartCoroutine(ToggleEmission());
    }

    private IEnumerator ToggleEmission()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);

            emissionEnabled = !emissionEnabled; 

            foreach (Material material in targetMaterials)
            {
                if (material != null)
                {
                    if (emissionEnabled)
                    {
                        material.EnableKeyword("_EMISSION");
                        material.SetColor(emissionColorProperty, emissionColor);
                    }
                    else
                    {
                        material.DisableKeyword("_EMISSION");
                        material.SetColor(emissionColorProperty, Color.black);
                    }
                }
            }
        }
    }
}
