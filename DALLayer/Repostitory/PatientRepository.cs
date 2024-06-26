﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLayer.Repostitory
{
    public class PatientRepository 
    {
        private readonly ClinicalDbContext _Db; //define database class object

        public PatientRepository()
        {
            _Db = new ClinicalDbContext(); 
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _Db.Patients.ToList(); 
        }
        public void InsertPatient(Patient patient)
        {
            _Db.Patients.Add(patient);
            Save();
        }
        public void UpdatePatient(Patient patient)
        {
            _Db.Entry(patient).State = EntityState.Modified;
            Save();
        }
        public bool checkPatientLogin(Patient patient)
        {
            return _Db.Patients.Any(d => d.Email == patient.Email && d.Password == patient.Password);
        }
        public void DeletePatient(int id)
        {
            Patient found = _Db.Patients.Find(id);
            if (found != null)
            {
                _Db.Patients.Remove(found);
                Save();
            }
        }
        public void Save()
        {
            _Db.SaveChanges();
        }
        public Patient FindPatientById(int id)
        {
            return _Db.Patients.Find(id); 
        }
        public Patient FindPatientByEmail(string Email)
        {
            return _Db.Patients.FirstOrDefault(pro => pro.Email == Email); 
        }
        public IEnumerable<Patient> FindPatientWithName(string Name)
        {
            return _Db.Patients.Where(meds => meds.Name.ToLower().Contains(Name.ToLower()));
        }   
    }
}
