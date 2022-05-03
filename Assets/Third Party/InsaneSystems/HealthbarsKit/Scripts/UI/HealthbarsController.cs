using System.Collections.Generic;
using UnityEngine;

namespace InsaneSystems.HealthbarsKit.UI
{
	/// <summary> This class controls all healthbars on scene. </summary>
	public class HealthbarsController : MonoBehaviour
	{
		public delegate void HealthChangedAction(float newHealthValue);

		public static HealthbarsController instance { get; protected set; }

		public Camera cachedCamera { get; protected set; }

		public bool SetColorByHealthPecents { get { return setColorByHealthPercents; } }
		public bool UseHDRForBetterColoring	{ get { return useHDRForBetterColoring; } }
		public Color MinHealthColor	{ get { return minHealthColor; } }
		public Color MaxHealthColor	{ get { return maxHealthColor; } }

		public bool HideHealthbarsIfHealthFull { get { return hideHealthbarsIfHealthFull; } }

		List<Healthbar> allHealthbars = new List<Healthbar>();

		[SerializeField] Canvas canvasForHealthbars;
		[SerializeField] GameObject healthbarObjectTemplate;
		[SerializeField] bool setColorByHealthPercents;
		[SerializeField] Color minHealthColor = Color.red;
		[SerializeField] Color maxHealthColor = Color.green;
		[Tooltip("If selected, healthbar fill will better lerp between two colors, but it works correctly only with full-valued colors (like 255 0 0, 0 255 255, etc)")]
		[SerializeField] bool useHDRForBetterColoring = true;
		[Tooltip("If selected, healthbars for units with 100% of health will be hidden until them will take some damage.")]
		[SerializeField] bool hideHealthbarsIfHealthFull = false;

		void Awake()
		{
			instance = this;
			cachedCamera = Camera.main; // caching camera because Camera.main is expensive on maps with big objects count.
		}

		void Update()
		{
			for (int i = 0; i < allHealthbars.Count; i++)
				if (allHealthbars[i])
					allHealthbars[i].OnUpdate();
		}

		/// <summary> Use this to add healthbar for your characters objects. </summary>
		/// <param name="targetObject">Your character object which healthbar should be attached to.</param>
		/// <param name="targetMaxHealth">Your character max health value. Needed to correct calculations of healthbar percents.</param>
		public Healthbar AddHealthbar(GameObject targetObject, float targetMaxHealth)
		{
			var spawnedHealthbarObject = Instantiate(healthbarObjectTemplate, canvasForHealthbars.transform);
			var healthbar = spawnedHealthbarObject.GetComponent<Healthbar>();

			healthbar.SetupWithTarget(targetObject.transform, targetMaxHealth);

			allHealthbars.Add(healthbar);

			return healthbar;
		}

		public void ClearHealthbars()
		{
			for (int i = 0; i < allHealthbars.Count; i++)
				Destroy(allHealthbars[i].gameObject);

			allHealthbars.Clear();
		}

		void OnDestroy()
		{
			if (instance == this)
				instance = null;
		}

		public void ChangeHealthbarTemplate(GameObject newTemplate)
		{
			healthbarObjectTemplate = newTemplate;
		}

		public void SetCustomColors(Color minColor, Color maxColor)
		{
			minHealthColor = minColor;
			maxHealthColor = maxColor;
		}
	}
}