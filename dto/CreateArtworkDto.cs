using ArtHub.Models;

namespace ArtHub.dto
{
    public class CreateArtworkDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required double MinimumBid { get; set; }
        public required int SellerId { get; set; }
        public required int CategoryId { get; set; }
    }
}