using UnityEngine;

public class EnemyTracker : MonoBehaviour
{

    private GameObject enemy;
    private bool start = false;

    public void SetEnemy(GameObject o)
    {
        enemy = o;
        start = true;
    }

    void Update()
    {
        if (!start) return;

        if (enemy == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (enemy.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
