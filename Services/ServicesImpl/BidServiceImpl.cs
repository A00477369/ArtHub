using System;
using ArtHub.Filters;
using ArtHub.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Services.ServicesImpl
{
    public class BidServiceImpl : BidService
	{
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ArtworkService _artworkService;

        public BidServiceImpl(IServiceScopeFactory scopeFactory, ArtworkService artworkService)
        {
            _artworkService = artworkService;
            _scopeFactory = scopeFactory;
        }

        public Bid CreateBid(Bid bid)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                Artwork selectedArtwork = _artworkService.GetArtworkById(bid.ArtworkId);

                if(selectedArtwork != null && selectedArtwork.Live && selectedArtwork.MinimumBid <= bid.BidAmount && selectedArtwork.CurrentHighestBid <= bid.BidAmount)
                {

                    bid = context.Bid.Add(bid).Entity;
                    selectedArtwork.CurrentHighestBid = bid.BidAmount;
                    context.SaveChanges();
                }

                return bid;
            }
        }

        public List<Bid> filter(BidFilter filter)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                IQueryable<Bid> query = context.Bid;

                query = filter.ApplyFilter(query);

                return query.ToList();
            }
        }

        public void UpdateBidStatusByArtworkIdAndBidAmount(int id, double currentHighestBid)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var selectedBid = context.Bid.FirstOrDefault(b => b.ArtworkId == id && b.BidAmount == currentHighestBid);

                if (selectedBid != null)
                {
                    selectedBid.Successful = true;
                    context.SaveChanges();
                }


            }
        }
    }
}

