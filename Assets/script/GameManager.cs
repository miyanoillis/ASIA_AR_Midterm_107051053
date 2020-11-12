using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("物件")]
    public Transform dg;
    public Transform gl;
    [Header("控制桿")]
    public FloatingJoystick floatingJoystick;
    [Header("速度"), Range(0.1f, 10f)]
    public float speed = 10f;
    [Header("大小"), Range(0.1f, 1f)]
    public float size = 0.01f;
    [Header("動畫元件")]
    public Animator animdg;
    public Animator animgl;

    private void Start()
    {
        print("start");
    }

    private void Update()
    {


        if (Mathf.Abs(floatingJoystick.Vertical) < 0.5f)
        {
            dg.Rotate(0, -floatingJoystick.Horizontal * speed, 0);
            gl.Rotate(0, -floatingJoystick.Horizontal * speed, 0);

        }
        if (Mathf.Abs(floatingJoystick.Horizontal) < 0.5f)
        {
            dg.localScale += new Vector3(1, 1, 1) * floatingJoystick.Vertical * size;
            gl.localScale += new Vector3(1, 1, 1) * floatingJoystick.Vertical * size;

        }

        dg.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(dg.localScale.x, 0.5f, 3.5f);
        gl.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(dg.localScale.x, 0.5f, 3.5f);

        print(floatingJoystick.Vertical + "," + floatingJoystick.Horizontal);
    }

    public void Playanim(string Name)
    {
        animdg.SetTrigger(Name);
        animgl.SetTrigger(Name);
    }

    public void quit()
    {
        Application.Quit();
    }
}
