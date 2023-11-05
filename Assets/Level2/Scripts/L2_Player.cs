using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Player : MonoBehaviour
{
    public float JumpSpeed = 1f;
    public float backSpeed = 0.5f;
    public float directSpeed = 3f;

    private Rigidbody rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = rb.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PlayFlySound();
            MoveUp();
        }

        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-backSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(directSpeed);
        }
    }

    private void PlayFlySound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void MoveUp()
    {
        rb.freezeRotation = true;
        rb.AddRelativeForce(Vector3.up * JumpSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }

    private void ApplyRotation(float speed)
    {
        //rb.AddRelativeForce(directSpeed * Time.deltaTime, 0, 0);
        Debug.Log($"F: {Vector3.back}");
        Vector3 fwd = Vector3.back * speed * Time.deltaTime;
        Debug.Log($"D: {fwd}");
        transform.Rotate(fwd);
    }
}
