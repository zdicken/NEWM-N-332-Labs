using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHPlayer : MonoBehaviour {
    public float speed = 10f;

    void Update() {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        this.transform.position += move * speed * Time.deltaTime;
    }
}
