using System;
using System.Net.NetworkInformation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ArtHub.Models
{
	public class Category
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }


        public Category()
        {
        }

        public Category( string title, DateTime createdOn, string createdBy)
        {
            Title = title;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
        }
        

    }
}

