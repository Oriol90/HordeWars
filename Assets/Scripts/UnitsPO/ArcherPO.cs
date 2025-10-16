public class ArcherPO : UnitData
{
    public ArcherPO(int experience, Item item) : base(experience, item)
    {
        unitName = NamesDBStatic.GetRandomNameByGender(gender);
        gender = Gender.Female;
        race = Race.Human;
        unitType = UnitType.Archer;
    }
}