using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    
    public Vector2Int posIndex;
    [HideInInspector]
    public Board board;
    
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    
    private bool mousePressed;
    private float swipeAngle = 0f;

    private Gem otherGem;
    
    public enum GemType {blue ,green,red,yellow,purple}

    public GemType type;

    public bool isMatched;
    
    private Vector2Int previousPosition;
    
    
    private void Update()
    {
        if (Vector2.Distance(transform.position, posIndex) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position,posIndex,board.gemSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(posIndex.x, posIndex.y, 0f);
            board.allGems[posIndex.x, posIndex.y] = this;
        }
        
        if (mousePressed && Input.GetMouseButtonUp(0))
        {
            mousePressed = false;
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        swipeAngle = swipeAngle * 180 / Mathf.PI;
        Debug.Log(swipeAngle);

        if (Vector3.Distance(firstTouchPosition, finalTouchPosition) > .5f)
        {
            MovePieces();
        }
    }

    private void MovePieces()
    {
        previousPosition = posIndex;
        
        if(swipeAngle < 45 && swipeAngle > -45 && posIndex.x < board.width - 1)
        {
            //Swiping Right
            otherGem = board.allGems[posIndex.x + 1, posIndex.y];
            otherGem.posIndex.x--;
            posIndex.x++;
        } else if (swipeAngle > 45 && swipeAngle <= 135 && posIndex.y < board.height - 1)
        {
            //Swiping Top
            otherGem = board.allGems[posIndex.x, posIndex.y + 1];
            otherGem.posIndex.y--;
            posIndex.y++;
        }
        else if (swipeAngle < -45 && swipeAngle >= -135 && posIndex.y > 0)
        {
            //Swiping bottom
            otherGem = board.allGems[posIndex.x, posIndex.y - 1];
            otherGem.posIndex.y++;
            posIndex.y--;
        } else if (swipeAngle > 135 || swipeAngle < -135 && posIndex.x > 0)
        {
            //swiging left
            otherGem = board.allGems[posIndex.x - 1, posIndex.y];
            otherGem.posIndex.x++;
            posIndex.x--;
        }

        board.allGems[posIndex.x, posIndex.y] = this;
        board.allGems[otherGem.posIndex.x, otherGem.posIndex.y] = otherGem;

        StartCoroutine(CheckMoveCoroutine());

    }

    public IEnumerator CheckMoveCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        
        board.matchFind.FindAllMatches();

        if (otherGem != null)
        {
            if (!isMatched && !otherGem.isMatched)
            {
                otherGem.posIndex = posIndex;
                posIndex = previousPosition;
                
                board.allGems[posIndex.x, posIndex.y] = this;
                board.allGems[otherGem.posIndex.x, otherGem.posIndex.y] = otherGem;
            }
        }
        
    }
    
    
}
