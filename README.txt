1. Open the .sln file
2. Hit f5
3. Follow the on screen indications

Optional: if it does not run, remember to change optionsBuilder.UseSqlServer, so it matches your own.
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("__________________");
        }