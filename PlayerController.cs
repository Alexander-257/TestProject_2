using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;

    [SerializeField] float verticalInput;
    [SerializeField] float speed;
    [SerializeField] bool isPauseActive;
    [SerializeField] Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(gameManager.isGameActive) {
            verticalInput = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.W)) {
                transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            }

            animator.SetFloat("speed", GetComponent<PlayerController>().verticalInput);
            Border();
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            gameManager.PauseGame();
        }

        if(transform.position.z >= 230.0f) {
            gameManager.EndGame();
        }
    }

    private void Border() {
        if (transform.position.x > 4) {
            transform.position = new Vector3(4.0f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -4) {
            transform.position = new Vector3(-4.0f, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Area")) {
            //Destroy(gameObject);
            gameManager.GameOver();
        }
    }
}
