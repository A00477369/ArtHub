using System;
using System.Net.NetworkInformation;

namespace ArtHub.Models
{
	public class Category
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        
        public Category(int id, string title, DateTime createdOn, string createdBy)
        {
            Id = id;
            Title = title;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
        }
        

    }
}

