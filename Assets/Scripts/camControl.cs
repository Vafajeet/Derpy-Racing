using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{
    [SerializeField]
    private List<Transform> targets = new List<Transform>();

    public Vector3 offset;
    public float smooth = .5f;
    private Vector3 velocity;
    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform player4;
    public float minZoom = 40f;
    public float maxZoom = 10f;

    public float zoomLimiter = 50f;

    private Camera cam;

    private void Awake()
    {
        if (player1 != null)
            targets.Add(player1);

        if (player2 != null)
            targets.Add(player2);

        if (player3 != null)
            targets.Add(player3);

        if (player4 != null)
            targets.Add(player4);
    }
    private void Start()
    {
        cam = GetComponent<Camera>();

    }
    private void FixedUpdate()
    {

        if (targets.Count == 0)
            return;

        Move();
        Zoom();

    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smooth);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);

        }
        return bounds.size.x;
    }
    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].gameObject.activeInHierarchy == false)
            {
                targets.RemoveAt(i);
            }
            if (targets.Count > 1)
                bounds.Encapsulate(targets[i].position);

        }
        return bounds.center;
    }
}

