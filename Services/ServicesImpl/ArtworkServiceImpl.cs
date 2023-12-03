using System;
using ArtHub.dto;
using ArtHub.Filters;
using ArtHub.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Services.ServicesImpl
{
    public class ArtworkServiceImpl : ArtworkService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ArtworkServiceImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public Artwork CreateArtwork(Artwork createdArtwork)
        {
            throw new NotImplementedException();
        }

        public List<Artwork> filter(ArtworkFilter filter)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                string query = filter.ToQuery();
                return context.Artwork.FromSqlRaw(query).ToList();
            }
        }

        public List<Artwork> GetAllArtworks()
        {
            throw new NotImplementedException();
        }

        public Artwork GetArtworkById(int id)
        {
            throw new NotImplementedException();
        }

        public Artwork StartAuction(int id)
        {
            throw new NotImplementedException();
        }

        public Artwork StopAuction(int id)
        {
            throw new NotImplementedException();
        }

        public Artwork UpdateArtwork(UpdateArtworkDto artworkDto, Artwork existingArtwork)
        {
            throw new NotImplementedException();
        }
    }
}

