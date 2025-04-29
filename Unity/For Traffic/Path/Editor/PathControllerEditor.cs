using UnityEngine;
using UnityEditor;

//By RetrKill0
[CustomEditor(typeof(PathController))]
public class PathControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PathController pathController = (PathController)target;

        if (GUILayout.Button("Renomear com base na hierarquia"))
        {
            RenamePaths(pathController.parentPath);
        }

        if (GUILayout.Button("Inverter Ordem"))
        {
            InvertOrder(pathController.parentPath);
        }
    }

    private void RenamePaths(Transform parentPath)
    {
        for (int i = 0; i < parentPath.childCount; i++)
        {
            Transform path = parentPath.GetChild(i);

            string prefix = "Path_T";
            string suffix = "_n";
            if ((i + 1) < parentPath.childCount)
            {
                suffix = string.Format("_{0}", (i + 1));
            }

            path.name = string.Format("{0}{1}{2}", prefix, i, suffix);
        }

        // Faz o loop do �ltimo caminho para o primeiro
        parentPath.GetChild(parentPath.childCount - 1).GetComponent<PathStatic>().NextDestination = parentPath.GetChild(0);
    }

    private void InvertOrder(Transform parent)
    {
        int childCount = parent.childCount;
        for (int i = 0; i < childCount / 2; i++)
        {
            int otherIndex = childCount - 1 - i;
            Transform temp = parent.GetChild(i);
            Transform other = parent.GetChild(otherIndex);
            temp.SetSiblingIndex(otherIndex);
            other.SetSiblingIndex(i);
        }

        // Atualiza as refer�ncias
        RenamePaths(parent);
    }
}
