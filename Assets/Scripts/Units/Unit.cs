using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public Race Race { get; set; }
    public UnitType UnitType { get; set; }
    public float Experience { get; set; }
    public int Level { get; set; }
    public BaseStats BaseStats { get; set; }
    public UnitStats Stats { get; set; }
    public Item EquippedItem { get; set; }

    public float attackRange = 1f;
    public float detectionRadius = 5f; // Añadido para la detección de enemigos
    public GameObject healthBarCanvasPrefab; // Prefab del Canvas con la barra de salud

    protected GameObject prefab;
    private int currentHealth;
    private Animator animator;
    private GameObject targetEnemy;
    private bool isAttacking = false;
    private HealthBar healthBarInstance; // Instancia de la barra de salud

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = Stats.Health;

        // Instanciar el Canvas con la barra de salud como hijo de la unidad
        if (healthBarCanvasPrefab != null)
        {
            GameObject healthBarCanvasObject = Instantiate(healthBarCanvasPrefab, transform);
            healthBarInstance = healthBarCanvasObject.GetComponentInChildren<HealthBar>();
            healthBarInstance.SetMaxHealth(Stats.Health);

            // Ajustar la posición del Canvas
            RectTransform healthBarCanvasRect = healthBarCanvasObject.GetComponent<RectTransform>();
            healthBarCanvasRect.localPosition = new Vector3(0, 1, 0); // Ajusta la posición según sea necesario
        }

        // Iniciar la búsqueda de enemigos en intervalos
        InvokeRepeating(nameof(FindClosestEnemy), Random.Range(0.1f, 1f), 1f); // Buscar enemigos cada 1 segundo
    }

    protected virtual void Update()
    {
        if (targetEnemy != null)
        {
            MoveTowardsEnemy();
        }

        // Actualizar la posición del Canvas de la barra de salud
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
        transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, Stats.MoveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetEnemy.transform.position) <= attackRange)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool(GC.ANIM_ATTACK, true);
        yield return new WaitForSeconds(Stats.AttackSpeed);
        if (targetEnemy != null)
        {
            targetEnemy.GetComponent<Unit>().TakeDamage(Stats.Attack);
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
        // Implementar lógica de muerte (desactivar la unidad, reproducir animación, etc.)
        Destroy(gameObject);
    }

    void FindClosestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (Collider2D collider in enemiesInRange)
        {
            if (!collider.CompareTag(tag))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
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