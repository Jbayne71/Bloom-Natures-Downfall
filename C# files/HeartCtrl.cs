using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCtrl : MonoBehaviour
{
    private Vector3 Startingpos = Vector3.zero; //where heart starts on its turn

    public float speed; //speed of heart
    public float Sensitivity;
    private Vector2 MovePos; //where heart moves to

    public float MaxX = 2;
    public float MaxY = 2;
    public float MinX = -2;
    public float MinY = -2;

    // Start is called before the first frame update
    void Start()
    {
        SetHeart();
    }

    public void SetHeart()
    {
        transform.position = Startingpos;
        MovePos = Startingpos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * Sensitivity;
        float vertical = Input.GetAxisRaw("Vertical") * Sensitivity;

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

        transform.position = Vector2.LerpUnclamped(transform.position, MovePos, speed * Time.deltaTime);
    }
}
