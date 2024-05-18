
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] int maxAmmo;

    [SerializeField] int ammo;

   void Start()
    {
        ammo = maxAmmo;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (ammo > 0)
            {
                Debug.Log("Boom");
                ammo--;
            }

            else
            {
                Debug.Log("Klikk");
            }


            if (Input.GetKeyDown(KeyCode.X) && ammo == 0)
            {
                ammo = maxAmmo;
            }
        }
    }
}
