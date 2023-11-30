using System;
namespace ArtHub.Models
{
	public class Transaction
	{
        public int Id { get; set; }
        public int BidId { get; set; }

        public Transaction(int id, int bidId)
        {
            Id = id;
            BidId = bidId;
        }
    }
}

