using System;
using System.Collections.Generic;
using ArtHub.dto;
using ArtHub.Models;
using Microsoft.AspNetCore.Mvc;
namespace ArtHub.Controllers
{
    

    [ApiController]
    [Route("[controller]")]
    public class ArtworkController : ControllerBase
    {
        private readonly ArtworkService _artworkService;

        public ArtworkController(ArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        [HttpGet("{id:int}")]
        public ActionResult GetArtwork(int id)
        {
            Artwork artwork = _artworkService.GetArtworkById(id);

            if (artwork == null)
            {
                return NotFound();
            }

            return Ok(artwork);
        }

        [HttpPost]
        public ActionResult CreateArtwork([FromBody] CreateArtworkDto artworkDto)
        {
            if (artworkDto == null)
            {
                return BadRequest("Invalid artwork data");
            }



            createdArtwork = _artworkService.CreateArtwork(createdArtwork);
            return CreatedAtAction(nameof(GetArtwork), new { id = createdArtwork.Id }, createdArtwork);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateArtwork(int id, [FromBody] UpdateArtworkDto artworkDto)
        {
            if (artworkDto == null)
            {
                return BadRequest("Invalid artwork data");
            }

            Artwork existingArtwork = _artworkService.GetArtworkById(id);

            if (existingArtwork == null)
            {
                return NotFound("Artwork not found");
            }

            Artwork updatedArtwork = _artworkService.UpdateArtwork(artworkDto, existingArtwork);

            return Ok(updatedArtwork);
        }

        [HttpGet]
        public ActionResult GetAllArtworks()
        {
            List<Artwork> artworks = _artworkService.GetAllArtworks();

            return Ok(artworks);
        }
    }

}

