public class FelipePO : UnitData
{
    public FelipePO(int experience, Item item) : base(experience, item)
    {
        gender = Gender.Male;
        unitName = NamesDBStatic.GetRandomNameByGender(gender);
        race = Race.Human;
        unitType = UnitType.Felipe;
    }
}