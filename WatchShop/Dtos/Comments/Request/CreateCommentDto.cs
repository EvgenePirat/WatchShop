﻿using System.ComponentModel.DataAnnotations;

namespace WatchShop_UI.Dtos.Comments.Request
{
    public class CreateCommentDto
    {
        [Required]
        public int WatchId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
