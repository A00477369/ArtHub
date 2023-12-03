using ArtHub.dto;
using ArtHub.Filters;
using ArtHub.Models;

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
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                createdArtwork = context.Artwork.Add(createdArtwork).Entity;

                context.SaveChanges();

                return createdArtwork;
            }
        }

        public List<Artwork> filter(ArtworkFilter filter)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                IQueryable<Artwork> query = context.Artwork;

                query = filter.ApplyFilter(query);

                return query.ToList();
            }

        }

        public List<Artwork> GetAllArtworks()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                List<Artwork> artworks = context.Artwork.ToList();

                return artworks;

            }
        }

        public Artwork GetArtworkById(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                Artwork artwork = context.Artwork.Find(id);

                return artwork;

            }
        }

        public Artwork StartAuction(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                Artwork selectedArtwork = GetArtworkById(id);
                if (!selectedArtwork.Live && selectedArtwork.Status == StatusType.Draft)
                {
                    selectedArtwork.Live = true;
                    selectedArtwork.Status = StatusType.Active;
                    selectedArtwork.LiveStartTime = DateTime.Now;
                    context.SaveChanges();
                }
                return selectedArtwork;
            }


        }

        public Artwork StopAuction(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                Artwork selectedArtwork = GetArtworkById(id);
                if (selectedArtwork.Live)
                {
                    selectedArtwork.Live = false;
                    selectedArtwork.Status = StatusType.Sold;

                }

                context.SaveChanges();
                return selectedArtwork;

            }



        }

        public Artwork UpdateArtwork(UpdateArtworkDto artworkDto, Artwork existingArtwork)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                existingArtwork.Title = artworkDto.Title;
                existingArtwork.Description = artworkDto.Description;
                existingArtwork.ImageUrl = artworkDto.ImageUrl;
                existingArtwork.MinimumBid = artworkDto.MinimumBid;
                existingArtwork.CategoryId = artworkDto.CategoryId;
                existingArtwork.LastUpdatedOn = DateTime.Now;

                context.SaveChanges();

            }

            return existingArtwork;
        }
    }
}