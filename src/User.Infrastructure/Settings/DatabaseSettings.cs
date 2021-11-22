namespace User.Infrastructure.Settings
{
    public class DatabaseSettings
    {
        public string Server { get; set; }
        public string Catalog { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ConnectionString => 
            $"Server={Server};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
    }
}