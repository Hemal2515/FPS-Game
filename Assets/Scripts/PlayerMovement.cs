using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator shotgunAnimator;

    public Camera mainCam;
    public AudioSource gunFire;
    public AudioSource reloadGun;

    public float currentHealth;
    public int health = 100;
    public Text healthAmount;
    public int damage = 51;

    private float speed = 12f;
    private float gravity = -9.81f;
    private float jumpHeight = 3f;

    Vector3 velocity;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthAmount.text = currentHealth.ToString();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        if(Input.GetMouseButtonDown(0))
        {
            shotgunAnimator.SetTrigger("Fire");
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    public void TakeDamage(float amount)
    {

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void Death()
    {

        SceneManager.LoadScene("GameOver");
        
    }

    void BulletFired()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {

            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<EnemyAttack>().Damage(damage);
            }
        }
    }
    void GunSound()
    {
        reloadGun.Stop();
        gunFire.Play();
    }
    void ReloadSound()
    {
        gunFire.Stop();
        reloadGun.Play();
    }
}
