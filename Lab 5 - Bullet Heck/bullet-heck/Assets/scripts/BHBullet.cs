using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHBullet : MonoBehaviour {
    public Vector2 moveDirection;
    public float speed = 5f;
    public float lifeSpan = 2f;

    private float lifeEnd;

    void Start() {
        lifeEnd = Time.time + lifeSpan;
    }

    void Update() {
        this.transform.position += this.transform.right * Time.deltaTime * speed;

        if(Time.time > lifeEnd) {
            Destroy(this.gameObject);
        }
    }
}
