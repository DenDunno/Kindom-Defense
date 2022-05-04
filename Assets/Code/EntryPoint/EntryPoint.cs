using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private EnemiesFactory _enemiesFactory;

    private void Start()
    {
        _enemiesFactory.LoadEnemies();
    }
}