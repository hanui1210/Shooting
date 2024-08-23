using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBulletController : MonoBehaviour
{
    public float moveSpeed=1f;

    private void Start()
    {
        StartCoroutine(this.CoMove());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    this.transform.Translate(Vector3.up * this.moveSpeed*Time.deltaTime);


    //}
    IEnumerator CoMove()
    {
        while (true)
        {
            this.transform.Translate(Vector3.up * this.moveSpeed * Time.deltaTime);
            if (this.transform.position.y > 5.41f)
            {
                Object.Destroy(this.gameObject);
            }
            yield return null;
        }
    }
}
