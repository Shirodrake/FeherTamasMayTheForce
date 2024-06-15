using UnityEngine;

class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float duration = 5;
    [SerializeField] float distanceToDestroy = 10;
    [SerializeField] int damage = 10;

    Vector3 startPoint;

    void Start()
    {
        Invoke(nameof(OnProjectileDestroy), duration);
        startPoint = transform.position;
    }
    
    void Update()
    {
        transform.position += 
            transform.up * speed * Time.deltaTime;

        float startDistance = (transform.position - startPoint).magnitude;
        bool isOutsideRange = startDistance > distanceToDestroy;
        if (isOutsideRange)
            OnProjectileDestroy();
    }

    void OnProjectileDestroy()
    {
        Destroy(gameObject);
        // Effect
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HealthObject healthObject = other.GetComponent<HealthObject>();
        if (healthObject != null)
        {
            healthObject.Damage(damage);
            Destroy(gameObject);
        }
    }
}
