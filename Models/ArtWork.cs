using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.NetworkInformation;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double MinimumBid { get; set; }
        public bool Live { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public DateTime LiveStartTime { get; set; }
        public double CurrentHighestBid { get; set; }
        public StatusType Status { get; set; }

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

        public (bool isValid, string errorMessage) Validate()
        {

            if (string.IsNullOrWhiteSpace(Title))
            {
                return (false, "Title is required.");
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                return (false, "Description is required.");
            }

            if (!string.IsNullOrWhiteSpace(ImageUrl) && !Uri.IsWellFormedUriString(ImageUrl, UriKind.Absolute))
            {
                return (false, "Invalid URL format for ImageUrl.");
            }

            if (MinimumBid < 0)
            {
                return (false, "MinimumBid must be a non-negative number.");
            }

            return (true,"");
        }


    }

    
}

