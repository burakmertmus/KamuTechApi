﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace KamuTechApi.Models
{
    public partial class Sliders
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual PhotoList Photo { get; set; }
    }
}