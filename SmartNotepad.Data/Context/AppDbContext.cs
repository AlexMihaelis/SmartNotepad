using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartNotepad.Domain.Models;


namespace SmartNotepad.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<ExerciseTag> ExerciseTags { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка отношений "один-ко-многим" Exercise и Category
            modelBuilder.Entity<ExerciseCategory>().HasKey(ec => new { ec.ExerciseId, ec.CategoryId }); // Составной ключ

            modelBuilder.Entity<ExerciseCategory>().HasOne(ec => ec.Exercise) // Один ExcCateg соответсвует одному Exc
                                                   .WithMany(e => e.ExerciseCategories) // Один Exc может именть несколько ExcCateg
                                                   .HasForeignKey(ec => ec.ExerciseId); // FK для связи

            modelBuilder.Entity<ExerciseCategory>().HasOne(ec => ec.Category) 
                                                   .WithMany(e => e.ExerciseCategories) 
                                                   .HasForeignKey(ec => ec.CategoryId);

            // Настройка отношений "один-ко-многим" Recipe и Category
            modelBuilder.Entity<RecipeCategory>().HasKey(rc => new { rc.RecipeId, rc.CategoryId }); // Составной ключ

            modelBuilder.Entity<RecipeCategory>().HasOne(rc => rc.Recipe)
                                                 .WithMany(r => r.RecipeCategories)
                                                 .HasForeignKey(rc => rc.RecipeId);

            modelBuilder.Entity<RecipeCategory>().HasOne(rc => rc.Category)
                                                 .WithMany(r => r.RecipeCategories)
                                                 .HasForeignKey(rc => rc.CategoryId);

            // Настройка отношений "один-ко-многим" Note и Category
            modelBuilder.Entity<NoteCategory>().HasKey(nc => new { nc.NoteId, nc.CategoryId }); // Составной ключ

            modelBuilder.Entity<NoteCategory>().HasOne(nc => nc.Note)
                                               .WithMany(n => n.NoteCategories)
                                               .HasForeignKey(nc => nc.NoteId);

            modelBuilder.Entity<NoteCategory>().HasOne(nc => nc.Category)
                                               .WithMany(c => c.NoteCategories)
                                               .HasForeignKey(nc => nc.CategoryId);

            // Настройка отношений "один-ко-многим" Exercise и Tag
            modelBuilder.Entity<ExerciseTag>().HasKey(et => new { et.ExerciseId, et.TagId }); // Составной ключ

            modelBuilder.Entity<ExerciseTag>().HasOne(et => et.Exercise)
                                              .WithMany(e => e.ExerciseTags)
                                              .HasForeignKey(et => et.ExerciseId);

            modelBuilder.Entity<ExerciseTag>().HasOne(et => et.Tag)
                                              .WithMany(e => e.ExerciseTags)
                                              .HasForeignKey(et => et.TagId);

            // Настройка отношений "один-ко-многим" Recipe и Tag
            modelBuilder.Entity<RecipeTag>().HasKey(rt => new { rt.RecipeId, rt.TagId }); // Составной ключ

            modelBuilder.Entity<RecipeTag>().HasOne(rt => rt.Recipe)
                                            .WithMany(r => r.RecipeTags)
                                            .HasForeignKey(rt => rt.RecipeId);

            modelBuilder.Entity<RecipeTag>().HasOne(rt => rt.Tag)
                                            .WithMany(r => r.RecipeTags)
                                            .HasForeignKey(rc => rc.TagId);

            // Настройка отношений "один-ко-многим" Note и Tag
            modelBuilder.Entity<NoteTag>().HasKey(nt => new { nt.NoteId, nt.TagId }); // Составной ключ

            modelBuilder.Entity<NoteTag>().HasOne(nt => nt.Note)
                                          .WithMany(n => n.NoteTags)
                                          .HasForeignKey(nt => nt.NoteId);

            modelBuilder.Entity<NoteTag>().HasOne(nt => nt.Tag)
                                          .WithMany(n => n.NoteTags)
                                          .HasForeignKey(nt => nt.TagId);

            // Настройка отношений "один-ко-многим" User и Note
            modelBuilder.Entity<Note>().HasKey(n => n.Id);

            modelBuilder.Entity<Note>().HasOne(n => n.User)
                                       .WithMany(u => u.Notes)
                                       .HasForeignKey(n => n.UserId);

            //// Настройка отношений "один-ко-многим" User и Exercise
            //modelBuilder.Entity<Exercise>().HasOne(e => e.User)
            //                           .WithMany(u => u.Exercises)
            //                           .HasForeignKey(e => e.UserId);

            // Настройка отношений "один-ко-многим" User и Recipe
            modelBuilder.Entity<Recipe>().HasOne(r => r.User)
                                       .WithMany(u => u.Recipes)
                                       .HasForeignKey(r => r.UserId);

            // Настройка отношений "один-ко-многим" User и Board
            modelBuilder.Entity<Board>().HasOne(b => b.User)
                                        .WithMany(u => u.Boards)
                                        .HasForeignKey(b => b.UserId);

            // Настройка отношений "один-ко-многим" Exercise и Board
            modelBuilder.Entity<Exercise>().HasOne(e => e.Board)
                                           .WithMany(b => b.Exercises)
                                           .HasForeignKey(e => e.BoardId);

            // Настройка отношений "один-ко-многим" Recipe и Ingredient
            modelBuilder.Entity<Ingredient>().HasOne(i => i.Recipe)
                                             .WithMany(r => r.Ingredients)
                                             .HasForeignKey(i => i.RecipeId);

            // настройка отношений "один-ко-многим" Ingredient и Unit
            modelBuilder.Entity<Unit>().HasOne(u => u.Ingredient)
                                       .WithMany(i => i.Units)
                                       .HasForeignKey(u => u.IngredientId);

            #region а-ля "Примеры"
            //modelBuilder.Entity<Exercise>().HasMany(ec => ec.Categories)
            //                                       .WithMany(e => e.Exercises)
            //                                       .UsingEntity<ExerciseCategory>();

            // Отношения "один-ко-многим"


            //Exercises.Where(x => x.ExerciseCategories.Any(y => y.Category.Name == categoryName))
            //Exercises.Where(x => x.Categories.Any(y => y.Name == categoryName))
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ELINA;Database=SmartNotepad;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
