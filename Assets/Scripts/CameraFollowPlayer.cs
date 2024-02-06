using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField] float smoothing = 0.6f;
    [SerializeField] float yOffset = 3f;
    public bool FollowingPlayer = true;

    Vector3 velocity = Vector3.zero;

    void Start()
    {
        transform.position = new Vector3(
        targetToFollow.position.x,
        targetToFollow.position.y + yOffset,
        transform.position.z);
    }


    void LateUpdate()
    {
        if (FollowingPlayer == true)
        {

            Vector3 targetPosition = new Vector3(
             targetToFollow.position.x,
             targetToFollow.position.y + yOffset,
             transform.position.z);

            transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothing);
        }
    }
}
