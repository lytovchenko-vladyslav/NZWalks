using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulty
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("5c516eec-c4f0-4b0b-9af7-799f881bcfca"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("95d87504-2845-4693-98b3-4b052b817e54"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("c0f57b50-cdcf-4597-8b8b-721127e68f1a"),
                    Name = "Hard"
                },
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed Data for Regions
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("b13cf54a-6f5c-4613-8ce3-f944e74a0c56"),
                    Name = "ASuckland",
                    Code = "ASKL",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fimagem&psig=AOvVaw1-RxayNMuCv7Un0jXyokNv&ust=1760872815555000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCPDNlsjQrZADFQAAAAAdAAAAABAE"
                },
                new Region
                {
                    Id = Guid.Parse("3b9f4bfb-6419-4f4c-b81d-1b14eb7204e6"),
                    Name = "Northland",
                    Code = "NRT",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fimagem&psig=AOvVaw1-RxayNMuCv7Un0jXyokNv&ust=1760872815555000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCPDNlsjQrZADFQAAAAAdAAAAABAE"
                },
                new Region
                {
                    Id = Guid.Parse("cf7bca57-d87d-4a30-814c-0e8b5f1eafc9"),
                    Name = "New York",
                    Code = "NY",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fimagem&psig=AOvVaw1-RxayNMuCv7Un0jXyokNv&ust=1760872815555000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCPDNlsjQrZADFQAAAAAdAAAAABAE"
                },
                new Region
                {
                    Id = Guid.Parse("0dbb8f1f-59e4-4a92-b77a-a0224842897d"),
                    Name = "Warsaw",
                    Code = "WRS",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fimagem&psig=AOvVaw1-RxayNMuCv7Un0jXyokNv&ust=1760872815555000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCPDNlsjQrZADFQAAAAAdAAAAABAE"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}