﻿using System;
using ArtHub.Models;

namespace ArtHub.dto
{
	public class UpdateArtworkDto
	{
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required double MinimumBid { get; set; }
        public required bool Live { get; set; }
        public required int SellerId { get; set; }
        public required int CategoryId { get; set; }
        public required double CurrentHighestBid { get; set; }
        public required StatusType Status { get; set; }
    }
}

