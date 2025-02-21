using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CozyCloudBlanket.Models;

namespace CozyCloudBlanket.Data
{
    public class CozyCloudBlanketContext : DbContext
    {
        public CozyCloudBlanketContext (DbContextOptions<CozyCloudBlanketContext> options)
            : base(options)
        {
        }

        public DbSet<CozyCloudBlanket.Models.Blanket> Blanket { get; set; } = default!;
    }
}
