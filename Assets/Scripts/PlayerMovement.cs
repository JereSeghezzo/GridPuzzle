using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 private GameObject[] Obstacles;
 private GameObject[] Boxes;

 private bool ReadyToMove;

 void Start() 
 {
   Obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
   Boxes = GameObject.FindGameObjectsWithTag("Boxes");
 }

 void Update()
 {
  Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
  moveinput.Normalize();

  if (moveinput.sqrMagnitude > 0.5)
  {
    if(ReadyToMove)
    {
        ReadyToMove = false;
        Move(moveinput);
    }
  }
  else
  {
    ReadyToMove = true;
  }
 }

 public bool Move(Vector2 direction)
 {
    if(Mathf.Abs(direction.x) < 0.5)
    {
        direction.x = 0;
    }
    else
    {
      direction.y = 0;     
    }
    direction.Normalize();

    if(Blocked(transform.position,direction))
    {
        return false;
    }
    else
    {
        transform.Translate(direction);
        return true;
    }
 }

 public bool Blocked(Vector3 position, Vector2 direction)
 {
  Vector2 newpos = new Vector2(position.x, position.y) + direction;

  foreach (var obj in Obstacles)
  {
    if(obj.transform.position.x == newpos.x && obj.transform.position.y == newpos.y)
    {
      return true;
    }
  }
 
  foreach (var box in Boxes)
  {
    if(box.transform.position.x == newpos.x && box.transform.position.y == newpos.y)
    {
      Push objpush = box.GetComponent<Push>();
      if(objpush && objpush.Move(direction))
      {
        return false;
      }
      else
      {
        return true;
      }
    }
  }
  return false;
 }
}
