﻿using System;
namespace ArtHub.dto
{
	public class CreateCategoryDto
	{
		public required string Title { get; set; }
        public required string CreatedBy { get; set; }
    }
}

