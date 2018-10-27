using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public float BulletSpeed = 200f;
    public float AttackSpeed = 0.7f;

    public Rigidbody2D projectile;

    public Transform UpLauncher;
    public Transform DownLauncher;
    public Transform LeftLauncher;
    public Transform RightLauncher;

    private Vector3 direction;
    private bool IsAttackReady = true;
    private float CurrentAttack;

    public void Start()
    {
        this.CurrentAttack = this.AttackSpeed;
    }

    public void FixedUpdate()
    {
        if (IsAttackReady)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = UpLauncher.up;
                this.Shoot(direction, UpLauncher);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = LeftLauncher.right;
                this.Shoot(direction, LeftLauncher);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = RightLauncher.right * -1;
                this.Shoot(direction, RightLauncher);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = DownLauncher.up * -1;
                this.Shoot(direction, DownLauncher);
            }
        }
        else
        {
            if (this.CurrentAttack <= 0)
            {
                this.IsAttackReady = true;
                this.CurrentAttack = this.AttackSpeed;
            }
            else
            {
                this.CurrentAttack -= Time.deltaTime;
            }
        }
    }

    private void Shoot(Vector3 direction, Transform launcher)
    {
        Rigidbody2D projectileInstance;
        projectileInstance = Instantiate(projectile, launcher.position, Quaternion.identity);
        projectileInstance.AddForce(direction * this.BulletSpeed);
        IsAttackReady = false;
    }
}