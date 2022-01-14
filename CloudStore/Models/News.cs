﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudStore.Models
{
    public class News
    {
        [Required]
        [Display(Name = "News subject")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "News body")]
        public string Body { get; set; }
    }
}