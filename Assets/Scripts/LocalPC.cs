using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LocalPC : MonoBehaviour
{
    [SerializeField] private float moveSpeed=10f;
    private Vector2 _moveVector;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rb.velocity = moveSpeed * Time.fixedDeltaTime * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }
}