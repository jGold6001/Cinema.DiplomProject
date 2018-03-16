using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class MovieDb
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]       
        public long Id { get; set; }     
        public string Title { get; set; } 
        public string Premiere { get; set; }
        public string Description { get; set; }       
        public int? Year { get; set; }
        public int? Duration { get; set; }
        public string AgeLimit { get; set; }        
        public double? Rating { get; set; }       
        public long? Votes { get; set; }
        public string BannerUrl { get; set; }
        public string PosterUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Actors { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }      
        public List<Image> Images { get; set; }

        public MovieDb()
        {

        }

        public MovieDb( long Id, string Title, string Premiere, string Description,int? Year, int? Duration,string AgeLimit, 
            double? Rating, long? Votes, string BannerUrl,  string PosterUrl, string TrailerUrl, string Actors,  string Director, string Genre,  string Country)
        {
            this.Id = Id;
            this.Title = Title;
            this.Premiere = Premiere;
            this.Description = Description;
            this.Year = Year;
            this.Duration = Duration;
            this.AgeLimit = AgeLimit;
            this.Rating = Rating;
            this.Votes = Votes;
            this.BannerUrl = BannerUrl;
            this.PosterUrl = PosterUrl;
            this.TrailerUrl = TrailerUrl;
            this.Actors = Actors;
            this.Director = Director;
            this.Genre = Genre;
            this.Country = Country;
            Images = new List<Image>();
        }
      
    }
}
