﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookweb.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
: base(options)
        {
        }
        public DbSet<book> Bookings { get; set; } = null!;
    }
}

