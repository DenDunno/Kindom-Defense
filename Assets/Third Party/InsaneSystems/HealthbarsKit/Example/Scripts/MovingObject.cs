using UnityEngine;

namespace InsaneSystems.HealthbarsKit.Example
{
	/// <summary> Simple moving object code for example scene. </summary>
	public class MovingObject : MonoBehaviour
	{
		void Update()
		{
			transform.position += transform.forward * Time.deltaTime;
		}
	}
}