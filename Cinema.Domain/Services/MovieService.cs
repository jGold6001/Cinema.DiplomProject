using Cinema.Domain.Business;
using Cinema.Domain.Entities;
using Cinema.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Services
{
    public class MovieService
    {
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsCinema");
        string keyAPI = "pol1kh111";

        public void AddOrUpdateMovie(Movie movie)
        {
            unitOfWork.Posters.AddOrUpdate(movie.Poster);
            unitOfWork.Trailers.AddOrUpdate(movie.Trailer);

            foreach (var item in unitOfWork.Persons.GetAll())
            {
                if (unitOfWork.Persons.FindBy(c => c.Id == item.Id).Count() != 0)
                    unitOfWork.Persons.AddOrUpdate(item);
            }                

            foreach (var item in unitOfWork.Images.GetAll())
                unitOfWork.Images.AddOrUpdate(item);

            unitOfWork.Save();
        }


        public void DeleteMovie(long id)
        {
            var movie = unitOfWork.Movies.Get(id);

            unitOfWork.Posters.Delete(movie.Poster);
            unitOfWork.Trailers.Delete(movie.Trailer);

            foreach (var item in unitOfWork.Images.GetAll())
                unitOfWork.Images.Delete(item);

            unitOfWork.Save();
        }


        public Movie GetFromAPI(long id)
        {
            var movie = JsonFromURL<Movie>.ConvertToObject("");
            var poster = JsonFromURL<Poster>.ConvertToObject("");
            var trailer = JsonFromURL<Trailer>.ConvertToObject("");

            var imagesData = JsonFromURL<ImageData>.ConvertToObject("");
            var images = new List<Image>();
            
            for (int i = 0; i < imagesData.Ids.Count; i++)
            {
                var image = JsonFromURL<Image>.ConvertToObject("");
                images.Add(image);
            }



            return movie;
        }


        public void GetAllCountriesFromAPIAndAddToDb()
        {
            var countries = JsonFromURL<CountriesData>.ConvertToObject("");
            foreach (var item in countries.Countries)
                unitOfWork.Countries.AddOrUpdate(item);
        }


        public void GetAllGenresFromAPIAndAddToDb()
        {
            var genres = JsonFromURL<GenresData>.ConvertToObject("");
            foreach (var item in genres.Genres)
                unitOfWork.Genres.AddOrUpdate(item);
        }

    }
}
