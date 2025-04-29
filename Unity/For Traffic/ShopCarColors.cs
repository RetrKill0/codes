using UnityEngine;

//By RetrKill0
public class ShopCarColors : MonoBehaviour
{
    [SerializeField] private Color[] newColors; 
    [SerializeField] private Material baseMaterial; 
    [SerializeField] private MeshRenderer[] carParts;

    void Start()
    {
        if (newColors.Length == 0 || baseMaterial == null || carParts.Length == 0)
        {
            //Debug.LogError("As cores, o material base ou as partes do carro n�o est�o configuradas.");
            return;
        }

        int randomNumber = Random.Range(0, newColors.Length);
        Color selectedColor = newColors[randomNumber];

        Material newMaterial = new Material(baseMaterial);

        if (newMaterial.HasProperty("_DiffuseColor"))
        {
            newMaterial.SetColor("_DiffuseColor", selectedColor);
        }
        //else
        //{
        //    Debug.LogError("O material n�o possui a propriedade '_DiffuseColor'.");
        //}

        foreach (MeshRenderer part in carParts)
        {
            Material[] materials = part.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i].name.Contains(baseMaterial.name))
                {
                    materials[i] = newMaterial; 
                }
            }
            part.materials = materials; 
        }
    }
}
