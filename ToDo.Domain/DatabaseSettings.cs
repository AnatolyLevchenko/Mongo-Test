namespace ToDo.Domain
{
    public  class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}