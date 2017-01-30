namespace project1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using project1.Models;
    using project1.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<project1.DAL.projectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "project1.DAL.projectContext";
            
        }

        protected override void Seed(project1.DAL.projectContext context)

        {
            context.album.AddOrUpdate(
               a => a.id,
               new album() { id = 1, names = "Dark Side of the Moon", yearReleased = 1972, producer = "Some Guy", recodLabel = "IDK lol", Price = 10.00M }
               );

            context.song.AddOrUpdate(
                a => a.ID,
                new song() { ID = 1, Name = "Time", Duration = "3:33", Lyrics = "Some singy stuff" }
                );
            context.bands.AddOrUpdate(
                a => a.ID,
                new bands() { ID = 1, Name = "back street boys", genre = "Rock" }

                );

            album newAlbum = context.album.Find(1);
            song newSong = context.song.Find(1);

            newAlbum.songs.Add(newSong);
            bands newBand = context.bands.Find(1);
            
            newBand.albums.Add(newAlbum);



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
