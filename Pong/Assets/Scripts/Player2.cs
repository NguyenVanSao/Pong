using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float paketSpeed;
    [SerializeField] Vector2 paketDir;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical2");
        paketDir = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity = paketDir * paketSpeed * Time.deltaTime;
    }
}
