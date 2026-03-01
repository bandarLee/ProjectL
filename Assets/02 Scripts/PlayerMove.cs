using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float moveSpeed = 6f;

    private Rigidbody rb;
    private Vector3 inputMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = 0f;
        float z = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed) x -= 1f;
            if (Keyboard.current.dKey.isPressed) x += 1f;
            if (Keyboard.current.sKey.isPressed) z -= 1f;
            if (Keyboard.current.wKey.isPressed) z += 1f;
        }
        inputMove = new Vector3(x, 0f, z).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = rb.position + inputMove * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPos);
    }
}
