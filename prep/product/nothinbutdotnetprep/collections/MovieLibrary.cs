using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies;
        }

        public void add(Movie movie)
        {
            foreach (var movie1 in movies)
            {
                if (movie1 == movie)
                    return;
            }

            movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                movies.Sort((left,right)=>right.title.CompareTo(left.title));

                return movies;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar ||
                    movie.production_studio == ProductionStudio.Disney)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                movies.Sort((left, right) => left.title.CompareTo(right.title));

                return movies;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return all_movies_of(Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return all_movies_of(Genre.action);
        }

        private IEnumerable<Movie> all_movies_of(Genre genre)
        {
            foreach (var movie in movies)
            {
                if (movie.genre == genre)
                    yield return movie;
            }
        }

        

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            movies.Sort((left, right) => right.date_published.CompareTo(left.date_published));

            return movies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            movies.Sort((left, right) => left.date_published.CompareTo(right.date_published));

            return movies;
        }
    }
}