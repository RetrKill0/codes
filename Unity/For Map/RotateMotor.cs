using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By RetrKill0
public class RotateMotor : MonoBehaviour
{
    enum Type
    {
        Rotate,
        Float 
    }

    [SerializeField]
    Type type = Type.Rotate;

    [SerializeField]
    [Range(1, 10)]
    float speed = 1;

    [SerializeField]
    Vector3 axis = Vector3.up;

    [SerializeField]
    bool enableVerticalMovement = false;

    [SerializeField]
    bool enableRotationWhileFloating = false;

    [SerializeField]
    [Range(0f, 5f)]
    float floatAmplitude = 0.5f;

    [SerializeField]
    [Range(0f, 5f)]
    float floatFrequency = 1f;

    private Vector3 startPosition;
    private Transform modelTransform;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        if (meshRenderer != null)
        {
            modelTransform = meshRenderer.transform;
        }
        else
        {
            modelTransform = transform;
        }

        startPosition = modelTransform.position;
    }

    void Update()
    {
        switch (type)
        {
            case Type.Rotate:
                modelTransform.Rotate(speed * Time.deltaTime * axis);
                break;
            case Type.Float:
                if (enableVerticalMovement)
                {
                    Vector3 newPosition = startPosition;
                    newPosition.y += Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
                    modelTransform.position = newPosition;

                    if (enableRotationWhileFloating)
                    {
                        modelTransform.Rotate(speed * Time.deltaTime * axis);
                    }
                }
                break;
        }
    }
}
