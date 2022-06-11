namespace MCB.Core.Infra.CrossCutting.DateTime;

public static class DateTimeProvider
{
    // Properties
    public static Func<DateTimeOffset>? GetDateCustomFunction { get; set; }

    // Public Methods
    public static DateTimeOffset GetDate()
    {
        return GetDateCustomFunction?.Invoke() ?? DateTimeOffset.UtcNow;
    }
}
