using UnityEngine;
//BY RetrKill0
/// <summary>
/// Randomize the visibility of extra parts (GameObjects) whenever the main object is enabled
/// </summary>
public class HR_RandomizeExtraPartsOnEnable : MonoBehaviour
{

    [System.Serializable]
    public class ExtraPart
    {
        public GameObject part;  
        [Range(0f, 1f)]
        public float appearanceProbability = 0.5f;  
    }

    public ExtraPart[] extraParts;

    /// <summary>
    /// Randomize the appearance of extra parts whenever the object is enabled
    /// </summary>
    private void OnEnable()
    {
        RandomizeParts();
    }

    /// <summary>
    /// Enable or disable each extra part based on its appearance probability
    /// </summary>
    private void RandomizeParts()
    {
        for (int i = 0; i < extraParts.Length; i++)
        {
            if (extraParts[i].part != null)
            {
                bool shouldAppear = Random.value <= extraParts[i].appearanceProbability;
                extraParts[i].part.SetActive(shouldAppear);
            }
        }
    }

    private void OnValidate()
    {
        if (extraParts == null) return;

        for (int i = 0; i < extraParts.Length; i++)
        {
            if (extraParts[i].part != null && extraParts[i].appearanceProbability == 0)
            {
                extraParts[i].appearanceProbability = 0.5f; 
            }
        }
    }
}
