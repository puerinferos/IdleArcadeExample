using UnityEngine;

public class Character : MonoBehaviour
{
    private static readonly int DynIdle = Animator.StringToHash("DynIdle");
    private static readonly int Running = Animator.StringToHash("Running");

    [SerializeField] private float speed;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private int garbageMaxCollected = 4;

    private Joystick joystick;
    private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 rotation;

    private int garbageCollected = 0;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        animator.SetTrigger(DynIdle);
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!joystick)
            return;
        Move(joystick.Direction);
    }

    public void Initialize(Joystick joystick)
    {
        this.joystick = joystick;

        joystick.OnMoveStart += OnMoveStart;
        joystick.OnMoveEnd += OnMoveEnd;
    }

    public bool CollectGarbage()
    {
        if (garbageMaxCollected >= garbageCollected)
            garbageCollected++;

        return garbageMaxCollected > garbageCollected;
    }

    public void RemoveGarbage() =>
        garbageCollected = 0;

    private void OnMoveEnd() =>
        HandleAnimation(false);

    private void OnMoveStart() =>
        HandleAnimation(true);

    private void HandleAnimation(bool isRunning)
    {
        animator.SetTrigger(isRunning ? Running : DynIdle);
        var emission = particles.emission;
        emission.rateOverTime = isRunning ? 16 : 0;
    }

    private void Move(Vector2 input)
    {
        movement = new Vector3(input.x, 0, input.y);

        rb.velocity = movement * (speed * Time.deltaTime);
        rb.velocity.Normalize();
        rotation = (transform.position + movement) - transform.position;
        if (movement != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(rotation, Vector3.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            collision.gameObject.GetComponent<IInteractable>().Interact(this);
        }
    }
}