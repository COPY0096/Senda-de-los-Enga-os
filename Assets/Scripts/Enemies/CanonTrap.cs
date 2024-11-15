using UnityEngine;

public class CanonTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] canonballs;
    private float cooldownTimer;

    [Header("SFX")]
    [SerializeField] private AudioClip canonSound;

    private void Attack()
    {
        cooldownTimer = 0;
        SoundManager.instance.PlaySound(canonSound);
        int canonballIndex = FindCanonball();
        canonballs[canonballIndex].transform.position = firePoint.position;
        Vector2 direction = firePoint.right; // Adjust the direction as needed
        canonballs[canonballIndex].GetComponent<EnemyProjectile>().ActivateProjectile(direction);
    }

    private int FindCanonball()
    {
        for (int i = 0; i < canonballs.Length; i++)
        {
            if (!canonballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }
}
