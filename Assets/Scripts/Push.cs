using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
 private GameObject[] Obstacles;
 private GameObject[] Boxes;

 public bool m_OnCross;

 void Start() 
 {
   Obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
   Boxes = GameObject.FindGameObjectsWithTag("Boxes");
 }

  
 void Update()
 {
        
 }

 public bool Move(Vector2 direction)
 {
  if(ObjToBlocked(transform.position, direction))
  {
    return false;
  }
  else
  {
    transform.Translate(direction);
    TestForOnCross();
    return true;
  }
 }

 public bool ObjToBlocked(Vector3 position, Vector2 direction)
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
      return true;
    }
  }
  return false;
 }

 void TestForOnCross()
 {
    GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
    foreach (var cross in crosses)
    {
        if(transform.position.x == cross.transform.position.x && transform.position.y == cross.transform.position.y)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            m_OnCross = true;
            return;
        }
    }
    GetComponent<SpriteRenderer>().color = Color.white;
    m_OnCross = false;
 }
}
