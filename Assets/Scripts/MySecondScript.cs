using System.Security.Cryptography;
using UnityEngine;

public class MySecondScript : MonoBehaviour
{
    [SerializeField] int num;
    
    void Start()
    {
        int i = 1;
        while (i <= 10)
        {
            Debug.Log(i);
            i = i++;
        }

        for (int j = 0; j <= 10; j++)
        {
            Debug.Log(j);
        }    

    }

}
