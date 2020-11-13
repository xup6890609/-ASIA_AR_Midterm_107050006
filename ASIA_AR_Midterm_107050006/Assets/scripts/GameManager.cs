using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
// 標題語法 = [Header("名稱")]
 [Header("小黑")]
 public Transform Black;

 [Header("小白")]
 public Transform White;

 [Header("虛擬搖桿")]
 public FixedJoystick Joystick;

 [Header("旋轉速度"),Range(0.5f,10f)]
 public float turn = 1f;

 [Header("縮放"), Range(1f, 3f)]
 public float size = 1f;

    [Header("小黑動畫元件")]
    public Animator aniBlack;

    [Header("小白動畫元件")]
    public Animator aniWhite;

// 開始事件
    private void Start()
 {
  print("開始執行中...");
 }
// 更新事件
 private void Update()
 {
  print("更新");
  print(Joystick.Vertical);

// 搖桿縮放、旋轉
  Black.Rotate(0,Joystick.Horizontal*turn,0);
  White.Rotate(0, Joystick.Horizontal*turn, 0);

// 縮放語法:模型.尺寸= 新三維向量(1,1,1)*虛擬搖桿垂直方向
  Black.localScale += new Vector3(1, 1, 1) * Joystick.Vertical * size;
  White.localScale += new Vector3(1, 1, 1) * Joystick.Vertical * size;

// 夾住語法:模型.尺寸= 新三維向量(1,1,1)*Mathf.Clamp(模型x軸,最小值,最大值)
  Black.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(Black.localScale.x, 1f, 5f);
  White.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(White.localScale.x, 1f, 5f);
    }

// 讓按鈕跟程式溝通:
// [第一種] aniName.SetTrigger("觸發條件");
// public void Run()
// {
// print("跑步");
// aniBlack.SetTrigger("跑觸發");
// aniWhite.SetTrigger("跑觸發");
// }
// [第二種](使用參數)
public void PlayAnimation(string aniName)
{ 
 print(aniName);
 aniBlack.SetTrigger(aniName);
 aniWhite.SetTrigger(aniName);
}
}
