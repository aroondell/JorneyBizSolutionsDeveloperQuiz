using JourneyBizDatabase.Entities;
using JourneyBizDatabase.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyBizDatabase
{
    public class JourneyBizDatabaseProvider
    {
        private readonly JourneyBizContext _context;
        public JourneyBizDatabaseProvider(JourneyBizContext journeyBizContext)
        {
            _context = journeyBizContext;
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            var resultSet = await _context.Set<T>().ToListAsync();
            return resultSet;
        }

        public async Task<T> GetById<T>(int id) where T : class, IEntity
        {
            return await _context.Set<T>().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteById<T>(int id) where T : class, IEntity
        {
            T entity = GetById<T>(id).Result;
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<T> UpdateRecord<T>(T updatedRecord) where T : class, IEntity
        {
            if (updatedRecord.Id == 0)
            {
                CreateNewRecord(updatedRecord);
                return updatedRecord;
            }

            T oldEntity = GetById<T>(updatedRecord.Id).Result;

            if (oldEntity == null)
            {
                CreateNewRecord(updatedRecord);
                return updatedRecord;
            }

            oldEntity.CopyFrom(updatedRecord);
            await _context.SaveChangesAsync();
            return updatedRecord;
        }

        protected void CreateNewRecord<T>(T newRecord) where T : class, IEntity
        {
            _context.Set<T>().Add(newRecord);
            _context.SaveChanges();
        }
    }
}
