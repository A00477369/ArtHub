using System;
namespace ArtHub.dto
{
	public class CreateBidDto
	{
        public int BidderId { get; set; }
        public int ArtworkId { get; set; }
        public double BidAmount { get; set; }

    }
}

