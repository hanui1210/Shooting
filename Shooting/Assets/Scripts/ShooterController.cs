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
            Debug.Log("�Ѿ˹߻�");
            // �������� ����ǰ�� ����
            GameObject playerBullerGo = Object.Instantiate(playerBullerPrefab);
            Vector3 targetPosition = this.transform.position;
            targetPosition.y += 0.798f;

            // ��ġ�� �缳��
            playerBullerGo.transform.position = targetPosition;

        }
    }
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // Debug.Log($"{h},{v}"); // ����
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
        Vector3 dir = new Vector3(h, v, 0); //����
        //������ ������(��������)
        Vector3 movement = dir.normalized * this.moveSpeed * Time.deltaTime;

        // ���� * �ӵ� * �ð�
        this.transform.Translate(movement); // ��ġ

    }
    


}
