﻿
using ArtHub.dto;
using ArtHub.Filters;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ArtHub.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ArtworkController : ControllerBase
    {
        private readonly ArtworkService _artworkService;

        public ArtworkController(ArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        [HttpGet("{id:int}"),AllowAnonymous]
        public ActionResult GetArtworkById(int id)
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


            Artwork createdArtwork = new Artwork(1,artworkDto.Title,artworkDto.Description,artworkDto.ImageUrl,artworkDto.MinimumBid,false,artworkDto.SellerId,artworkDto.CategoryId,DateTime.Now,DateTime.Now,0,StatusType.Draft);
            if (createdArtwork.Validate().isValid)
            {
                createdArtwork = _artworkService.CreateArtwork(createdArtwork);
                return Ok(createdArtwork);
            }
            else
            {
                return BadRequest(createdArtwork.Validate().errorMessage);
            }
 
          
        }

        [HttpPut]
        public ActionResult UpdateArtwork([FromBody] UpdateArtworkDto artworkDto)
        {
            if (artworkDto == null)
            {
                return BadRequest("Invalid artwork data");
            }

            Artwork existingArtwork = _artworkService.GetArtworkById(artworkDto.Id);

            if (existingArtwork == null)
            {
                return NotFound("Artwork not found");
            }

            Artwork updatedArtwork = _artworkService.UpdateArtwork(artworkDto, existingArtwork);

            return Ok(updatedArtwork);
        }

        [HttpGet, AllowAnonymous]
        public ActionResult GetAllArtworks()
        {
            List<Artwork> artworks = _artworkService.GetAllArtworks();

            return Ok(artworks);
        }


        [HttpPost("filter"), AllowAnonymous]
        public ActionResult ArtworkFilter([FromBody] ArtworkFilter filter)
        {
            List<Artwork> artworks = _artworkService.filter(filter); 

            return Ok(artworks);
        }

        [HttpGet("startAuction/{id:int}")]
        public ActionResult StartAuction(int id)
        {
            Artwork artwork = _artworkService.StartAuction(id);
            return Ok(artwork);
        }

        [HttpGet("stopAuction/{id:int}")]
        public ActionResult StopAuction(int id)
        {
            Artwork artwork = _artworkService.StopAuction(id);
            return Ok(artwork);
        }


    }

}

