using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Script : MonoBehaviour
{
    public Status status;

    public float watk;

    public float cooltime;
    public float damage;
    public float shootspeed;
    public float range;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        // 시전 지점
        position = transform.position;
        damage = status.stat.ATK.Final * watk;
    }

    // Update is called once per frame
    void Update()
    {
        // 이동
        GetComponent<Rigidbody2D>().velocity = transform.right * shootspeed;

        //사거리
        if (Vector3.Distance(transform.position, position) > range)
        {
            Destroy(gameObject);
        }
    }
    // 데미지
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Status>().getDamage(damage);
        }
    }

}
