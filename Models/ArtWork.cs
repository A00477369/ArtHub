using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.NetworkInformation;

namespace ArtHub.Models
{
    public enum StatusType
    {
        Draft,
        Active,
        Sold,
        Archived
    }

    public class Artwork
    {
        public int Id;
        public string Title;
        public string Description;
        public string ImageUrl;
        public double MinimumBid;
        public bool Live;
        public int SellerId;
        public int CategoryId;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public DateTime LiveStartTime;
        public double CurrentHighestBid;
        public StatusType Status;

        public Artwork(int id, string title, string description, string imageUrl, double minimumBid, bool live, int sellerId,
                   int categoryId, DateTime createdOn, DateTime lastUpdatedOn, double currentHighestBid, StatusType status)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            MinimumBid = minimumBid;
            Live = live;
            SellerId = sellerId;
            CategoryId = categoryId;
            CreatedOn = createdOn;
            LastUpdatedOn = lastUpdatedOn;
            CurrentHighestBid = currentHighestBid;
            Status = status;
        }
    }

    
}

