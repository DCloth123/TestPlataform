using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    public bool jump;
    public float jumpForce;
    public Rigidbody _rigidbody;
    public Animator _animationController;
    public Transform _InitialPosition;
  


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animationController.SetTrigger("Jumping");
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            transform.position = _InitialPosition.position;
        }
    }

    public void Move()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, moveVertical * speed * Time.deltaTime);
        transform.Rotate(0, moveHorizontal, 0 * turnSpeed * Time.deltaTime);
    }
}
