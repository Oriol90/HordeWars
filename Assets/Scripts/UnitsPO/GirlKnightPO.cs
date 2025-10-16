public class GirlKnightPO : UnitData
{
    public GirlKnightPO(int experience, Item item) : base(experience, item)
    {
        gender = Gender.Female;
        unitName = NamesDBStatic.GetRandomNameByGender(gender);
        race = Race.Human;
        unitType = UnitType.GirlKnight;
    }
}