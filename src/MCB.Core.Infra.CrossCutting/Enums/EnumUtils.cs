namespace MCB.Core.Infra.CrossCutting.Enums
{
    public static class EnumUtils
    {
        public static TEnum GetRandomEnumValue<TEnum>()
            where TEnum : struct, Enum, IConvertible
        {
            return Enum.GetValues<TEnum>()
                .OrderBy(q => Guid.NewGuid())
                .FirstOrDefault();
        }
    }
}
