using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 1.0f;
    public Vector3 forward;

    const float buf = 50.0f; // The center of bullets can be this many pixels offscreen before they despawn
    void Update() {
        if (Time.timeScale == 0)
            return;
        transform.position = transform.position + forward * Time.deltaTime * speed;

        Vector3 screen_space = Camera.main.WorldToScreenPoint(transform.position);
        if (screen_space.x > Screen.width+buf || screen_space.x < 0f-buf || screen_space.y > Screen.height+buf || screen_space.y < 0f-buf) {
            Destroy(gameObject);
        }
    }
}