﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorChat.Server.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(applicationUser => applicationUser.ReceivedMessages)
                .WithOne(receivedMessage => receivedMessage.Receiver)
                .HasForeignKey(receivedMessage => receivedMessage.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(applicationUser => applicationUser.SentMessages)
                .WithOne(receivedMessage => receivedMessage.Sender)
                .HasForeignKey(receivedMessage => receivedMessage.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
