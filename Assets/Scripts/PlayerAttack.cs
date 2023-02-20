using UnityEngine;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InputController inputController;
    [SerializeField] CircleCollider2D attackCollider;
    [SerializeField] SpriteRenderer attackSprite;

    [Header("Stats")]
    [SerializeField, Range(0f, 0.5f)] float attackDuration = 0.25f;
    float attackDurationCounter;
    List<GameObject> objectsIHit;

    void Start()
    {
        
    }

    void Update()
    {
        if (inputController.RetrieveAttack() && attackDurationCounter <= 0f) // Trigger Attack
        {
            LookAtMouse();
            attackDurationCounter = attackDuration;
        }

        if (attackDurationCounter > 0f) // Run Attack
        {
            attackCollider.enabled = true;
            attackSprite.enabled = true;

            attackDurationCounter -= Time.deltaTime;
        }
        else // End Attack
        {
            if (objectsIHit != null)
            {
                objectsIHit.Clear();
            }

            attackCollider.enabled = false;
            attackSprite.enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectsIHit == null)
        {
            objectsIHit = new List<GameObject>();
        }

        if (!objectsIHit.Contains(collision.gameObject))
        {
            Vector2 direction = collision.gameObject.transform.position - gameObject.transform.position;

            collision.gameObject.SendMessage("Hit", direction.normalized);
            objectsIHit.Add(collision.gameObject);
        }
    }

    void LookAtMouse()
    {
        Vector2 mousePos = inputController.RetrieveMousePosition(Camera.main);
        transform.right = new Vector3(mousePos.x, mousePos.y, 0) - transform.position;
        transform.Rotate(new Vector3(0f, 0f, -45f));
    }
}
