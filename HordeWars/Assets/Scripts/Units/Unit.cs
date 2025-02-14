using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public float speed = 2f;
    public float attackRange = 1f;
    public float attackCooldown = 1.5f;
    public int damage = 10;
    public float detectionRadius = 10f;
    public int maxHealth = 100;
    public GameObject healthBarPrefab;

    private int currentHealth;
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject targetEnemy;
    private bool isAttacking = false;
    private HealthBar healthBarInstance;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        if (healthBarPrefab != null)
        {
            GameObject healthBarObject = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
            healthBarInstance = healthBarObject.GetComponent<HealthBar>();
            healthBarInstance.SetMaxHealth(maxHealth);

            Canvas canvas = healthBarObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();
            canvasRect.sizeDelta = new Vector2(200, 100); // Ajustar el tamaño del canvas según sea necesario

            RectTransform healthBarRect = healthBarObject.GetComponent<RectTransform>();
            healthBarRect.SetParent(canvasRect, false);
            healthBarRect.localPosition = new Vector3(0, 1, 0);
        }
    }

    protected virtual void Update()
    {
        if (targetEnemy == null)
        {
            FindClosestEnemy();
        }
        else
        {
            MoveTowardsEnemy();
        }

        if (healthBarInstance != null)
        {
            healthBarInstance.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0));
        }
    }

    void MoveTowardsEnemy()
    {
        if (targetEnemy == null || isAttacking) return;

        Debug.Log("Moviendo hacia el enemigo: " + targetEnemy.name);
        
        Vector2 direction = (targetEnemy.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetEnemy.transform.position) <= attackRange)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool(GC.ANIM_ATTACK, true);
        yield return new WaitForSeconds(attackCooldown);
        if (targetEnemy != null)
        {
            targetEnemy.GetComponent<Unit>().TakeDamage(damage);
        }
        animator.SetBool(GC.ANIM_ATTACK, false);
        isAttacking = false;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (healthBarInstance != null)
        {
            healthBarInstance.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void FindClosestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        Debug.Log("Número de enemigos detectados: " + enemiesInRange.Length);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (Collider2D collider in enemiesInRange)
        {
            if (!collider.CompareTag(tag))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                Debug.Log("Enemigo detectado: " + collider.gameObject.name + " a una distancia de: " + distance);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestEnemy = collider.gameObject;
                }
            }
        }

        if (nearestEnemy != null)
        {
            targetEnemy = nearestEnemy;
            Debug.Log("Enemigo más cercano encontrado: " + targetEnemy.name);
        }
        else
        {
            Debug.Log("No se encontraron enemigos cercanos.");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}