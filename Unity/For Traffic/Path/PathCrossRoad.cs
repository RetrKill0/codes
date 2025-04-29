using UnityEngine;

//By RetrKill0
public class PathCrossRoad : MonoBehaviour
{
    // Componente vazio para identificar um cruzamento
    public Transform[] possibleDestinations;

    public Transform GetRandomDestination()
    {
        if (possibleDestinations.Length == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, possibleDestinations.Length);
        return possibleDestinations[randomIndex];
    }
}