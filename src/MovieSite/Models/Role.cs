﻿using System.Collections.Generic;

namespace MovieSite.Models
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<TitleArtist> TitleArtists { get; set; } = new List<TitleArtist>();
    }
}