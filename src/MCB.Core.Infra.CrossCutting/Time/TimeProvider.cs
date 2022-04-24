namespace MCB.Core.Infra.CrossCutting.Time
{
    public static class TimeProvider
    {
        // Properties
        public static DateTimeOffset? InjectedUtcNow { get; set; }

        // Public Methods
        public static DateTimeOffset GetUtcNow()
        {
            return InjectedUtcNow ?? DateTimeOffset.UtcNow;
        }
    }
}
