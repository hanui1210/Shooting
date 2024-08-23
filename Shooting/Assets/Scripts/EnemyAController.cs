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
        //    yield return null; // 다음프레임으로 넘어감
        //    yield return new WaitForSeconds(1f); // 1초있다가 다음프레임으로 넘어감
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
        
        Debug.Log(collision.gameObject.name); // 확인용
        if(collision.gameObject.name == "PlayerBullet(Clone)")
        {
            Object.Destroy(collision.gameObject);  //플레이어게임오브젝트가 제거됨
            StartCoroutine(this.CoDestroy()); //내가 붙어있는 게임 오브젝트 제거
        }

    }
    IEnumerator CoDestroy(float delay = 1f)
    {
        yield return new WaitForSeconds(delay);
        Object.Destroy(this.gameObject);
    }
}
