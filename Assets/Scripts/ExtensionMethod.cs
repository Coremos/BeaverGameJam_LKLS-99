public static class ExtensionMethod
{
    public static LocationType ToLocationType(this string value)
    {
        if (value.Equals("제1연구실")) return LocationType.Lab1;
        else if (value.Equals("제2연구실")) return LocationType.Lab2;
        else if (value.Equals("화학 실험실")) return LocationType.ChemicalLab;
        else if (value.Equals("멸균 세척실")) return LocationType.SterileLab;
        else if (value.Equals("위험물 저장소")) return LocationType.DangerLab;
        else if (value.Equals("환상재료 양자역학 합성실")) return LocationType.FantasyLab;
        else if (value.Equals("화장실")) return LocationType.Toilet;
        else if (value.Equals("실내 재배실")) return LocationType.GrowingRoom;
        return LocationType.Lab1;
    }
}