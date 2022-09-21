using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 Offset;
    public float CamPositionSpeed = 5f;

    void FixedUpdate()
    {
        Vector3 newCamPosition = new Vector3(PlayerTransform.position.x + Offset.x, PlayerTransform.position.y + Offset.y, PlayerTransform.position.z + Offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamPosition, CamPositionSpeed * Time.deltaTime);
    }
}
