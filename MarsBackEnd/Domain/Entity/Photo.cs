﻿namespace Domain.Entity
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateOnly UploadDate { get; set; }
        public string Title { get; set; }

    }
}