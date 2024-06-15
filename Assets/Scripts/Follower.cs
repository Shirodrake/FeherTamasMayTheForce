using UnityEngine;

class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    void Update()
    {
        Vector3 selfPoint = transform.position;
        Vector3 targetPoint = target.position;

        if (selfPoint != targetPoint)
        {
            float maxD = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(selfPoint, targetPoint, maxD);
        }
    }
}