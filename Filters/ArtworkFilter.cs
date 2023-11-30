using System;
using ArtHub.Models;

namespace ArtHub.Filters
{
	public class ArtworkFilter
	{
        private int? SellerId { get; set; }
        private List<int>? CategoryIds { get; set; }
        private StatusType? Status { get; set; }

        public String toQuery()
        {
            string query = "SELECT * FROM Artwork WHERE 1=1";

            if (SellerId != null)
            {
                query += " AND SellerId = " + SellerId;
            }

            if (CategoryIds != null && CategoryIds.Count > 0)
            {
                // Use IN clause to filter by multiple category IDs
                string categoryIdsString = string.Join(",", CategoryIds);
                query += " AND CategoryId IN (" + categoryIdsString + ")";
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

