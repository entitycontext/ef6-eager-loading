using System.Collections.Generic;

using MovieSite.Models;

namespace MovieSite.Database
{
    public class SampleData
    {
        public IDictionary<string, Artist> Artists = new Dictionary<string, Artist>();
        public IDictionary<string, Character> Characters = new Dictionary<string, Character>();
        public IDictionary<string, Genre> Genres = new Dictionary<string, Genre>();
        public IDictionary<string, Role> Roles = new Dictionary<string, Role>();
        public IDictionary<string, Title> Titles = new Dictionary<string, Title>();
        
        public SampleData()
        {
            Titles["Iron Man"] = new Title
            {
                Year = 2008,
                RuntimeMinutes = 126,
                BudgetMillions = 140.0m,
                GrossMillions = 585.2m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Jon Favreau"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Robert Downey Jr."),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Iron Man") },
                            new TitleArtistCharacter { Character = GetCharacter("Tony Stark") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Terrence Howard"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("James 'Rhodey' Rhodes") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jeff Bridges"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Obadiah Stane") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Gwyneth Paltrow"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Pepper Potts") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Clark Gregg"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Agent Phil Coulson") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Leslie Bibb"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Christine Everhart") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jon Favreau"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Happy Hogan") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Paul Bettany"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jarvis") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Shaun Toub"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Yinsen") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Faran Tahir"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Raza") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Bill Smitrovich"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("General Gabriel") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Sayed Badreya"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Abu Bakaar") }
                        }
                    },
                }
            };

            Titles["The Incredible Hulk"] = new Title
            {
                Year = 2008,
                RuntimeMinutes = 112,
                BudgetMillions = 150.0m,
                GrossMillions = 263.4m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Louis Leterrier"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Edward Norton"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Bruce Banner") },
                            new TitleArtistCharacter { Character = GetCharacter("The Hulk") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Liv Tyler"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Betty Ross") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Tim Roth"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Emil Blonsky") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("William Hurt"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("General 'Thunderbolt' Ross") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Tim Blake Nelson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Samuel Sterns") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Ty Burrell"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Leonard") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Christina Cabot"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Major Kathleen Sparr") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Peter Mensah"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("General Joe Greller") }
                        }
                    }
                }
            };

            Titles["Iron Man 2"] = new Title
            {
                Year = 2010,
                RuntimeMinutes = 125,
                BudgetMillions = 200.0m,
                GrossMillions = 623.0m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Jon Favreau"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Robert Downey Jr."),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Tony Stark") },
                            new TitleArtistCharacter { Character = GetCharacter("Iron Man") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Gwyneth Paltrow"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Pepper Potts") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Don Cheadle"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("James 'Rhodey' Rhodes") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Scarlett Johansson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Natasha Romanoff") },
                            new TitleArtistCharacter { Character = GetCharacter("Black Widow") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Sam Rockwell"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Justin Hammer") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Mickey Rourke"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Ivan Vanko") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Samuel L. Jackson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Nick Fury") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Clark Gregg"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Agent Phil Coulson") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("John Slattery"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Howard Stark") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Garry Shandling"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Senator Stern") }
                        }
                    },                    
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Paul Bettany"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jarvis") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Kate Mara"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("U.S. Marshal") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Leslie Bibb"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Christine Everhart") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jon Favreau"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Happy Hogan") }
                        }
                    },
                }
            };

            Titles["Thor"] = new Title
            {
                Year = 2011,
                RuntimeMinutes = 114,
                BudgetMillions = 150.0m,
                GrossMillions = 449.3m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Kenneth Branagh"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Chris Hemsworth"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Thor") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Natalie Portman"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jane Foster") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Tom Hiddleston"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Loki") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Anthony Hopkins"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Odin") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Stellan Skarsgård"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Erik Selvig") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Kat Dennings"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Darcy Lewis") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Clark Gregg"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Agent Phil Coulson") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Colm Feore"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("King Laufey") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Idris Elba"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Heimdall") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Ray Stevenson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Volstagg") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Tadanobu Asano"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Hogun") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Josh Dallas"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Fandral") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jaimie Alexander"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Sif") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Rene Russo"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Frigga") }
                        }
                    },
                }
            };

            Titles["Captain America: The First Avenger"] = new Title
            {
                Year = 2011,
                RuntimeMinutes = 124,
                BudgetMillions = 140.0m,
                GrossMillions = 370.6m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Joe Johnston"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Chris Evans"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Captain America") },
                            new TitleArtistCharacter { Character = GetCharacter("Steve Rogers") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Hayley Atwell"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Peggy Carter") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Sebastian Stan"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("James 'Bucky' Barnes") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Tommy Lee Jones"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Colonel Chester Phillips") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Hugo Weaving"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Johann Schmidt") },
                            new TitleArtistCharacter { Character = GetCharacter("Red Skull") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Dominic Cooper"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Howard Stark") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Richard Armitage"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Heinz Kruger") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Stanley Tucci"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Dr. Abraham Erskine") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Samuel L. Jackson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Nick Fury") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Toby Jones"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Dr. Arnim Zola") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Neal McDonough"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Timothy 'Dum Dum' Dugan") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Derek Luke"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Gabe Jones") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Kenneth Choi"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jim Morita") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("JJ Feild"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("James Montgomery Falsworth") }
                        }
                    },
                }
            };

            Titles["The Avengers"] = new Title
            {
                Year = 2012,
                RuntimeMinutes = 143,
                BudgetMillions = 220.0m,
                GrossMillions = 1519.0m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Joss Whedon"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Robert Downey Jr."),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Tony Stark") },
                            new TitleArtistCharacter { Character = GetCharacter("Iron Man") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Chris Evans"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Steve Rogers") },
                            new TitleArtistCharacter { Character = GetCharacter("Captain America") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Mark Ruffalo"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Bruce Banner") },
                            new TitleArtistCharacter { Character = GetCharacter("The Hulk") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Chris Hemsworth"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Thor") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Scarlett Johansson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Natasha Romanoff") },
                            new TitleArtistCharacter { Character = GetCharacter("Black Widow") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jeremy Renner"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Clint Barton") },
                            new TitleArtistCharacter { Character = GetCharacter("Hawkeye") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Tom Hiddleston"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Loki") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Clark Gregg"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Agent Phil Coulson") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Cobie Smulders"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Agent Maria Hill") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Stellan Skarsgård"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Erik Selvig") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Samuel L. Jackson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Nick Fury") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Gwyneth Paltrow"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Pepper Potts") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Paul Bettany"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jarvis") }
                        }
                    },
                }
            };

            Titles["Iron Man 3"] = new Title
            {
                Year = 2013,
                RuntimeMinutes = 130,
                BudgetMillions = 200.0m,
                GrossMillions = 1215.0m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Shane Black"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Robert Downey Jr."),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Tony Stark") },
                            new TitleArtistCharacter { Character = GetCharacter("Iron Man") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Gwyneth Paltrow"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Pepper Potts") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Don Cheadle"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("James 'Rhodey' Rhodes") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Guy Pearce"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Aldrich Killian") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Rebecca Hall"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Maya Hansen") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jon Favreau"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Happy Hogan") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Ben Kingsley"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Trevor Slattery") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("James Badge Dale"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Savin") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Stephanie Szostak"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Brandt") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Paul Bettany"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jarvis") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("William Sadler"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("President Ellis") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Dale Dickey"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Mrs. Davis") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Ty Simpkins"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Harley Keener") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Miguel Ferrer"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Vice President Rodriguez") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Xueqi Wang"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Doctor Wu") }
                        }
                    },
                }
            };

            Titles["Thor: The Dark World"] = new Title
            {
                Year = 2013,
                RuntimeMinutes = 112,
                BudgetMillions = 170.0m,
                GrossMillions = 644.8m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Alan Taylor"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Chris Hemsworth"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Thor") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Natalie Portman"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jane Foster") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Tom Hiddleston"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Loki") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Anthony Hopkins"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Odin") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Christopher Eccleston"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Malekith") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jaimie Alexander"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Sif") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Zachary Levi"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Fandral") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Ray Stevenson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Volstagg") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Tadanobu Asano"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Hogun") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Idris Elba"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Heimdall") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Rene Russo"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Frigga") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Adewale Akinnuoye-Agbaje"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Algrim") },
                            new TitleArtistCharacter { Character = GetCharacter("Kurse") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Kat Dennings"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Darcy Lewis") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Stellan Skarsgård"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Erik Selvig") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Alice Krige"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Eir") }
                        }
                    },
                }
            };

            Titles["Captain America: The Winter Soldier"] = new Title
            {
                Year = 2014,
                RuntimeMinutes = 136,
                BudgetMillions = 170.0m,
                GrossMillions = 714.8m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Anthony Russo"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Joe Russo"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Chris Evans"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Steve Rogers") },
                            new TitleArtistCharacter { Character = GetCharacter("Captain America") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Samuel L. Jackson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Nick Fury") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Scarlett Johansson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Natasha Romanoff") },
                            new TitleArtistCharacter { Character = GetCharacter("Black Widow") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Robert Redford"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Alexander Pierce") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Sebastian Stan"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("James 'Bucky' Barnes") },
                            new TitleArtistCharacter { Character = GetCharacter("Winter Soldier") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Anthony Mackie"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Sam Wilson") },
                            new TitleArtistCharacter { Character = GetCharacter("Falcon") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Cobie Smulders"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Agent Maria Hill") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Frank Grillo"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Brock Rumlow") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Maximiliano Hernández"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jasper Sitwell") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Emily VanCamp"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Agent 13") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Hayley Atwell"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Peggy Carter") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Toby Jones"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Dr. Arnim Zola") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Callan Mulvey"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jack Rollins") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jenny Agutter"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Councilwoman Hawley") }
                        }
                    },
                }                
            };

            Titles["Avengers: Age of Ultron"] = new Title
            {
                Year = 2015,
                RuntimeMinutes = 141,
                BudgetMillions = 279.9m,
                GrossMillions = 1396.0m,
                TitleGenres = new List<TitleGenre>
                {
                    new TitleGenre { Genre = GetGenre("Action") },
                    new TitleGenre { Genre = GetGenre("Adventure") },
                    new TitleGenre { Genre = GetGenre("Sci-Fi") }
                },
                TitleArtists = new List<TitleArtist>
                {
                    new TitleArtist
                    {
                        Role = GetRole("Director"),
                        Artist = GetArtist("Joss Whedon"),
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Robert Downey Jr."),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Tony Stark") },
                            new TitleArtistCharacter { Character = GetCharacter("Iron Man") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Mark Ruffalo"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Bruce Banner") },
                            new TitleArtistCharacter { Character = GetCharacter("The Hulk") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Chris Evans"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Steve Rogers") },
                            new TitleArtistCharacter { Character = GetCharacter("Captain America") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Scarlett Johansson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Natasha Romanoff") },
                            new TitleArtistCharacter { Character = GetCharacter("Black Widow") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Jeremy Renner"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Clint Barton") },
                            new TitleArtistCharacter { Character = GetCharacter("Hawkeye") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("James Spader"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Ultron") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Samuel L. Jackson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Nick Fury") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Don Cheadle"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("James 'Rhodey' Rhodes") },
                            new TitleArtistCharacter { Character = GetCharacter("War Machine") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Aaron Taylor-Johnson"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Pietro Maximoff") },
                            new TitleArtistCharacter { Character = GetCharacter("Quicksilver") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Elizabeth Olsen"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Wanda Maximoff") },
                            new TitleArtistCharacter { Character = GetCharacter("Scarlet Witch") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Paul Bettany"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Jarvis") },
                            new TitleArtistCharacter { Character = GetCharacter("Vision") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Cobie Smulders"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Agent Maria Hill") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Anthony Mackie"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Sam Wilson") },
                            new TitleArtistCharacter { Character = GetCharacter("Falcon") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Hayley Atwell"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Peggy Carter") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Idris Elba"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Heimdall") }
                        }
                    },
                    new TitleArtist
                    {
                        Role = GetRole("Actor"),
                        Artist = GetArtist("Stellan Skarsgård"),
                        TitleArtistCharacters = new List<TitleArtistCharacter>
                        {
                            new TitleArtistCharacter { Character = GetCharacter("Erik Selvig") }
                        }
                    },
                }                
            };

            foreach (var title in Titles)
            {
                title.Value.Name = title.Key;
            }
        }

        private Artist GetArtist(
            string name)
        {
            if (!Artists.ContainsKey(name))
            {
                Artists[name] = new Artist { Name = name };
            }
            return Artists[name];
        }

        private Character GetCharacter(
            string name)
        {
            if (!Characters.ContainsKey(name))
            {
                Characters[name] = new Character { Name = name };
            }
            return Characters[name];
        }

        private Genre GetGenre(
            string name)
        {
            if (!Genres.ContainsKey(name))
            {
                Genres[name] = new Genre { Name = name };
            }
            return Genres[name];
        }

        private Role GetRole(
            string name)
        {
            if (!Roles.ContainsKey(name))
            {
                Roles[name] = new Role { Name = name };
            }
            return Roles[name];
        }
    }
}