using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            PlacementContext context3 = new PlacementContext();

            using (PlacementContext context2 = new PlacementContext())
            {
                var ptx = (from r in context2.Placements select r);


                var students = (from s in context2.Placements
                                //orderby s.ClientNumber
                                .Take(100)
                                select s).ToList<Placement>();

            }

            var test = context3.Placements;




            using (var context = new MyContext())
            {

                // Create and save a new Students
                Console.WriteLine("Adding new students");

                var student = new Student
                {
                    ID = 1,
                    FirstMidName = "Alain",
                    LastName = "Bomer",
                    //EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.Students.Add(student);

                var student1 = new Student
                {
                    ID = 2,
                    FirstMidName = "Mark",
                    LastName = "Upston",
                    //EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.Students.Add(student1);
                //context.Entry(student).State = EntityState.Added;
                context.SaveChanges();

                // Display all Students from the database
                var students = (from s in context.Students
                                orderby s.FirstMidName
                                select s).ToList<Student>();

                Console.WriteLine("Retrieve all Students from the database:");

                foreach (var stdnt in students)
                {
                    string name = stdnt.FirstMidName + " " + stdnt.LastName;
                    Console.WriteLine("ID: {0}, Name: {1}", stdnt.ID, name);
                }



                var authors = context.Database
                    .SqlQuery<Student>("EXECUTE dbo.GetAllAuthors")
                    .ToList();

                var books = context.Database
    .SqlQuery<Student>("EXECUTE dbo.GetBookById 2")
    .ToList();



                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Console.ReadLine();
            }


        }



        public enum Grade
        {
            A, B, C, D, F
        }

        public class Enrollment
        {
            public int EnrollmentID { get; set; }
            public int CourseID { get; set; }
            public int StudentID { get; set; }
            public Grade? Grade { get; set; }

            public virtual Course Course { get; set; }
            public virtual Student Student { get; set; }
        }

        public class Student
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int ID { get; set; }
            public string LastName { get; set; }
            public string FirstMidName { get; set; }
            //public DateTime EnrollmentDate { get; set; }

            //public virtual ICollection<Enrollment> Enrollments { get; set; }
        }

        public class Course
        {
            public int CourseID { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }

            public virtual ICollection<Enrollment> Enrollments { get; set; }
        }

        public class Placement
        {
            [Key]
            public int ClientNumber { get; set; }
            public int ManagementNumber { get; set; }
            public string Community { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SSN { get; set; }
            public string TenantCode { get; set; }
            public DateTime ListedDate { get; set; }
            public DateTime MoveInDate { get; set; }
            public DateTime MoveOutDate { get; set; }
            public Decimal Principal { get; set; }
            public Decimal amtdueclient { get; set; }
            public Decimal amtremaining { get; set; }
        }

        public class MyContext : DbContext
        {
            public MyContext() : base("MyContext")
            {
                //this.Database.Connection.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=master;User Id=saa;Password=Asdfasdf1!;Integrated Security=False;";
                this.Database.Connection.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            }
            //protected override void OnModelCreating(DbModelBuilder modelBuilder)
            //{
            //    Database.SetInitializer<MyContext>(null);
            //    base.OnModelCreating(modelBuilder);
            //}

            public virtual DbSet<Course> Courses { get; set; }
            public virtual DbSet<Enrollment> Enrollments { get; set; }
            public virtual DbSet<Student> Students { get; set; }
        }



        public class PlacementContext : DbContext
        {
            public PlacementContext() : base("PlacementContext")
            {
                //this.Database.Connection.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=master;User Id=saa;Password=Asdfasdf1!;Integrated Security=False;";
                this.Database.Connection.ConnectionString = "Server=IR-SQL-DEV1;Database=AGENCY;Database=agency;Trusted_Connection=True;";

            }
            //protected override void OnModelCreating(DbModelBuilder modelBuilder)
            //{
            //    Database.SetInitializer<MyContext>(null);
            //    base.OnModelCreating(modelBuilder);
            //}

            public virtual DbSet<Placement> Placements { get; set; }

        }


    }
}

