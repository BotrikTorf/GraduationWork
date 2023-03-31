public static class ActiveHeroSave
{
    private static UnitGamePositive _activeHero;

    public static void SetActiveHero(UnitGamePositive activeHero) => _activeHero = activeHero;

    public static UnitGamePositive GetActiveHero() => _activeHero;
}
