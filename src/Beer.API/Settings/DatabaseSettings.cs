﻿namespace Beer.API.Settings
{
    public class DatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        
        public string ConnectionString 
        {
            get 
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                    return $@"mongodb://{Host}:{Port}";
                
                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }
}