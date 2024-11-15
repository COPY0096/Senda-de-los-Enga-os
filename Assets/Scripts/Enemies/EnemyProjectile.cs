using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifeTime;
    private Vector2 direction;

    public void ActivateProjectile(Vector2 _direction)
    {
        lifeTime = 0;
        direction = _direction.normalized;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(direction * movementSpeed);

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

#pragma warning disable 0108 // Disable warning for hiding inherited member
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        gameObject.SetActive(false);
    }
#pragma warning restore 0108 // Restore warning
}