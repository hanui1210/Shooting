using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public float moveSpeed = 1;
    public Animator animator;
    public GameObject playerBullerPrefab;
  

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("총알발사");
            // 프리팹의 복제품을 만들어냄
            GameObject playerBullerGo = Object.Instantiate(playerBullerPrefab);
            Vector3 targetPosition = this.transform.position;
            targetPosition.y += 0.798f;

            // 위치를 재설정
            playerBullerGo.transform.position = targetPosition;

        }
    }
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // Debug.Log($"{h},{v}"); // 방향
        if (h == 0)
        {
            animator.SetInteger("state", 0);
        }
        else if (h == 1)
        {
            animator.SetInteger("state", 1);
        }
        else if (h == -1)
        {
            animator.SetInteger("state", 2);
        }
        Vector3 dir = new Vector3(h, v, 0); //방향
        //백터의 정류하(단위벡터)
        Vector3 movement = dir.normalized * this.moveSpeed * Time.deltaTime;

        // 방향 * 속도 * 시간
        this.transform.Translate(movement); // 위치

    }
    


}
