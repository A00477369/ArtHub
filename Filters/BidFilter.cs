using System;
using System.Net.NetworkInformation;

namespace ArtHub.Filters
{
	public class BidFilter
	{
        public int? BidderId { get; set; }
        public int? ArtworkId { get; set; }
        public string? Successful { get; set; }
        public String toQuery()
        {
            string query = "SELECT * FROM Bid WHERE 1=1";

            if (BidderId != null)
            {
                query += " AND BidderId = " + BidderId;
            }

            if (ArtworkId != null)
            {
                query += " AND ArtworkId = " + ArtworkId;
            }

            if (Successful != null)
            {
                query += " AND Successfull = '" + Successful + "'";
            }

            query += ";";

            return query;
        }
    }
}

