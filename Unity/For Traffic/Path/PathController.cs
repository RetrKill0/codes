using UnityEngine;

//By RetrKill0
public class PathController : MonoBehaviour
{

    public Transform parentPath;

    private void Awake()
    {
        if (!parentPath)
            parentPath = this.gameObject.transform;

        SetDestination();
    }

    private void SetDestination()
    {
        for (int i = 0; i < parentPath.childCount; i++)
        {
            Transform path = parentPath.GetChild(i);

            if ((i + 1) < parentPath.childCount)
            {
                path.GetComponent<PathStatic>().NextDestination = parentPath.GetChild(i + 1);
                path.name = string.Format("Path_T{0}_{1}", i, (i + 1));
            }
            else
            {
                path.name = string.Format("Path_T{0}_n", (i));
            }
            string prefix = "Path_T";
            string suffix = "_n";
            if ((i + 1) < parentPath.childCount)
            {
                suffix = string.Format("_{0}", (i + 1));
            }
            path.name = string.Format("{0}{1}{2}", prefix, i, suffix);

            // Verifica se � um cruzamento
            if (path.GetComponent<PathStatic>().IsCrossroad())
            {
                // Aleatoriza a pr�xima sa�da
                path.GetComponent<PathStatic>().NextDestination = path.GetComponent<PathStatic>().GetRandomDestination();
            }
        }

        // Faz o loop do �ltimo caminho para o primeiro
        parentPath.GetChild(parentPath.childCount - 1).GetComponent<PathStatic>().NextDestination = parentPath.GetChild(0);
    }
}
