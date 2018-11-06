using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = false;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.zero);
        count = 0;
        SetCountText();
        winText.text = "";
    }
    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, -Input.acceleration.z);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
}
