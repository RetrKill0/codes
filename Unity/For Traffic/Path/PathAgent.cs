using UnityEngine;

//By RetrKill0
public class PathAgent : MonoBehaviour
{
    [Range(0.0f, 100.0f)]
    public float moveSpeed;
    [Range(0.0f, 100.0f)]
    public float rotateSpeed = 20.0f;

    private Transform nextDestination;
    private bool isWaitingAtCrossroad;

    void FixedUpdate()
    {
        if (nextDestination == null)
            return;

        // Verifica se h� um obst�culo na frente do ve�culo
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 15.0f))
        {
            if (hit.collider.CompareTag("PathCar") || hit.collider.CompareTag("PlayerCar") || hit.collider.CompareTag("Player"))
            {
                return; // Se houver um obst�culo, n�o mova o ve�culo
            }
        }

        // Verifica se o ve�culo est� em um cruzamento e se h� outro ve�culo bloqueando o caminho
        if (isWaitingAtCrossroad && Physics.Raycast(transform.position, transform.forward, out hit, 15.0f))
        {
            if (hit.collider.CompareTag("PathCar") || hit.collider.CompareTag("PlayerCar"))
            {
                Debug.Log("Waiting at crossroad");
                return; // Se houver um ve�culo no cruzamento, n�o mova o ve�culo
            }
            else
            {
                isWaitingAtCrossroad = false; // Caminho est� livre, pode seguir
            }
        }

        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);

        Vector3 pos = nextDestination.position;
        pos.y = transform.position.y;

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(pos - transform.position),
            rotateSpeed * Time.deltaTime
        );

        Transform wheels = transform.Find("Wheels");

        if (wheels != null)
        {
            float rotateAmount = moveSpeed / 5.0f;
            wheels.Rotate(rotateAmount * Time.deltaTime * Vector3.right);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Path"))
        {
            PathStatic path = col.GetComponent<PathStatic>();
            nextDestination = path.NextDestination;
            //if (nextDestination != null)

            //    return;


            if (path.IsCrossroad())
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 15.0f))
                {
                    if (hit.collider.CompareTag("PathCar") || hit.collider.CompareTag("PlayerCar"))
                    {
                        isWaitingAtCrossroad = true;
                        return;
                    }
                }

                Transform randomDestination = path.GetRandomDestination();
                if (randomDestination != null)
                {
                    nextDestination = randomDestination;
                }
            }
        }
    }
}