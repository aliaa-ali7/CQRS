using CQRS_Library.Data;
using CQRS_Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Library.Repos
{
    public class itemRepository : IitemRepository
    {
        private readonly AppDbContext appDbContext;

        public itemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public int DeleteItem(int id)
        {
            var item = appDbContext.Item.Where(x => x.Id == id).FirstOrDefault();
            if(item != null)
            {
                appDbContext.Item.Remove(item);
            }
            return appDbContext.SaveChanges();

        }

        public List<Items> GetItems()
        {
            return appDbContext.Item.ToList();
        }

        public Items GetItem(int id)
        {
            var item = appDbContext.Item.Where(x => x.Id == id).FirstOrDefault();

            return item ?? new();
        }

        public int InsertItem(Items item)
        {
           appDbContext.Item.Add(item);

            return appDbContext.SaveChanges();
        }

        public int UpdateItem(Items item)
        {
            try {
                appDbContext.Item.Attach(item);
                appDbContext.Entry(item).State = EntityState.Modified;
                return 1;
            }catch
            {
                return 0;
            }
        }
    }
}
