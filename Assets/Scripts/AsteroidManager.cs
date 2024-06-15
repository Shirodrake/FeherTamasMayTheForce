using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] GameObject asteroid1;
    [SerializeField] GameObject asteroid2;
    [SerializeField] GameObject asteroid3;

    [SerializeField] int asteroidCount = 5;
    [SerializeField] float maxAsteroidSpeed = 3;
    [SerializeField] float maxAsteroidAngularSpeed = 180;
    [SerializeField] float minDistanceFromCenter = 5;

    void Start()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int randomNumber = Random.Range(1,4);
        GameObject prefab;
        if (randomNumber == 1)
            prefab = asteroid1;
        else if (randomNumber == 2)
            prefab = asteroid2;
        else 
            prefab = asteroid3;

        GameObject newAsteroid = Instantiate(prefab);

        Rect cameraRect = CameraUtility.GetOrtographicRect(Camera.main);

        Vector2 randomPoint = new();
        for (int i = 0; i <= 10; i++)
        {
            randomPoint = GetRandomPoint(cameraRect);
            if (Vector3.Distance(cameraRect.center, randomPoint) > minDistanceFromCenter)
                break;
        }

        newAsteroid.transform.position = randomPoint;
        newAsteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        Rigidbody2D rb = newAsteroid.GetComponent<Rigidbody2D>();

        rb.velocity = Random.insideUnitCircle * maxAsteroidSpeed;
        rb.angularVelocity = Random.Range(-maxAsteroidAngularSpeed, +maxAsteroidAngularSpeed);
    }

    Vector2 GetRandomPoint(Rect rect)
    {
        float x = Random.Range(rect.xMin, rect.xMax);
        float y = Random.Range(rect.yMin, rect.yMax);
        return new (x, y);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Rect cameraRect = CameraUtility.GetOrtographicRect(Camera.main);
        Gizmos.DrawWireSphere(cameraRect.center, minDistanceFromCenter);
    }
}
