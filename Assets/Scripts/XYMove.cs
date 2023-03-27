using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYMove : MonoBehaviour
{
    public Texture2D crosshair;
    private Vector3 viewPos;
    private float xySpeed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(crosshair, new Vector2(), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        LocalMove(Input.mousePosition);
        LocalRotate(Input.mousePosition);
        viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -11, 11);
        viewPos.y = Mathf.Clamp(viewPos.y, -1, 11);
        transform.position = viewPos;
    }

    void LocalMove(Vector2 mousePosition)
    {
        mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);
        Vector2 playerPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 direction = mousePosition - playerPosition;
        transform.position += new Vector3(direction.x, direction.y, 0) * xySpeed;
    }

    void LocalRotate(Vector3 mousePosition)
    {
        mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);
        mousePosition.x = 23 * mousePosition.x - 11.5f;
        mousePosition.y = 13 * mousePosition.y - 6.5f;
        mousePosition.z = 10;
        transform.rotation = Quaternion.LookRotation(mousePosition);
    }

}
