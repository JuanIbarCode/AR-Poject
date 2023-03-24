using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform cam;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);
    }
}
