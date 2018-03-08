﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Cinema.Domain.EF;
using Cinema.Domain.Entities;

namespace Cinema.Domain.Repositories
{
    public class EFUnitOfWork 
    {
        private DbContext db;

        private TestRepository testRepository;

        private CountryRepository countryRepository;
        private GenreRepository genreRepository;
        private ImageRepository imageRepository;
        private MovieRepository movieRepository;
        private PersonRepository personRepository;
        private PosterRepository posterRepository;
        private TheaterRepository theaterRepository;
        private TrailerRepository trailerRepository;


        
        public EFUnitOfWork(string connectionString)
        {
            db = new CotsContext(connectionString);
        }
        public Repository<Test> Testes
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(db);
                return testRepository;
            }
        }

        public Repository<Person> Persons
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(db);
                return personRepository;
            }
        }

        public Repository<Genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public Repository<Movie> Movies
        {
            get
            {
                if (movieRepository == null)
                    movieRepository = new MovieRepository(db);
                return movieRepository;
            }
        }

        public Repository<Image> Images
        {
            get
            {
                if (imageRepository == null)
                    imageRepository = new ImageRepository(db);
                return imageRepository;
            }
        }

        public Repository<Country> Countries
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new CountryRepository(db);
                return countryRepository;
            }
        }

        public Repository<Poster> Posters
        {
            get
            {
                if (posterRepository == null)
                    posterRepository = new PosterRepository(db);
                return posterRepository;
            }
        }

        public Repository<Theater> Theaters
        {
            get
            {
                if (theaterRepository == null)
                    theaterRepository = new TheaterRepository(db);
                return theaterRepository;
            }
        }

        public Repository<Trailer> Trailers
        {
            get
            {
                if (trailerRepository == null)
                    trailerRepository = new TrailerRepository(db);
                return trailerRepository;
            }
        }
    


        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
