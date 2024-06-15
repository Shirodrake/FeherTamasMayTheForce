using UnityEngine;
using UnityEngine.Serialization;

class Shooter : MonoBehaviour
{

    [SerializeField] GameObject prototype;
    [SerializeField] int maxAmmo;
    [SerializeField, FormerlySerializedAs("offsetPoint")] Vector3 offsetPosition;

    int ammo;

    void Start()
    {
        ammo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ammo > 0)
            {
                GameObject newProjectile = Instantiate(prototype); 
                newProjectile.transform.position = GetProjectileStartPoint();
                newProjectile.transform.rotation = transform.rotation;

                ammo--;
            }
            else
            {
                Debug.Log("Klikk");
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && ammo == 0)
            ammo = maxAmmo;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GetProjectileStartPoint(), 0.25f);
    }

    Vector3 GetProjectileStartPoint()
    {
        Vector3 localOffset = transform.TransformVector(offsetPosition);
        return transform.position + localOffset;
    }
}
