using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAController : MonoBehaviour
{
    private void Start()
    {
        
       StartCoroutine(CoFade());
        //Color color = new Color(1, 0, 0, 1);
        //sr.color = color;
    }
    private void Fade()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            Debug.Log(alpha);
            Color color = new Color(1, 0, 0, alpha);
            sr.color = color;
        }

    }
    IEnumerator CoFade()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        //for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        //{
        //    Debug.Log(alpha);
        //    Color color = new Color(1, 1, 1, alpha);
        //    sr.color = color;
        //    yield return null; // �������������� �Ѿ
        //    yield return new WaitForSeconds(1f); // 1���ִٰ� �������������� �Ѿ
        //}
        float alpha = 1f;
        while (true)
        {
            if (alpha >= 0)
            {
                break;
            }

            Color color = new Color(1, 1, 1, alpha);
            sr.color = color;
            alpha -= 0.1f;
            Debug.Log(alpha);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log(collision.gameObject.name); // Ȯ�ο�
        if(collision.gameObject.name == "PlayerBullet(Clone)")
        {
            Object.Destroy(collision.gameObject);  //�÷��̾���ӿ�����Ʈ�� ���ŵ�
            StartCoroutine(this.CoDestroy()); //���� �پ��ִ� ���� ������Ʈ ����
        }

    }
    IEnumerator CoDestroy(float delay = 1f)
    {
        yield return new WaitForSeconds(delay);
        Object.Destroy(this.gameObject);
    }
}
