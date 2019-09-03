using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecopetrol.Api.Data
{
    using Models;
    public class FaqDbContext : DbContext
    {
        public FaqDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Faq> Faqs { get; set; }
    }
}
