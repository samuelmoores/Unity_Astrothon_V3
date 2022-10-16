using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class PlayerHealth : MonoBehaviour
{

	//public int health = 100;

	public GameObject deathEffect;

	public HealthBar healthBar;

	public int maxHealth = 100;
	public int currentHealth;

    private void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		FindObjectOfType<AudioManager>().Play("PlayerScream");

		healthBar.SetHealth(currentHealth);

		StartCoroutine(DamageAnimation());

		if (currentHealth <= 0)
		{
			Debug.Log("PLAYER DIED");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}

}
