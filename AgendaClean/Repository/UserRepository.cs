using AgendaClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaClean.Repository
{
    public class UserRepository : Repository<UserModel>
    {
        public override void Add(UserModel entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public override UserModel Find(string id)
        {
            return _context.Users.Find(id);
        }

        public override ICollection<UserModel> FindAll()
        {
            return _context.Users.ToList() ;
        }

        public override void Remove(UserModel entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public override void Update(UserModel entity)
        {
            var userDB = _context.Users.Find(entity.Id);
            if (entity == null)
                throw new NullReferenceException("Não foi encontrado o paciente no banco de dados.");
            _context.Entry(userDB).CurrentValues.SetValues(entity);
            _context.Entry(userDB).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}