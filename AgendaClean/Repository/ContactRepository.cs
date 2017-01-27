using AgendaClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaClean.Repository
{
    public class ContactRepository : Repository<ContactModel>
    {
        public override void Add(ContactModel entity)
        {
            _context.Contacts.Add(entity);
            _context.SaveChanges();
        }

        public override ContactModel Find(string id)
        {
            return _context.Contacts.Find(id);
        }

        public override ICollection<ContactModel> FindAll()
        {
            return _context.Contacts.ToList() ;
        }

        public override void Remove(ContactModel entity)
        {
            _context.Contacts.Remove(entity);
            _context.SaveChanges();
        }

        public override void Update(ContactModel entity)
        {
            var userDB = _context.Contacts.Find(entity.Id);
            if (entity == null)
                throw new NullReferenceException("Não foi encontrado o paciente no banco de dados.");
            _context.Entry(userDB).CurrentValues.SetValues(entity);
            _context.Entry(userDB).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}