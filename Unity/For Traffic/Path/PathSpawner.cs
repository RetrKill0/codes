using UnityEngine;
using System.Collections.Generic;
using codeItGameStudio.baixosQuebrada.Race; // Remove

//By RetrKill0
public class PathSpawner : MonoBehaviour
{
    public PathController[] pathControllers; 
    public GameObject[] carPrefabs; 
    public int numberOfCars;
    private List<GameObject> carsInScene = new();

    private bool isActiveCars;

    private void OnEnable()
    {
        SpawnCars();
    }
    private void Start()
    {
        isActiveCars = true;
        RaceManager.OnStateRace += StateRaceListen;
    }
    private void OnDestroy()
    {
        RaceManager.OnStateRace -= StateRaceListen;
    }

    private void StateRaceListen(StateRace state)
    {
        if(state == StateRace.PREPARATION)
        {
            DeactivateOrActiveAllCars(false);
        }else if(state == StateRace.WORLD)
        {
            DeactivateOrActiveAllCars(true);
        }
    }
    [ContextMenu("Deactivate or Active All Cars")]
    public void teste()
    {
        isActiveCars = !isActiveCars;
        DeactivateOrActiveAllCars(isActiveCars);
    }

    public void DeactivateOrActiveAllCars(bool state)
    {
        // Percorre a lista de tr�s para frente para evitar problemas caso haja necessidade de remover elementos durante a itera��o.
        for (int i = carsInScene.Count - 1; i >= 0; i--)
        {
            if (carsInScene[i] != null)
            {
                carsInScene[i].SetActive(state);
            }
        }
    }

    void SpawnCars()
    {
        // Cria uma lista de PathControllers dispon�veis
        List<PathController> availablePathControllers = new List<PathController>(pathControllers);

        for (int i = 0; i < numberOfCars; i++)
        {
            // Se n�o houver mais PathControllers dispon�veis, interrompe o loop
            if (availablePathControllers.Count == 0)
            {
                break;
            }

            // Escolhe um PathController aleat�rio
            int randomIndex = Random.Range(0, availablePathControllers.Count);
            PathController randomPathController = availablePathControllers[randomIndex];

            // Remove o PathController escolhido da lista de dispon�veis
            availablePathControllers.RemoveAt(randomIndex);

            // Escolhe um ponto de spawn aleat�rio dentro do PathController escolhido
            Transform randomSpawnPoint = randomPathController.parentPath.GetChild(Random.Range(0, randomPathController.parentPath.childCount));

            // Escolhe um carro aleat�rio da lista
            GameObject randomCarPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];

            // Instancia o carro no ponto de spawn com a rota��o do ponto de spawn
            //Instantiate(randomCarPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
            // Instancia o carro no ponto de spawn
            GameObject carInstance = Instantiate(randomCarPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

            carsInScene.Add(carInstance);

            // Ajusta a rota��o do carro para apontar para o pr�ximo ponto no caminho
            if (randomSpawnPoint.GetSiblingIndex() < randomPathController.parentPath.childCount - 1)
            {
                Transform nextPoint = randomPathController.parentPath.GetChild(randomSpawnPoint.GetSiblingIndex() + 1);
                Vector3 direction = (nextPoint.position - randomSpawnPoint.position).normalized;
                carInstance.transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
