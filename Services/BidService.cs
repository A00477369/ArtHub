using System;
using ArtHub.Filters;
using ArtHub.Models;

namespace ArtHub.Services
{
    public interface BidService
    {
        Bid CreateBid(Bid bid);
        List<Bid> filter(BidFilter filter);
        Bid FindBidById(int id);
        void UpdateBidStatusByArtworkIdAndBidAmount(int id, double currentHighestBid);
    }
}

