
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{

    [SerializeField] float speed = 10;
    [SerializeField] float angularSpeedIdle = 180;
    [SerializeField] float angularSpeedMove = 90;

    [SerializeField] float turbo = 1.5f;
    [SerializeField] float Nitro = 100;

    void Update()
    {
        //input
       float inputY = Input.GetAxisRaw("Vertical");
       float inputX = Input.GetAxisRaw("Horizontal");


        //forgatas
        float angularSpeed = inputY == 0 ? angularSpeedIdle : angularSpeedMove;
        

        Quaternion rot = transform.rotation;

        transform.Rotate(0,0,-inputX * angularSpeed * Time.deltaTime);




        // mozgatás
        Vector3 direction = transform.up * inputY;
       
            Vector3 pos = transform.position;

            pos += direction * speed * Time.deltaTime;
            transform.position = pos;
       
    }
}
