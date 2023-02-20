using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract Vector2 RetrieveMoveAxis();

    public virtual Vector2 RetrieveMousePosition(Camera mainCamera)
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = 0;

        return mainCamera.ScreenToWorldPoint(screenPosition);
    }
    public abstract bool RetrieveAttack();
}
