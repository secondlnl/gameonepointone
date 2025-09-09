using UnityEngine;

public class camerafollow : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10f);
    [SerializeField] private float smoothing = 1.0f;

    void LateUpdate()
    {
        Vector3 newpos = Vector3.Lerp(transform.position, Target.position + offset, smoothing * Time.deltaTime);
        transform.position = newpos;
    }
}
