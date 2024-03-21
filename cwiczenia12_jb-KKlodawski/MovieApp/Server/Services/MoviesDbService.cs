using System;
using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Data;
using MovieApp.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using IdentityModel.Internal;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Shared.DTOs;
using OkResult = System.Web.Http.Results.OkResult;

namespace MovieApp.Server.Services
{
    public interface IMoviesRepository
    {

    }

    public interface IMoviesDbService
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> AddMovie(MovieAddDto newMovie);
        Task<Movie> EditMovie(int id, MovieDTO updatedMovie);
        Task<Movie> GetMovie(int movieId);
        Task<Movie> DeleteMovie(int id);
        Task<List<Person>> GetPersons();
        Task<List<Genre>> GetGenres();
    }

    public class MoviesDbService : IMoviesDbService
    {
        private ApplicationDbContext _context;

        public MoviesDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddMovie()
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> GetMovie(int movieId)
        {
            return _context.Movies.FirstAsync(e => e.Id == movieId);
        }

        public Task<List<Movie>> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.Title).ToListAsync();
        }
        
        public async Task<Movie> EditMovie(int movieId, MovieDTO updatedMovie)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var movie = await _context.Movies.FirstAsync(e => e.Id == movieId);

                    movie.Poster = updatedMovie.Poster;
                    movie.Summary = updatedMovie.Summary;
                    movie.Title = updatedMovie.Title;
                    movie.Trailer = updatedMovie.Trailer;
                    movie.InTheaters = updatedMovie.InTheaters;
                    movie.ReleaseDate = updatedMovie.ReleaseDate;

                    await _context.SaveChangesAsync();
                    
                    transaction.Commit();

                    return movie;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var movie = await _context.Movies.FirstAsync(e => e.Id == id);
                    //var MovieActors = _context.MoviesActors.Where(e => e.MovieId == id);
                    //var MovieGenres = _context.MoviesGenres.Where(e => e.MovieId == id);

                    //_context.MoviesActors.RemoveRange(MovieActors);
                    //_context.MoviesGenres.RemoveRange(MovieGenres);
                    _context.Movies.Remove(movie);

                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    return movie;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public Task<List<Person>> GetPersons()
        {
            return _context.People.ToListAsync();
        }

        public Task<List<Genre>> GetGenres()
        {
            return _context.Genres.ToListAsync();
        }

        public async Task<Movie> AddMovie(MovieAddDto newMovie)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Movie movie = new Movie
                    {
                        Title = newMovie.Title,
                        Summary = newMovie.Summary,
                        InTheaters = newMovie.InTheaters,
                        Trailer = newMovie.Trailer,
                        ReleaseDate = newMovie.ReleaseDate,
                        Poster = newMovie.Poster
                    };
                    _context.Movies.Add(movie);
                    await _context.SaveChangesAsync();

                    if (newMovie.GenreId != 0 && newMovie.GenreId != null)
                    {
                        var genre = await _context.Genres.FirstAsync(e => e.Id == newMovie.GenreId);

                        MoviesGenres mg = new MoviesGenres
                        {
                            Movie = movie,
                            MovieId = movie.Id,
                            Genre = genre,
                            GenreId = (int)newMovie.GenreId
                        };

                        _context.MoviesGenres.Add(mg);
                        await _context.SaveChangesAsync();
                    }

                    if (newMovie.PersonId != 0 && newMovie.PersonId != null)
                    {
                        var person = await _context.People.FirstAsync(e => e.Id == newMovie.PersonId);

                        MoviesActors ms = new MoviesActors
                        {
                            MovieId = movie.Id,
                            Movie = movie,
                            Person = person,
                            PersonId = (int)newMovie.PersonId,
                            Order = (int)newMovie.Order,
                            Character = newMovie.Character
                        };

                        _context.MoviesActors.Add(ms);
                        await _context.SaveChangesAsync();
                    }
                    
                    transaction.Commit();
                    return null;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
               
            }
            
        }
    }
}
