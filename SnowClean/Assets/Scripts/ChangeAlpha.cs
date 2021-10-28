using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlpha : MonoBehaviour
{
    Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        //renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
    }


}
