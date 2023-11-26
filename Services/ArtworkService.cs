using System;
using ArtHub.dto;
using ArtHub.Filters;
using ArtHub.Models;

namespace ArtHub.Services
{
    public interface ArtworkService
    {
        Artwork CreateArtwork(Artwork createdArtwork);
        List<Artwork> filter(ArtworkFilter filter);
        List<Artwork> GetAllArtworks();
        Artwork GetArtworkById(int id);
        Artwork StartAuction(int id);
        Artwork StopAuction(int id);
        Artwork UpdateArtwork(UpdateArtworkDto artworkDto, Artwork existingArtwork);
    }
}

