﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLayer.Repostitory
{
    public class PharmacistRepository
    {
        private readonly ClinicalDbContext _context;

        public PharmacistRepository()
        {
            _context = new ClinicalDbContext();
        }
        public List<Pharmacist> GetAllPharmacists()
        {
            return _context.Pharmacists.ToList();
        }
        public Pharmacist GetPharmacistById(int pharmacistId)
        {
            return _context.Pharmacists.Find(pharmacistId);
        }
        public Pharmacist FindPharmacistByEmail(string email)
        {
            return _context.Pharmacists.FirstOrDefault(f => f.Email == email);
        }
        public bool checkPharmistLogin(Pharmacist pharmacist)
        {
            return _context.Pharmacists.Any(d => d.Email == pharmacist.Email && d.Password == pharmacist.Password);//for login
        }
        public void AddPharmacist(Pharmacist pharmacist)
        {
            _context.Pharmacists.Add(pharmacist);
            _context.SaveChanges();
        }
        public void UpdatePharmacist(Pharmacist pharmacist)
        {
            _context.Entry(pharmacist).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeletePharmacist(int pharmacistId)
        {
            var pharmacist = _context.Pharmacists.Find(pharmacistId);
            if (pharmacist != null)
            {
                _context.Pharmacists.Remove(pharmacist);
                _context.SaveChanges();
            }
        }
        public bool PharmacistExists(int pharmacistId)
        {
            return _context.Pharmacists.Any(e => e.PharmacistId == pharmacistId);
        }
    }
}

    

