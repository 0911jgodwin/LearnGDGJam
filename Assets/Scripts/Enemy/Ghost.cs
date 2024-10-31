using NUnit.Framework;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] float maxSpeed = 9f;
    [SerializeField] float speed = 5f;

    [SerializeField] Mesh debugMesh;
    [SerializeField] Material debugMaterialOrange;
    [SerializeField] Material debugMaterialGreen;

    public bool debugEnabled = true;

    private Vector3 TargetPosition { get => target.position; }
    private List<Vector3> waypoints = new List<Vector3>();
    private int worldLayerMask;

    public Transform target;
    private Animator animator;
    private Rigidbody2D _rb;

    private float stuckTimer = -1;
    private Vector3 lastPosition;
    private bool wiggleWaypointExists;
    private float originalDrag;


    private LineRenderer debugLineRenderer;
    private Material debugLineMaterialGreen;
    private Material debugLineMaterialOrange;

    void Awake()
    {
        animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        worldLayerMask = LayerMask.GetMask("Ground");
        originalDrag = _rb.linearDamping;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GameObject().GetComponent<RespawnManager>().Damage(3f);
            Destroy(gameObject);
        } else if (collision.CompareTag("NoGhostZone"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (debugEnabled)
            DrawDebug();
        if (target == null)
            return;

        // Raycast in the direction of our target, if we can see our target without hitting anything empty our waypoints list
        var targetDirection = (TargetPosition - transform.position).normalized;            
        if (Physics2D.CircleCast(transform.position, 0.7f, targetDirection, Vector2.Distance(transform.position, TargetPosition), worldLayerMask).collider == null &&
                !Physics2D.OverlapCircle(transform.position + targetDirection, 0.6f, worldLayerMask)) {
            waypoints.Clear();
            waypoints.Add(TargetPosition);
        }

        // If we have a waypoint
        if (waypoints.Count > 0 && Vector3.Distance(waypoints[waypoints.Count - 1], TargetPosition) > 1f)
        {
            waypoints.Add(TargetPosition);
        }

        if (waypoints.Count == 0)
            return;

        // If our current position is close enough to the next waypoint we remove that waypoint and cancel any attempts to get unstuck
        if (Vector3.Distance(transform.position, waypoints[0]) < 1f)
        {
            waypoints.RemoveAt(0);
            wiggleWaypointExists = false;
        }
    }

    private void FixedUpdate()
    {
        //If we have no target set the damping to 1f to freeze in place, otherwise set our damping to the base damping value
        if (waypoints.Count == 0)
        {
            _rb.linearDamping = 1f;
            return;
        }
        else
            _rb.linearDamping = originalDrag;

        // Move towards our current waypoint
        var targetDirection = (waypoints[0] - transform.position).normalized;
        _rb.linearVelocity = targetDirection * speed;

        // Prevent ghost from exceeding our max speed
        if (_rb.linearVelocity.magnitude > maxSpeed)
            _rb.linearVelocity = _rb.linearVelocity.normalized * maxSpeed;

        // Check distance travelled since our last frame
        var distanceTravelled = Vector3.Distance(lastPosition, _rb.position);
        lastPosition = _rb.position;

        // If we didn't move > 1 unit assume we're stuck
        if (distanceTravelled < Time.fixedDeltaTime)
        {
            if (stuckTimer < 0)
                stuckTimer = Time.time;

            if (Time.time > stuckTimer + 1)
            {
                // Find a random point around us and move in that direction
                var randomInCircle = Random.insideUnitCircle.normalized * 4;
                var wigglePosition = _rb.position + new Vector2(randomInCircle.x, randomInCircle.y);

                if (!Physics.CheckSphere(wigglePosition, 0.5f, worldLayerMask))
                {
                    if (!wiggleWaypointExists)
                    {
                        waypoints.Insert(0, wigglePosition);
                        wiggleWaypointExists = true;
                    } else
                    {
                        waypoints[0] = wigglePosition;
                    }

                    stuckTimer = -1;
                }
            }
        }        
    }

    private void DrawDebug()
    {
        if (debugLineRenderer == null)
        {
            debugLineMaterialOrange = new Material(debugMaterialOrange);
            debugLineMaterialOrange.color = Color.yellow;
            debugLineMaterialGreen = new Material(debugMaterialGreen);
            debugLineMaterialGreen.color = Color.green;
            debugLineRenderer = gameObject.AddComponent<LineRenderer>();
            debugLineRenderer.material = debugLineMaterialOrange;
            debugLineRenderer.startWidth = debugLineRenderer.endWidth = 0.5f;
        }

        var targetDirection = (TargetPosition - transform.position).normalized;

        for (int i = 0; i < waypoints.Count; i++)
        {
            Graphics.DrawMesh(debugMesh, waypoints[i], Quaternion.identity, i == 0 ? debugMaterialGreen : debugMaterialOrange, 0);
            var hit = Physics2D.CircleCast(transform.position, 0.7f, targetDirection, Vector2.Distance(transform.position, TargetPosition), worldLayerMask);
            if (hit.collider != null)
            {
                debugLineRenderer.sharedMaterial = debugLineMaterialOrange;
                debugLineRenderer.SetPositions(new Vector3[] { transform.position, hit.point });
            } else
            {
                debugLineRenderer.sharedMaterial = debugLineMaterialGreen;
                debugLineRenderer.SetPositions(new Vector3[] { transform.position, TargetPosition });
            }
        }
    }
}
