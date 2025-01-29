﻿namespace Backend.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
