using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysics : MonoBehaviour
{
    public LayerMask rockLayer;
    [Header("Options")]
    [Range(0.1f, 50.0f)]
    public float transitionSpeed = 15.0f;
    public bool isGrounded = false;
    [Header("Busy Places")]
    public bool objectOnTop = false;
    public bool objectOnBottom = false;
    public bool objectOnLeft = false;
    public bool objectOnRight = false;
    public bool objectOnTopLeft = false;
    public bool objectOnTopRight = false;
    public bool objectOnBottomLeft = false;
    public bool objectOnBottomRight = false;
    public bool objectOnLongRight = false;
    [Header("Movement")]
    public Vector3 objectNewPosition = Vector3.zero;
    private void Start()
    {
        //Time.timeScale = 0.1f;
        //
        objectNewPosition = transform.position;
    }
    private void LateUpdate()
    {
        Movement();

        if (transform.position != objectNewPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, objectNewPosition, transitionSpeed * Time.deltaTime);
        }
        
    }
    private void Movement()
    {
        if(!isGrounded && !objectOnBottom && transform.position == objectNewPosition)
        {
            objectNewPosition = transform.position + Vector3.down;
        }

        if(isGrounded && !objectOnTop && !objectOnBottomRight && !objectOnRight && !objectOnLongRight && !objectOnTopRight && transform.position == objectNewPosition)
        {
            objectNewPosition = transform.position + Vector3.right;
        }

        if (isGrounded && !objectOnTop && !objectOnBottomLeft && !objectOnLeft && !objectOnTopLeft && transform.position == objectNewPosition) 
        {
            objectNewPosition = transform.position + Vector3.left;
        }
    }
    private void FixedUpdate()
    {
        DetectTopObject();
        DetectBottomObject();
        //
        DetectLeftObject();
        DetectRightObject();
        //
        DetectTopLeftObject();
        DetectTopRightObject();
        //
        DetectBottomLeftObject();
        DetectBottomRightObject();
        //
        DetectLongRightObject();
    }
    private void DetectTopObject()
    {
        Vector3 startPoint = transform.position + new Vector3(0, 0.6f);
        Vector3 endPoint = startPoint + new Vector3(0, 0.5f);
        objectOnTop = false;

        Debug.DrawLine(startPoint, endPoint, Color.green);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint);

        if(hit)
        {
            objectOnTop = true;
        }
    }
    private void DetectBottomObject()
    {
        Vector3 startPoint = transform.position + new Vector3(0, -0.51f);
        Vector3 endPoint = startPoint + new Vector3(0, -0.5f);
        objectOnBottom = isGrounded = false;

        Debug.DrawLine(startPoint, endPoint, Color.red);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint);

        if (hit)
        {
            objectOnBottom = true;

            if(hit.distance <= 0)
            {
                isGrounded = true;
            }
        }
    }
    private void DetectLeftObject()
    {
        Vector3 startPoint = transform.position + new Vector3(-0.51f, 0);
        Vector3 endPoint = startPoint + new Vector3(-0.9f, 0);
        objectOnLeft = false;

        Debug.DrawLine(startPoint, endPoint, Color.blue);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint);

        if (hit)
        {
            objectOnLeft = true;
        }
    }
    private void DetectRightObject()
    {
        Vector3 startPoint = transform.position + new Vector3(0.51f, 0);
        Vector3 endPoint = startPoint + new Vector3(0.9f, 0);
        objectOnRight = false;

        Debug.DrawLine(startPoint, endPoint, Color.magenta);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint);

        if (hit)
        {
            objectOnRight = true;
        }
    }
    private void DetectTopLeftObject()
    {
        Vector3 startPoint = transform.position + new Vector3(-0.5f, 0.51f);
        Vector3 endPoint = startPoint + new Vector3(-0.5f, 0.5f);
        objectOnTopLeft = false;

        Debug.DrawLine(startPoint, endPoint, Color.white);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint, rockLayer);

        if (hit)
        {
            objectOnTopLeft = true;
        }
    }
    private void DetectTopRightObject()
    {
        Vector3 startPoint = transform.position + new Vector3(0.5f, 0.51f);
        Vector3 endPoint = startPoint + new Vector3(0.5f, 0.5f);
        objectOnTopRight = false;

        Debug.DrawLine(startPoint, endPoint, Color.white);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint, rockLayer);

        if (hit)
        {
            objectOnTopRight = true;
        }
    }
    private void DetectBottomLeftObject()
    {
        Vector3 startPoint = transform.position + new Vector3(-0.51f, -0.51f);
        Vector3 endPoint = startPoint + new Vector3(-0.5f, -0.5f);
        objectOnBottomLeft = false;

        Debug.DrawLine(startPoint, endPoint, Color.white);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint);

        if (hit)
        {
            objectOnBottomLeft = true;
        }
    }
    private void DetectBottomRightObject()
    {
        Vector3 startPoint = transform.position + new Vector3(0.51f, -0.51f);
        Vector3 endPoint = startPoint + new Vector3(0.5f, -0.5f);
        objectOnBottomRight = false;

        Debug.DrawLine(startPoint, endPoint, Color.white);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint);

        if (hit)
        {
            objectOnBottomRight = true;
        }
    }
    private void DetectLongRightObject()
    {
        Vector3 startPoint = transform.position + new Vector3(0.51f, 0);
        Vector3 endPoint = startPoint + new Vector3(1.5f, 0);
        objectOnLongRight = false;

        //Debug.DrawLine(startPoint, endPoint, Color.yellow);
        RaycastHit2D hit = Physics2D.Linecast(startPoint, endPoint, rockLayer);

        if (hit)
        {
            objectOnLongRight = true;
        }
    }
}
