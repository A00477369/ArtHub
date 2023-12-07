using System;
using ArtHub.Controllers;
using ArtHub.Filters;
using ArtHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ArtHub.Services.ServicesImpl
{
    public class BidServiceImpl : BidService
	{
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ArtworkService _artworkService;
        private readonly ILogger<BidServiceImpl> _logger;

        public BidServiceImpl(IServiceScopeFactory scopeFactory, ArtworkService artworkService, ILogger<BidServiceImpl> logger)
        {
            _artworkService = artworkService;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public Bid CreateBid(Bid bid)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                Artwork selectedArtwork = _artworkService.GetArtworkById(bid.ArtworkId);

                

                if(selectedArtwork != null && selectedArtwork.Live=="true" && selectedArtwork.MinimumBid <= bid.BidAmount && selectedArtwork.CurrentHighestBid <= bid.BidAmount)
                {

                    bid = context.Bids.Add(bid).Entity;
                    selectedArtwork.CurrentHighestBid = bid.BidAmount;
                    context.Entry(selectedArtwork).State = EntityState.Modified;
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

                IQueryable<Bid> query = context.Bids;

                query = filter.ApplyFilter(query);

                return query.ToList();
            }
        }

        public Bid FindBidById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                Bid bid = context.Bids.Find(id);
                return bid;

            }
        }

        public void UpdateBidStatusByArtworkIdAndBidAmount(int id, double currentHighestBid)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var selectedBid = context.Bids.FirstOrDefault(b => b.ArtworkId == id && b.BidAmount == currentHighestBid);

                if (selectedBid != null)
                {
                    
                    selectedBid.Successful = "true";
                    context.Entry(selectedBid).State = EntityState.Modified;
                    context.SaveChanges();
                }


            }
        }
    }
}

