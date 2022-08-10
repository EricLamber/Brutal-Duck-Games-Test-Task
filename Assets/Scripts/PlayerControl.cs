using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float Power = 10000f;
    [SerializeField] private float DragLimit = 0.5f;
    [SerializeField] private float LineLinbgh = 20f;

    private Camera cam;
    private Rigidbody rb;
    private LineRenderer lr;

    private Vector3 dragStartPos;
    private Vector3 PlayerPosToReturn;
    private Vector3 CurrentDragPower;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        PlayerPosToReturn = transform.position;
    }

    private void FixedUpdate()
    {
        if (rb.velocity == new Vector3(0, 0, 0))
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                DragLogic(touch);
            }

            PlayerPosToReturn = transform.position;
        }
    }

    private void DragLogic(Touch touch)
    {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    DragStart(touch);
                    break;

                case TouchPhase.Moved:
                    Dragging(touch);
                    break;

                case TouchPhase.Ended:
                    DragRealease(touch);
                    break;

                default:
                    break;
            }
    }

    private void DragStart(Touch touch)
    {
        dragStartPos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
        
        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);
    }

    private void Dragging(Touch touch)
    {
        var draggingPos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));

        CurrentDragPower = draggingPos - dragStartPos;

        lr.positionCount = 2;

        draggingPos = (dragStartPos - draggingPos) * LineLinbgh;
        if (draggingPos.z < 0) draggingPos = new Vector3(draggingPos.x, draggingPos.y, 0);
        draggingPos += transform.position;
        lr.SetPosition(1, new Vector3(draggingPos.x, transform.position.y, draggingPos.z));
    }

    private void DragRealease(Touch touch)
    {
        lr.positionCount = 0;

        var dragReleasePos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));

        var force = (dragStartPos - dragReleasePos);
        if (force.y < 0) force = new Vector3(force.x, 0, force.z);
        if (force.y > DragLimit) force = new Vector3(force.x, DragLimit, force.z);
        if (force.x > DragLimit) force = new Vector3(DragLimit, force.y, force.z);
        if (force.x < -DragLimit) force = new Vector3(-DragLimit, force.y, force.z);
        force *= Power;
        force += transform.position;
        
        rb.AddForce(new Vector3(force.x, 0, force.y));
    }

    public void Returning()
    {
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = PlayerPosToReturn;
    }

    public Vector3 GetCurrentPower() { return CurrentDragPower; }
}
