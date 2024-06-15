using UnityEngine; 

class SpaceshipController : MonoBehaviour
{
    [SerializeField] float acceleration = 10;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float angularSpeedInIdle = 360;
    [SerializeField] float angularSpeedInMovement = 180;
    [SerializeField] float drag = 0.5f;

    [SerializeField] float maxNitro = 2;
    [SerializeField] float nitroAccelerationMultiplier = 1.5f;
    [SerializeField] float nitroMaxSpeedMultiplier = 1.5f;

    float nitro;
    Vector3 velocity;

    void Start()
    {
        nitro = maxNitro;
    }

    void Update()
    {
        // Input
        float inputY = Input.GetAxisRaw("Vertical");
        float inputX = Input.GetAxisRaw("Horizontal");

        // Forgatás
        float angularSpeed = inputY <= 0 ? angularSpeedInIdle : angularSpeedInMovement;
        transform.Rotate(0, 0, -inputX * angularSpeed * Time.deltaTime);

        // Mozgás
        transform.position += velocity * Time.deltaTime;

        // Reset
        if (Input.GetKeyDown(KeyCode.X))
        {
            Vector3 euler = transform.rotation.eulerAngles;
            euler.z = 0;
            transform.rotation = Quaternion.Euler(euler);
            transform.position = Vector3.zero;
            velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // Input
        float inputY = Input.GetAxisRaw("Vertical");
        inputY = Mathf.Max(inputY, 0);

        // Gyorsulás
        if (inputY > 0)
        {
            Vector3 direction = transform.up * inputY;
            float realAcceleration = acceleration;
            float realMaxSpeed = maxSpeed;

            // Nitro
            if (nitro > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                realAcceleration *= nitroAccelerationMultiplier;
                realMaxSpeed *= nitroMaxSpeedMultiplier;
                nitro -= Time.fixedDeltaTime;
                nitro = Mathf.Max(nitro, 0);
            }

            velocity += direction * realAcceleration * Time.fixedDeltaTime;
            velocity = Vector3.ClampMagnitude(velocity, realMaxSpeed);

        }
        else
        {
            nitro += Time.fixedDeltaTime;
            nitro = Mathf.Min(nitro, maxNitro);
        }

        // Lassítás
        Vector3 dragVector = -velocity * drag;
        velocity += dragVector * Time.deltaTime;
    }

}
