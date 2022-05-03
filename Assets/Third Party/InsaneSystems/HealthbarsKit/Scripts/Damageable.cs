using InsaneSystems.HealthbarsKit.UI;
using UnityEngine;

namespace InsaneSystems.HealthbarsKit
{
	/// <summary>This component allows to make any game object having health and its own healthbar. Use this in your game or you can make your custom class, using its code as template. </summary>
	public class Damageable : MonoBehaviour
	{
		public event HealthbarsController.HealthChangedAction healthChangedEvent;

		[SerializeField] [Range(0.1f, 1000f)] float maxHealth = 100;
		float health;

		void Awake()
		{
			health = maxHealth;
		}

		void Start()
		{
			AddHealthbarToThisObject();
		}

		void AddHealthbarToThisObject()
		{
			var healthBar = HealthbarsController.instance.AddHealthbar(gameObject, maxHealth);
			healthChangedEvent += healthBar.OnHealthChanged; // setting up event to connect healthbar with this damageable. Now every time when it will take damage, healthbar will be updated.

			OnHealthChanged();
		}

		void OnHealthChanged()
		{
			if (healthChangedEvent != null)
				healthChangedEvent(health);
		}

		public void TakeDamage(float damage)
		{
			health = Mathf.Clamp(health - damage, 0, maxHealth);

			OnHealthChanged();

			if (health == 0)
				Die();
		}

		public void Die()
		{
			Destroy(gameObject);
		}
	}
}