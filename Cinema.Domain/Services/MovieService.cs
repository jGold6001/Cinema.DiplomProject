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
        EFUnitOfWork unitOfWork = new EFUnitOfWork("CotsContext");
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
            var postrsIds = JsonFromURL<PostersByMovie>.ConvertToObject($"{host}/film/{id}/posters{keyAPI}");
            var posterUrl = $"{host}/film/poster/{postrsIds.Ids[0].Value}{keyAPI}&width=300&height=400&ratio=1";
            var poster = new Poster(id, posterUrl);
            movie.Poster = poster;

            //get and add trailer
            var trailers = JsonFromURL<TrailersData>.ConvertToObject($"{host}/film/{id}/trailers{keyAPI}&size=1");
            var trailer = trailers.trailers.FirstOrDefault();
            movie.Trailer = trailer;

            //get and add images
            var imagesData = JsonFromURL<ImageData>.ConvertToObject($"{host}/film/{id}/images{keyAPI}");
            var images = new List<Image>();
            movie.Images = GetImages(id, imagesData, images);

            //get and add persons
            var personsByMovie = JsonFromURL<PersonesByMovie>.ConvertToObject($"{host}/film/{id}/persons{keyAPI}&size=max&detalization=FULL");
            var persons = new List<Person>();          
            movie.Persons = GetPersons(id, personsByMovie, persons);

            return movie;
        }

        private List<Person> GetPersons(long id, PersonesByMovie personsByMovie, List<Person> persons)
        {
            foreach (var item in personsByMovie.PersonModels)
            {
                var person = ConvertToPerson(item, id);
                if(person != null)
                    persons.Add(person);
            }
            return persons;
        }

        private List<Image> GetImages(long id, ImageData imagesData, List<Image> images)
        {
            foreach (var imageId in imagesData.Ids)
            {
                var imgPath = $"{host}/film/image/{imageId.Value}{keyAPI}&width=300&height=400&ratio=1";
                var image = new Image(imgPath, id);
                images.Add(image);
            }
            return images;
        }

        public void GetAllCountriesFromAPIAndAddToDb()
        {
            var countries = JsonFromURL<CountriesData>.ConvertToObject($"{host}/countries{keyAPI}&size=150");
            foreach (var item in countries.Countries)
                unitOfWork.Countries.AddOrUpdate(item);

            unitOfWork.Save();
        }


        public void GetAllGenresFromAPIAndAddToDb()
        {
            var genres = JsonFromURL<GenresData>.ConvertToObject($"{host}/genres{keyAPI}&size=90");
            foreach (var item in genres.Genres)
                unitOfWork.Genres.AddOrUpdate(item);

            unitOfWork.Save();
        }

        public void GetProffesionByIdAndAddToDb()
        {
            var professions = JsonFromURL<ProfessionsData>.ConvertToObject($"{host}/professions{keyAPI}&size=20");
            foreach (var item in professions.Professions)
                unitOfWork.Professions.AddOrUpdate(item);

            unitOfWork.Save();
        }

        public Person ConvertToPerson(PersonModel personModel, long filmId)
        {
            if (filmId == personModel.FilmId && (personModel.ProfessionId == 1 || personModel.ProfessionId == 2))
            {
                Person person = JsonFromURL<Person>.ConvertToObject($"{host}/person/{personModel.PersonId}{keyAPI}");
                person.ProfessionId = personModel.ProfessionId;
                return person;
            }
            return null;
        }

    }
}
