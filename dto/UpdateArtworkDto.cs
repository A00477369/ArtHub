﻿using System;
using ArtHub.Models;

namespace ArtHub.dto
{
	public class UpdateArtworkDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double MinimumBid { get; set; }
        public bool Live { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public double CurrentHighestBid { get; set; }
        public StatusType Status { get; set; }
    }
}

