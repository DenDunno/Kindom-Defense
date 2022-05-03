using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace InsaneSystems.HealthbarsKit
{
	public class ExampleController : MonoBehaviour
	{
		public static GameObject customHealthbarToSet;
		public static bool useCustomColors;
		public static Color maxColor;
		public static Color minColor;

		[SerializeField] List<GameObject> healthbarTemplatesDemo = new List<GameObject>();

		Camera cachedCamera;

		void Awake()
		{
			if (customHealthbarToSet || useCustomColors)
			{
				var healthbarsController = FindObjectOfType<UI.HealthbarsController>();

				if (customHealthbarToSet)
					healthbarsController.ChangeHealthbarTemplate(customHealthbarToSet);

				if (useCustomColors)
					healthbarsController.SetCustomColors(minColor, maxColor);
			}
		}

		void Start()
		{
			cachedCamera = Camera.main;
		}

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				var ray = cachedCamera.ScreenPointToRay(Input.mousePosition);

				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, 1000f))
				{
					var damageable = hit.collider.GetComponent<Damageable>();

					if (damageable)
						damageable.TakeDamage(10f);
				}
			}
		}

		public void OnResetButtonClick(bool fullReset = true)
		{
			if (fullReset)
			{
				customHealthbarToSet = null;
				useCustomColors = false;
			}

			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void OnHealthbarChangeButtonClick(int healthbarToSelect)
		{
			if (healthbarTemplatesDemo.Count <= healthbarToSelect)
				return;

			customHealthbarToSet = healthbarTemplatesDemo[healthbarToSelect];

			OnResetButtonClick(false);
		}

		public void OnSetDefaultColorSchemeClick()
		{
			useCustomColors = false;

			OnResetButtonClick(false);
		}

		public void OnHealthbarBlueColorButtonClick()
		{
			useCustomColors = true;
			minColor = new Color(1f, 0.35f, 0f);
			maxColor = new Color(0.17f, 0.35f, 1f);

			OnResetButtonClick(false);
		}

		public void OnHealthbarSingleColorButtonClick()
		{
			useCustomColors = true;
			minColor = maxColor = Color.green;

			OnResetButtonClick(false);
		}
	}
}