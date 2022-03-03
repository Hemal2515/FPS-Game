using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public int decreseHealth = 5;
    public float damage = 5f;
    public int enemyHealth = 100;
    public int currHealth;
    public Animator animator;

    private GameObject spawner;
    private SpawnEnemy spawnEnemy;

    private GameObject player;
    private PlayerMovement playerMovement;
    public void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawnEnemy = spawner.GetComponent<SpawnEnemy>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        currHealth = enemyHealth;
    }
    public void DecresePlayerHealth()
    {
        playerMovement.TakeDamage(damage);
    }

    public void Damage(int damageAmount)
    {
        currHealth -= damageAmount;
        if (currHealth <= 0)
        {
            animator.SetTrigger("Die");
            StartCoroutine(DestroyEnemy());
        }
    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
        spawnEnemy.enemyCount -= 1;
    }
}
