using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_scr : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target;
    public float camAheadOffset = 0f;
        //offset the camera left or right
    public float camUpOffset;
        //offset camera up or down
    public float camSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x + camAheadOffset * Mathf.Sign(target.localScale.x), target.position.y + camUpOffset, transform.position.z);


        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * camSpeed);
    }
}
