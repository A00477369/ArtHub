using System;
using ArtHub.Models;

namespace ArtHub.Filters
{
	public class ArtworkFilter
	{
        private int? SellerId { get; set; }
        private int? CategoryId { get; set; }
        private StatusType? Status { get; set; }

        public String toQuery()
        {
            string query = "SELECT * FROM Artwork WHERE 1=1";

            if (SellerId != null)
            {
                query += " AND SellerId = " + SellerId;
            }

            if (CategoryId != null)
            {
                query += " AND CategoryId = " + CategoryId;
            }

            if (Status != null)
            {
                query += " AND Status = '" + Status.ToString() + "'";
            }

            query += ";";

            return query;
        }
    }


}

