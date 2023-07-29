using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public float speed;
    public bool isMoving = true; // 添加开关状态，默认为 true，表示平台可以移动
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) // 仅当开关状态为 true 时，平台才会移动
        {
            if (Vector2.Distance(transform.position, posA.position) < 0.05f)
            {
                targetPos = posB.position;
            }
            if (Vector2.Distance(transform.position, posB.position) < 0.05f)
            {
                targetPos = posA.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    // 添加开关控制方法
    public void ToggleMovement()
    {
        isMoving = !isMoving;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}