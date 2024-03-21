namespace DALLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DALLayer.ClinicalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DALLayer.ClinicalDbContext context)
        {

            base.Seed(context);

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Patients', RESEED, 100)");
            //  //this line is used to the start the patients table from 100 value. 

            //  //Admin
            context.Admins.Add(new Admin { EmailId = "admin@cas.com", Password = "Admin@CAS7" });
            //our db class.Table name.Add(object of the table class {properties of table class})

            //Default Medicine
            context.Medicines.Add(new Medicine { MedicineName = "Aspirin", Stock = 10, Price = 600, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Paracetamol", Stock = 5, Price = 1000, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Naproxen", Stock = 52, Price = 2500, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Aspirinol", Stock = 60, Price = 450, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Feveron", Stock = 20, Price = 1800, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Dolo 650", Stock = 5, Price = 400, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Cetirizine", Stock = 10, Price = 200, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Formost 400", Stock = 25, Price = 250, Tax = 5, IsAvailable = true });
            context.SaveChanges();


            context.FrontOfficeExecutives.Add(new FrontOfficeExecutive { Name = "FrontOffCAS", DOB = DateTime.Parse("20-04-1998"), Address = "madras", Gender = "Male", Email = "frontoffice@cas.com", Password = "Front@CAS7", Phone = "2345678910" });

            context.Pharmacists.Add(new Pharmacist { Name = "Pharmacist", DOB = DateTime.Parse("20-07-1998"), Address = "Chennai", Gender = "Male", Email = "pharmacist@cas.com", Password = "Pharmacist@CAS7", Phone = "2345678910" });


            ////Method-2
            context.Specializations.Add(new Specialization { SpecializationName = "Neurologist" });
            context.Specializations.Add(new Specialization { SpecializationName = "Dentist" });
            context.Specializations.Add(new Specialization { SpecializationName = "Psychatrists" });
            context.Specializations.Add(new Specialization { SpecializationName = "Cardiologist" });
            context.Specializations.Add(new Specialization { SpecializationName = "Gynecologist" });
            context.SaveChanges();

            //default doctors
            context.Doctors.Add(new Doctor { DoctorName = "Abishek", DOB = DateTime.Parse("20-04-1995"), Email = "abi@cas.com", Password = "Abi@CAS7", Address = "Karnataka", Gender = "Male", Phone = "8587464286", IsAvailable = true, Timings = "11:00 AM - 1:00 PM", SpecializationId = 1 });
            context.Doctors.Add(new Doctor { DoctorName = "Saroj", DOB = DateTime.Parse("06-03-1995"), Email = "saro@cas.com", Password = "Saro@CAS7", Address = "TamilNadu", Gender = "Male", Phone = "9865327842", IsAvailable = true, Timings = "09:00 AM - 11:00 AM", SpecializationId = 3 });
            context.Doctors.Add(new Doctor { DoctorName = "smitha", DOB = DateTime.Parse("05-09-1995"), Email = "smitha@cas.com", Password = "Smitha@CAS7", Address = "Odisha", Gender = "FeMale", Phone = "8587464286", IsAvailable = true, Timings = "2:00 PM - 4:00 PM", SpecializationId = 4 });
            context.Doctors.Add(new Doctor { DoctorName = "Shyam", DOB = DateTime.Parse("24-07-1993"), Email = "shyam@cas.com", Password = "shyam@CAS7", Address = "Telangana", Gender = "Male", Phone = "7848572578", IsAvailable = true, Timings = "04:00 PM - 6:00 PM", SpecializationId = 5 });
            context.Doctors.Add(new Doctor { DoctorName = "Pallavi", DOB = DateTime.Parse("12-08-1994"), Email = "pallavi@cas.com", Password = "Pallavi@CAS7", Address = "AndhraPradesh", Gender = "FeMale", Phone = "7707858238", IsAvailable = true, Timings = "09:00 AM - 12:00 PM", SpecializationId = 2 });
            context.SaveChanges();

        }
    }
}