﻿namespace UnluCo.FinalProject.BlazorUI.ViewModels
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }

        public byte[] FileContent { get; set; }
    }
}
