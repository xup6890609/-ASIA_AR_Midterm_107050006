using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 [Header("小黑")]
 public Transform Black;

 [Header("小白")]
 public Transform White;

 [Header("虛擬搖桿")]
 public FixedJoystick Joystick;

 [Header("旋轉速度"),Range(0.5f,10f)]
 public float turn = 1f;

 [Header("縮放"), Range(1f, 5f)]
 public float size = 1f;


 private void Start()
 {
  print("開始執行中...");
 }
 private void Update()
 {
  print("更新");
  print(Joystick.Vertical);
  Black.Rotate(0,Joystick.Horizontal*turn,0);
  White.Rotate(0, Joystick.Horizontal*turn, 0);
  Black.localScale += new Vector3(1, 1, 1) * Joystick.Vertical * size;
  White.localScale += new Vector3(1, 1, 1) * Joystick.Vertical * size;
    }

}
