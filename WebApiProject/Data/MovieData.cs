//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApiProject.Models;

//namespace WebApiProject.Data
//{
//    public class MovieData
//    {
//        public static void Initialize(IApplicationBuilder app)
//        {
//            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
//            {
//                var context = serviceScope.ServiceProvider.GetService<DBContext>();
//                context.Database.EnsureCreated();
//                //context.Database.Migrate();

//                // Look for any ailments
//                if (context.Movies != null && context.Movies.Any())
//                    return; // DB has already been seeded

//                var movies = GetMovies().ToArray();
//                if (context.Movies != null) context.Movies.AddRange(movies);
//                context.SaveChanges();
//            }
//        }
//        public static List<Movie> GetMovies()
//        {
//            List<Movie> movies = new List<Movie>() {
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dark Knight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="Tnight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="TheKnight",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Daght",Director=" Christopher Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Dt",Director=" Chrilan",Genre=" Action",ReleaseDate="18 Jy 2008",
//                    Description ="When the menace sterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//                new Movie {Title="The Daright",Director=" Christopr Nolan",Genre=" Action",ReleaseDate="18 July 2008",
//                    Description ="When thes from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
//                    Poster ="poster"},
//            };
//            return movies;
//        }
//    }
//}
