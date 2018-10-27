using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int NumberOfProjectiles;
    public float ProjectileSpeed;
    public GameObject ProjectilePrefab;
    public float SecondForShooting = 1;
    
    public float AngleRotation = 0;

    [Header("Private Variables")]
    private Vector3 StartPoint;
    private const float Radius = 1f;

    private float TimeBeforeBullet = 0;

    private float test = 0;
    
    private void Update()
    {
        if (this.TimeBeforeBullet > SecondForShooting)
        {
            StartPoint = transform.GetChild(0).position;
            this.SpawnProjectile(this.NumberOfProjectiles);

            this.TimeBeforeBullet = 0;
        }

        TimeBeforeBullet += Time.deltaTime;
    }

    private void SpawnProjectile(int number)
    {
        float angleStep = 360 / NumberOfProjectiles;
        float angle = 0;

        for (int i = 0; i <= NumberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = StartPoint.x + Mathf.Sin((angle * Mathf.PI + test) / 180) * Radius;
            float projectileDirYPosition = StartPoint.y + Mathf.Cos((angle * Mathf.PI + test) / 180) * Radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0f);
            Vector3 projectileMoveDirection = (projectileVector - StartPoint).normalized * ProjectileSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, StartPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0);

            angle += angleStep;
        }
        test += this.AngleRotation;
    }
}