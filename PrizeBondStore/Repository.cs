namespace PrizeBondStore
{
    public static class Repository
    {
        private static readonly PrizeBondEntities Entities = new PrizeBondEntities();

        public static PrizeBondEntities GetInstance()
        {
            return Entities;
        }
    }
}