
using UnityEngine;

namespace RedstoneHallows.Commands
{
    public class MoveCommand : MonoBehaviour
    {
        [SerializeField] private CharacterMotor _motor;

        public void LocalExecute(Vector2 moveVector)
        {
            if (Mathf.Abs(moveVector.x) == 1 && Mathf.Abs(moveVector.y) == 1)
                moveVector.y /= 2;
            _motor.Input = moveVector;
        }

    }
}