﻿namespace Infrastructure.Models
{
    public partial class SchemaVersion
    {
        public int Id { get; set; }
        public string ScriptName { get; set; } = null!;
        public DateTime Applied { get; set; }
    }
}
