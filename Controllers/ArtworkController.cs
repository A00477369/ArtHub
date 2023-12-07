
using ArtHub.dto;
using ArtHub.Filters;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ArtHub.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ArtworkController : ControllerBase
    {
        private readonly ArtworkService _artworkService;
        private readonly BidService _bidService;
        private readonly UserPreferenceService _userPreferenceService;
        private readonly ILogger<ArtworkController> _logger;

        public ArtworkController(ArtworkService artworkService, ILogger<ArtworkController> logger, BidService bidService, UserPreferenceService userPreferenceService)
        {
            _artworkService = artworkService;
            _logger = logger;
            _bidService = bidService;
            _userPreferenceService = userPreferenceService;
        }

        [HttpGet("{id:int}"),AllowAnonymous]
        public ActionResult GetArtworkById(int id)
        {
            try
            {
                _logger.LogInformation($"Getting artwork by ID: {id}");

                Artwork artwork = _artworkService.GetArtworkById(id);

                if (artwork == null)
                {
                    _logger.LogWarning($"Artwork with ID {id} not found");
                    return NotFound();
                }

                return Ok(artwork);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting artwork by ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public ActionResult CreateArtwork([FromBody] CreateArtworkDto artworkDto)
        {
            try
            {
                _logger.LogInformation("Creating artwork");

                if (artworkDto == null)
                {
                    _logger.LogWarning("Invalid artwork data received");
                    return BadRequest("Invalid artwork data");
                }

                Artwork createdArtwork = new Artwork(artworkDto.Title, artworkDto.Description, artworkDto.ImageUrl, artworkDto.MinimumBid, "false", artworkDto.SellerId, artworkDto.CategoryId, DateTime.Now, DateTime.Now, 0, StatusType.Draft.ToString());

                if (createdArtwork.Validate().isValid)
                {
                    createdArtwork = _artworkService.CreateArtwork(createdArtwork);
                    _logger.LogInformation($"Artwork created successfully with ID: {createdArtwork.Id}");
                    return Ok(createdArtwork);
                }
                else
                {
                    _logger.LogWarning($"Failed to create artwork: {createdArtwork.Validate().errorMessage}");
                    return BadRequest(createdArtwork.Validate().errorMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating artwork: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut]
        public ActionResult UpdateArtwork([FromBody] UpdateArtworkDto artworkDto)
        {
            try
            {
                _logger.LogInformation("Updating artwork");

                if (artworkDto == null)
                {
                    _logger.LogWarning("Invalid artwork data received");
                    return BadRequest("Invalid artwork data");
                }

                Artwork existingArtwork = _artworkService.GetArtworkById(artworkDto.Id);

                if (existingArtwork == null)
                {
                    _logger.LogWarning($"Artwork with ID {artworkDto.Id} not found for update");
                    return NotFound("Artwork not found");
                }

                Artwork updatedArtwork = _artworkService.UpdateArtwork(artworkDto, existingArtwork);
                _logger.LogInformation($"Artwork updated successfully with ID: {updatedArtwork.Id}");
                return Ok(updatedArtwork);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating artwork: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet, AllowAnonymous]
        public ActionResult GetAllArtworks()
        {
            try
            {
                _logger.LogInformation("Getting all artworks");

                List<Artwork> artworks = _artworkService.GetAllArtworks();
               Console.Write($"Retrieved {artworks.Count} artworks: {JsonConvert.SerializeObject(artworks)}");

                _logger.LogInformation($"Retrieved {artworks.Count} artworks");
                return Ok(artworks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all artworks: {ex.Message}");
                return StatusCode(500, ex);
            }
        }


        [HttpPost("filter"), AllowAnonymous]

        public ActionResult ArtworkFilter([FromBody] ArtworkFilter filter)
        {
            try
            {
                _logger.LogInformation("Filtering artworks");

                List<Artwork> artworks = _artworkService.filter(filter);
                _logger.LogInformation($"Filtered {artworks.Count} artworks");
                return Ok(artworks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error filtering artworks: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("startAuction/{id:int}")]
        public ActionResult StartAuction(int id)
        {
            try
            {
                _logger.LogInformation($"Starting auction for artwork ID: {id}");

                Artwork artwork = _artworkService.StartAuction(id);
                _logger.LogInformation($"Auction started successfully for artwork ID: {id}");
                return Ok(artwork);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error starting auction for artwork ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("stopAuction/{id:int}")]
        public ActionResult StopAuction(int id)
        {
            try
            {
                _logger.LogInformation($"Stopping auction for artwork ID: {id}");

                Artwork artwork = _artworkService.StopAuction(id);
                _bidService.UpdateBidStatusByArtworkIdAndBidAmount(id, artwork.CurrentHighestBid);
                _logger.LogInformation($"Auction stopped successfully for artwork ID: {id}");
                return Ok(artwork);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error stoping auction for artwork ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("user/{id:int}")]
        public ActionResult GetArtworksBasedOnUserId(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching Artwork Based on User Preference for User: {id}");

                List<int> categoryIds = _userPreferenceService.GetCategoryIdsByUserId(id);
                ArtworkFilter filter = new ArtworkFilter();
                filter.CategoryIds = categoryIds;
                List<Artwork> artworks = _artworkService.filter(filter);

                return Ok(artworks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching Artwork Based on User Preference for User: {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");

            }
        }


    }

}

