using System;
using UnityEngine;

public class Gem : MonoBehaviour
{

    [HideInInspector]
    public Vector2Int posIndex;
    [HideInInspector]
    public Board board;
    
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    
    private bool mousePressed;
    private float swipeAngle = 0f;

    private void Update()
    {
        if (mousePressed && Input.GetMouseButtonUp(0))
        {
            mousePressed = false;
            firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CalculateAngle();
        }
    }
    
    public void SetupGem(Vector2Int pos, Board theboard)
    {
        posIndex = pos;
        board = theboard;
    }

    private void OnMouseDown()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePressed = true;
    }

    private void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x);
        swipeAngle = swipeAngle * Mathf.Rad2Deg;
        Debug.Log(swipeAngle);
    }
}
