﻿using ProjectTwitter.Core.Map;
using ProjectTwitter.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTwitter.Map.Option
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.UserName).HasMaxLength(50).IsOptional();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.LastName).HasMaxLength(50).IsOptional();
            Property(x => x.FirstName).HasMaxLength(50).IsOptional();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.Gender).IsOptional();
            Property(x => x.Followers).IsOptional();
            Property(x => x.Following).IsOptional();
            Property(x => x.ImagePath).IsOptional();
            Property(x => x.UserImage).IsOptional();
            Property(x => x.XSmallUserImage).IsOptional();
            Property(x => x.CruptedUserImage).IsOptional();
            Property(x => x.Birthdate).HasColumnType("datetime2").IsOptional();
            Property(x => x.Bio).IsOptional();


            HasMany(x => x.Comments)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);
            HasMany(x => x.Likes)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);
            HasMany(x => x.Tweets)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);
        }
    }
}
