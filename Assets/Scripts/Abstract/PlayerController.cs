using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController", menuName = "InputController/Player")]
public class PlayerController : InputController
{
    public override bool RetrieveAttack()
    {
        return Input.GetButtonDown("Fire1");
    }

    public override Vector2 RetrieveMoveAxis()
    {
        Vector2 moveAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveAxis.sqrMagnitude > 1)
        {
            moveAxis = moveAxis.normalized;
        }

        return moveAxis;
    }
}
