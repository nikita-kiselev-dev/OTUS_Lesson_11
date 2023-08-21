using UnityEngine;

public sealed class Player : MonoBehaviour
{
    private static readonly int State = Animator.StringToHash("State");
    private const int IDLE_ANIM_STATE = 0;
    private const int MOVE_ANIM_STATE = 1;

    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private float rotationSpeed;
 
    [SerializeField]
    private Animator animator;
    
    private Vector3 moveDirection;
    private bool isMoving;
    
    public void Move(Vector3 direction)
    {
        this.moveDirection = direction;
        this.isMoving = true;
    }

    private void FixedUpdate()
    {
        Debug.Log($"{GetType().Name}.FixedUpdate: isMoving = {isMoving}");
        
        if (this.isMoving)
        {
            this.UpdateMovement();
            this.animator.SetInteger(State, IDLE_ANIM_STATE); //MOVE
            this.isMoving = false;
        }
        else
        {
            this.animator.SetInteger(State, MOVE_ANIM_STATE); //IDLE
        }
    }

    private void UpdateMovement()
    {
        var deltaTime = Time.fixedDeltaTime;
        this.transform.position += moveDirection * this.moveSpeed * deltaTime;

        var targetRotation = Quaternion.LookRotation(this.moveDirection, Vector3.up);
        var nextRotation = Quaternion.Slerp(this.transform.rotation, targetRotation, this.rotationSpeed * deltaTime);
        this.transform.rotation = nextRotation;
    }
}
