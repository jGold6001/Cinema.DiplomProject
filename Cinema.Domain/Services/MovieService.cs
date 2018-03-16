using AutoMapper;
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
        IMapper mapper;

        public MovieService()
        {

        }

        

        public void AddOrUpdateMovie(Movie movie)
        {
            mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<Movie, MovieDb>()));
            
  
            foreach (var item in movie.Images)
                unitOfWork.Images.AddOrUpdate(item);

            unitOfWork.Movies.AddOrUpdate(mapper.Map<Movie, MovieDb>(movie));

            unitOfWork.Save();
        }


        public MovieDb GetOne(long id)
        {
            return unitOfWork.Movies.Get(id);
        }


        public void DeleteMovie(long id)
        {
            var movie = unitOfWork.Movies.Get(id);
            var poster = unitOfWork.Posters.Get(id);
            var trailer = unitOfWork.Trailers.Get(id);

            unitOfWork.Posters.Delete(poster);
            unitOfWork.Trailers.Delete(trailer);

            foreach (var item in unitOfWork.Images.FindBy(i => i.MovieId == id))
                unitOfWork.Images.Delete(item);

            unitOfWork.Movies.Delete(movie);
            unitOfWork.Save();
        }


        


        public Movie GetFromAPI(long id)
        {
            var movie = JsonFromURL<Movie>.ConvertToObject($"{host}/film/{id}{keyAPI}");

            //get and add poster
            var postrsIds = JsonFromURL<PostersByMovie>.ConvertToObject($"{host}/film/{id}/posters{keyAPI}");
            var posterUrl = $"{host}/film/poster/{postrsIds.Ids[0].Value}{keyAPI}&width=380&height=600&ratio=1";
            movie.PosterUrl = posterUrl;

            //banner
            //if (unitOfWork.Banners.Get(id) != null)
            //    movie.BannerUrl = unitOfWork.Banners.Get(id).Url;

            //get and add trailer
            var trailers = JsonFromURL<TrailersData>.ConvertToObject($"{host}/film/{id}/trailers{keyAPI}&size=1");
            var trailer = trailers.trailers.FirstOrDefault();
            movie.TrailerUrl = trailer.Url;

            //get and add images
            var imagesData = JsonFromURL<ImageData>.ConvertToObject($"{host}/film/{id}/images{keyAPI}");
            var images = new List<Image>();
            movie.Images = GetImages(id, imagesData, images);

            //get and add persons
            var personsByMovie = JsonFromURL<PersonesByMovie>.ConvertToObject($"{host}/film/{id}/persons{keyAPI}&size=max&detalization=FULL");
            var persons = GetPersons(id, personsByMovie);
            try
            {
                var director = persons.Find(p => p.ProfessionId == 1);
                movie.Director = $"{director.FirstName} {director.LastName}";
            }
            catch(Exception)
            {
                
            }         
            
           

            StringBuilder actors = CreateActors(persons);
            movie.Actors = actors.ToString();

            StringBuilder counties = CreateCountries(movie);
            movie.Country = counties.ToString();

            StringBuilder genres = CreateGenres(movie);
            movie.Genre = genres.ToString();

            return movie;
        }

        private static StringBuilder CreateGenres(Movie movie)
        {
            StringBuilder genres = new StringBuilder();
            foreach (var item in movie.Genres)
            {
                genres.Append($"{item.Name}");
                if (item.Id != movie.Genres.Last().Id)
                    genres.Append(", ");
            }

            return genres;
        }

        private static StringBuilder CreateCountries(Movie movie)
        {
            StringBuilder counties = new StringBuilder();
            foreach (var item in movie.Countries)
            {
                counties.Append($"{item.Name}");
                if (item.Id != movie.Countries.Last().Id)
                    counties.Append(", ");
            }

            return counties;
        }

        private static StringBuilder CreateActors(List<Person> persons)
        {
            StringBuilder actors = new StringBuilder();
            foreach (var item in persons)
            {
                if (item.ProfessionId == 2)
                {
                    actors.Append($"{item.FirstName} {item.LastName}");
                    if (item.Id != persons.Last().Id)
                        actors.Append(", ");
                }
            }

            return actors;
        }

        public List<Movie> GetAllFromAPIByTheater(long id)
        {
            var moviesIds = JsonFromURL<MoviesByTheater>.ConvertToObject($"{host}/cinema/{id}/shows{keyAPI}&size=1000&detalization=FULL");

            var movies = new List<Movie>();
            foreach (var item in moviesIds.Movies)
            {
                var movie = GetFromAPI(item.Id);
                movies.Add(movie);
            }

            return movies;
        }

        public List<MovieDb> GetAllBestFromApi()
        {
            var movies = unitOfWork.Movies.GetAll().OrderBy(m => m.Premiere).Reverse().Take(6).ToList();           
            return movies;
        }


        public List<MovieDb> GetAllTodayFromApi()
        {
            var movies = unitOfWork.Movies.GetAll().Take(8).ToList();
            return movies;
        }

        public List<Movie> GetAllOfCinemasFromApi()
        {
            var florenceMovies = GetAllFromAPIByTheater(8);
            var boomerMovies = GetAllFromAPIByTheater(281);

            var merged = new List<Movie>(florenceMovies);
            merged.AddRange(boomerMovies.Where(m2 =>
                            florenceMovies.All(m1 => m1.Id != m2.Id)));

            var movies = merged;

            return movies;
        }

        public List<MovieDb> GetAllWithBanners()
        {
            var movies = unitOfWork.Movies.GetAll();
            return movies.Where(m => m.BannerUrl != null).ToList();
        }

        private List<Person> GetPersons(long id, PersonesByMovie personsByMovie)
        {
            var persons = new List<Person>();
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
                var imgPath = $"{host}/film/image/{imageId.Value}{keyAPI}&width=1000&height=600&ratio=1";
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

        public void AddBannerToDb(Banner banner)
        {
            unitOfWork.Banners.AddOrUpdate(banner);
            unitOfWork.Save();
        }


        public Banner GetBannerFromDb(long id)
        {
            return unitOfWork.Banners.Get(id);           
        }

    }
}
