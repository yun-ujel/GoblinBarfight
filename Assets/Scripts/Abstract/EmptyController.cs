using UnityEngine;

[CreateAssetMenu(fileName = "EmptyController", menuName = "InputController/Empty")]
public class EmptyController : InputController
{
    public override bool RetrieveAttack()
    {
        return false;
    }

    public override Vector2 RetrieveMoveAxis()
    {
        return Vector2.zero;
    }
}
