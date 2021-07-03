using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Vector3 rotOffset;
    [SerializeField] public Vector3 posOffset;
    [SerializeField] public float translateSpeed;
    [SerializeField] public float rotationSpeed;

    [SerializeField] public Transform target;

    private void LateUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(rotOffset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.smoothDeltaTime);
    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position + posOffset;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.smoothDeltaTime);
    }
}
