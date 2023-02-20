using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InputController inputController;
    [SerializeField] Rigidbody2D body;


    [Header("Speed Values")]
    [SerializeField] float maxSpeed;
    [SerializeField] float acceleration;



    void Start()
    {
        
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move(inputController.RetrieveMoveAxis());
    }


    private void Move(Vector2 direction)
    {
        Vector2 velocity = body.velocity;
        float maxDelta = acceleration * Time.deltaTime;

        velocity = new Vector2
        (
            Mathf.MoveTowards(velocity.x, direction.x * maxSpeed, maxDelta),
            Mathf.MoveTowards(velocity.y, direction.y * maxSpeed, maxDelta)
        );

        body.velocity = velocity;
    }

    void Hit(Vector2 hitDirection)
    {
        Debug.Log("Hit in direction " + hitDirection);
        body.AddForce(hitDirection * 20f, ForceMode2D.Impulse);
    }
}
