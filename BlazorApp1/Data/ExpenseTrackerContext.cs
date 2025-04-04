﻿using BlazorApp1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    //categori
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                new Category() { Id=1, Name="Food"},
                new Category() { Id=2, Name="Travel" },
                new Category() { Id=3,Name="Entertainment" },
                new Category() {Id=4, Name="Education" },
                new Category() {Id=5, Name="Clothes" },
                new Category() {Id=6, Name="House" },

            });
            //expenses
            modelBuilder.Entity<Expense>()
               .HasOne(e => e.Category)
               .WithMany() 
               .HasForeignKey(e => e.CategoryId);

         
        }
    }
}
