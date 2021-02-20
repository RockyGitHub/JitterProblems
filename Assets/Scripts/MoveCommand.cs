
using UnityEngine;

namespace RedstoneHallows.Commands
{
    public class MoveCommand : MonoBehaviour
    {
        [SerializeField] private CharacterMotor _motor;

        public void LocalExecute(Vector2 moveVector)
        {
            moveVector = new Vector2(moveVector.x, moveVector.y / 2).normalized;
            _motor.Input = moveVector;
        }

    }
}