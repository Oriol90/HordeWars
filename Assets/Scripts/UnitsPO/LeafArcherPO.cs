public class LeafArcherPO : UnitData
{
    public LeafArcherPO(int experience, Item item) : base(experience, item)
    {
        gender = Gender.Male;
        unitName = NamesDBStatic.GetRandomNameByGender(gender);
        race = Race.Human;
        unitType = UnitType.LeafArcher;
    }
}