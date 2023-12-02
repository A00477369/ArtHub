using System;
using ArtHub.dto;
using ArtHub.Filters;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BidController : ControllerBase
    {

        private readonly BidService _bidService;


        public BidController(BidService bidService)
		{
            _bidService = bidService;
		}

        [HttpPost]
        public ActionResult CreateBid([FromBody] CreateBidDto dto)
        {
            if(dto == null)
            {
                return BadRequest("Bad Bid Data");
            }

            Bid bid = new Bid(1, dto.BidderId, dto.ArtworkId, dto.BidAmount, DateTime.Now, false);

            if (bid.Validate().isValid)
            {
                bid = _bidService.CreateBid(bid);
                return Ok(bid);
            }
            else
            {
                return BadRequest(bid.Validate().errorMessage);
            }
            
        }

        [HttpPost("filter")]
        public ActionResult BidFilter([FromBody] BidFilter filter)
        {
            List<Bid> bids = _bidService.filter(filter);

            return Ok(bids);
        }
	}
}

