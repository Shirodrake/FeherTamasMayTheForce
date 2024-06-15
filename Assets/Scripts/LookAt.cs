using UnityEngine;

class LookAt : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        Vector3 forward = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(forward, Vector3.right);       
    }
}