namespace WebAPI_Empresas.Domain.ValueObjects
{
    public class Billing
    {
        public bool Free { get; private set; }
        public bool Database { get; private set; }

        protected Billing() { }

        public Billing(bool free, bool database)
        {
            Free = free;
            Database = database;
        }
    }
}
