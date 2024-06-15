using UnityEngine; 

class SpaceshipControllerPhysics : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float acceleration = 10;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float angularSpeedInIdle = 360;
    [SerializeField] float angularSpeedInMovement = 180;

    [SerializeField] float maxNitro = 2;
    [SerializeField] float nitroAccelerationMultiplier = 1.5f;
    [SerializeField] float nitroMaxSpeedMultiplier = 1.5f;
    [SerializeField] int collisionDamage = 5;

    float nitro;

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
        rb.rotation += -inputX * angularSpeed * Time.deltaTime;

        // Reset
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.rotation = 0;
            rb.position = Vector3.zero;
            rb.velocity = Vector3.zero;
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
            Vector2 direction = transform.up * inputY;
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

            rb.velocity += direction * realAcceleration * Time.fixedDeltaTime;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, realMaxSpeed);
        }
        else
        {
            nitro += Time.fixedDeltaTime;
            nitro = Mathf.Min(nitro, maxNitro);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<HealthObject>().Damage(collisionDamage);
    }
}
