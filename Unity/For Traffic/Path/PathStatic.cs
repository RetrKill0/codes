using UnityEngine;

//By RetrKill0
public class PathStatic : MonoBehaviour
{
    public Color sphereColor;
    public new SphereCollider collider;

    private Transform nextDestination;

    public Transform NextDestination { get => nextDestination; set => nextDestination = value; }

    public bool IsCrossroad()
    {
        // Verifica se o objeto tem mais de uma sa�da
        //return transform.childCount > 1;
        return GetComponent<PathCrossRoad>() != null;
    }

    public Transform GetRandomDestination()
    {
        // Escolhe aleatoriamente um dos filhos do objeto como pr�xima sa�da
        //int randomIndex = Random.Range(0, transform.childCount);
        //return transform.GetChild(randomIndex);
        PathCrossRoad crossRoad = GetComponent<PathCrossRoad>();
        if (crossRoad != null)
        {
            return crossRoad.GetRandomDestination();
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = sphereColor;

        Gizmos.DrawWireSphere(transform.position, collider.radius);
    }
}