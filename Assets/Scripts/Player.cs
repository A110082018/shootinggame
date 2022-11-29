using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // move
    CharacterController controller;
    public float speed = 3;
    public Joystick joyStick;

    // fire
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject focusEnemy;



    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
        FindEnemy();
        Fire();
        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        
        if (dir.magnitude > 0.1f)
        {
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        Vector3 move = dir * speed;

        if (!controller.isGrounded)
        {
            move.y = -9.8f * 100 * Time.deltaTime;
        }

        controller.Move(move * speed * Time.deltaTime);
        */
    }
    public void PlayerMove()
    {
        // 取得虛擬搖桿輸入
        float h = joyStick.Horizontal;
        float v = joyStick.Vertical;
        // 合成方向向量
        Vector3 dir = new Vector3(h, 0, v);

        // 調整角色面對方向
        // 判斷方向向量長度是否大於 0.1（代表有輸入）
        if (dir.magnitude > 0.1f)
        {
            // 將方向向量轉為角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            // 使用 Lerp 漸漸轉向
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        // 移動角色位置
        controller.Move(dir * speed * Time.deltaTime);

        // 地心引力 (y)
        if (!controller.isGrounded)
        {
            dir.y = -98f * 1000 * Time.deltaTime;
        }

    }

    public void FindEnemy()
    {
        // find target
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        float miniDist = 9999;
        foreach (GameObject enemy in enemys)
        {
            float d = Vector3.Distance(transform.position, enemy.transform.position);

            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = enemy;
            }
        }
        //focus enemy
    
        if (focusEnemy)
        {
            var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
        }
    }

    public void Fire()
    {
        if (Input.GetKeyDown("Space"))
        {
            Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
        }
    }

}
