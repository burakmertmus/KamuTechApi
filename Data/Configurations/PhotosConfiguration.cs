﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using KamuTechApi.Data;
using KamuTechApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;


namespace KamuTechApi.Data.Configurations
{
    public partial class PhotosConfiguration : IEntityTypeConfiguration<Photos>
    {
        public void Configure(EntityTypeBuilder<Photos> entity)
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.DateAdded)
                .HasColumnType("date")
                .HasColumnName("dateAdded");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");

            entity.Property(e => e.IsMain).HasColumnName("isMain");

            entity.Property(e => e.PublicId)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("publicId");

            entity.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("url");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Photos> entity);
    }
}
