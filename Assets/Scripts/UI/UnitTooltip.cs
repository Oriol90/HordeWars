using UnityEngine;
using TMPro;

public class UnitTooltip : MonoBehaviour
{
    public static UnitTooltip Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI statsText;
    private RectTransform tooltipRect;
    
    void Awake()
    {
        Instance = this;
        tooltipRect = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void ShowTooltip(UnitPO unit, Vector2 position)
    {
        nameText.text = unit.UnitType.ToString();
        statsText.text = $"Salud: {unit.Stats.Health}\n" +
                        $"Ataque: {unit.Stats.Attack}\n" +
                        $"Vel. Ataque: {unit.Stats.AttackSpeed}\n" +
                        $"Defensa: {unit.Stats.Defense}\n" +
                        $"Resist. Oscuridad: {unit.Stats.DarkResist}\n" +
                        $"Vel. Movimiento: {unit.Stats.MoveSpeed}\n" +
                        $"Fe: {unit.Stats.Faith}\n";


        tooltipRect.position = position;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}