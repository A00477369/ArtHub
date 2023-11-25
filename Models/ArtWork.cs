using System;
using System.Collections.Generic;
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
        public List<int> CategoryIds { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public double CurrentHighestBid { get; set; }
        public StatusType Status { get; set; }
    }

}

