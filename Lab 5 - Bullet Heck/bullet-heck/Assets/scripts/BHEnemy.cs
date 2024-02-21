using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHEnemy : MonoBehaviour {
    public Vector2 moveDirection;
    public float speed = 5f;

    public GameObject bullet;
    public float shootGate;
    public float shootDelay;
    public float angleMoveSpeed = 10f;

    private float angle;

    void Start() {
        shootGate = Time.time + shootDelay;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(moveDirection.x, moveDirection.y, 0f) * Time.deltaTime * speed;

        if(this.transform.position.y < -8f) {
            Vector3 newPos = this.transform.position;
            newPos.y = 8f;
            this.transform.position = newPos;
        }
        if(shootGate < Time.time) {
            shootGate = Time.time + shootDelay;

            GameObject b = Instantiate(bullet, this.transform.position, this.transform.rotation);
            b.GetComponent<BHBullet>().speed = 10f;
            b.transform.right = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;

            angle += angleMoveSpeed;
        }
    }
}
