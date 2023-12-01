using System;
using ArtHub.dto;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            Transaction transaction = _transactionService.GetTransactionById(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost]
        public ActionResult CreateTransaction([FromBody] CreateTransactionDto createTransactionDto)
        {
            if (createTransactionDto == null)
            {
                return BadRequest("Invalid transaction data");
            }

            Transaction createdTransaction = new Transaction(1,createTransactionDto.BidId);

            createdTransaction = _transactionService.CreateTransaction(createdTransaction);
            return Ok(createdTransaction);
        }

     
    }
}


