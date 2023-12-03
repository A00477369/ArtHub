using System;
using ArtHub.Models;

namespace ArtHub.Filters
{
	public class ArtworkFilter
	{
        private int ? SellerId { get; set; }
        private List<int>? CategoryIds { get; set; }
        private StatusType? Status { get; set; }

        public string ToQuery()
        {
            string query = "SELECT * FROM Artwork WHERE 1=1";

            if (SellerId != null)
            {
                Console.WriteLine("The seller id is "+SellerId);
                query += " AND SellerId = " + SellerId.ToString();
              
            }

            if (CategoryIds != null && CategoryIds.Count > 0)
            {
                string categoryIdsString = string.Join(",", CategoryIds);
                query += " AND CategoryId IN (" + categoryIdsString + ")";
            }

            if (Status != null)
            {
                if (Status is StatusType statusType)
                {
                    query += $" AND Status = '{statusType}'";
                }
            }

            query += ";";
            Console.WriteLine("The query is " + query);

            return query;
        }

    }


}

