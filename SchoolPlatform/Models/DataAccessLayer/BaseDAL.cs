using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public class BaseDAL<T> where T: class
    {
        public SchoolDataContext context;
        public DbSet<T> values;

        public BaseDAL(SchoolDataContext context)
        {
            this.context = context;
            values = context.Set<T>();
        }
        public void Add(T value)
        {
            values.Add(value);
            context.SaveChanges();
        }

        public void Update(T value)
        {
            context.Update(value);
            context.SaveChanges();
        }

        public void Delete(T value)
        {
            values.Remove(value);
            context.SaveChanges();
        }

        public T? Get(int id)
        {
            return values.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return values.ToList();
        }
    }
}
