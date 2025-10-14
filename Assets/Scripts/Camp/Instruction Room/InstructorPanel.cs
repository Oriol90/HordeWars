using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstructorPanel : MonoBehaviour
{
    public static InstructorPanel Instance;

    [Header("Referencias UI")]
    public TextMeshProUGUI health;
    public TextMeshProUGUI defense;
    public TextMeshProUGUI darkResist;
    public TextMeshProUGUI faith;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI attackSpeed;
    public TextMeshProUGUI moveSpeed;
    public TextMeshProUGUI mastery1;
    public TextMeshProUGUI mastery2;

    private void Awake()
    {
        Instance = this;  // Singleton simple
    }

    // public void ShowInstructor(InstructorData instructor)
    // {
    //     SetValueText(health, instructor.stats.health);
    //     SetValueText(defense, instructor.stats.defense);
    //     SetValueText(darkResist, instructor.stats.darkResist);
    //     SetValueText(faith, instructor.stats.faith);
    //     SetValueText(attack, instructor.stats.attack);
    //     SetValueText(attackSpeed, instructor.stats.attackSpeed);
    //     SetValueText(moveSpeed, instructor.stats.moveSpeed);
    //     if (instructor.mastery.Count > 0)
    //         mastery1.text = instructor.mastery[0].ToString();
    //     if (instructor.mastery.Count > 1)
    //         mastery2.text = instructor.mastery[1].ToString();
    // }

    private void SetValueText(TextMeshProUGUI textComponent, float value)
    {
        textComponent.text = value.ToString("0") + "%";

        if (value > 0)
            textComponent.color = Color.green;
        else if (value < 0)
            textComponent.color = Color.red;
        else
            textComponent.color = Color.black;
    }
}
