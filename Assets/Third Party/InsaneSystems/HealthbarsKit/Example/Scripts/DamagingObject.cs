using UnityEngine;

namespace InsaneSystems.HealthbarsKit.Example
{
	/// <summary> Simple auto-damage component for example scene. Does periodic damage to any object which have this component and Damageable component.</summary>
	public class DamagingObject : MonoBehaviour
	{
		[SerializeField] float damageValue = 5f;
		Damageable damageable;

		float timer;

		private void Start()
		{
			damageable = GetComponent<Damageable>();
		}

		void Update()
		{
			if (timer > 0)
			{
				timer -= Time.deltaTime;
				return;
			}

			if (damageable)
				damageable.TakeDamage(damageValue);

			timer = 1f;
		}
	}
}