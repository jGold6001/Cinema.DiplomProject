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
        string keyAPI = "?apiKey=pol1kh111";
        string host = "http://kino-teatr.ua:8081/services/api";


        public MovieService()
        {

        }

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
            var movie = JsonFromURL<Movie>.ConvertToObject($"{host}/film/{id}{keyAPI}");

            //get and add poster
            var poster = JsonFromURL<Poster>.ConvertToObject($"{host}");
            movie.Poster = poster;

            //get and add trailer
            var trailer = JsonFromURL<Trailer>.ConvertToObject("");
            movie.Trailer = trailer;

            //get and add images
            var imagesData = JsonFromURL<ImageData>.ConvertToObject("");
            var images = new List<Image>();
            for (int i = 0; i < imagesData.Ids.Count; i++)
            {
                var image = JsonFromURL<Image>.ConvertToObject("");
                images.Add(image);
            }
            movie.Images = images;

            //get and add persons
            var personsByMovie = JsonFromURL<PersonesByMovie>.ConvertToObject("");
            var persons = new List<Person>();
            foreach (var item in personsByMovie.PersonModels)
            {
                var person = ConvertToPerson(item, id);
                persons.Add(person);
            }
            movie.Persons = persons;           

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

        public void GetProffesionByIdAndAddToDb(long id)
        {
            var profession = JsonFromURL<Profession>.ConvertToObject("");
            unitOfWork.Professions.AddOrUpdate(profession);
        }

        public Person ConvertToPerson(PersonModel personModel, long filmId)
        {
            if (filmId == personModel.Id)
            {
                Person person = JsonFromURL<Person>.ConvertToObject("");
                person.ProfessionId = personModel.ProfessionId;
                return person;
            }
            return null;
        }

    }
}
