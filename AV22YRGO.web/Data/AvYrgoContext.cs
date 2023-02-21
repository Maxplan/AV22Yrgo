using AV22YRGO.web.Models;
using Microsoft.EntityFrameworkCore;

namespace AV22YRGO.web.Data;

public class AvYrgoContext : DbContext
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Event> Events => Set<Event>();
    public AvYrgoContext(DbContextOptions options) : base(options){}
}

