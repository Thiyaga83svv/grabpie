using GrabPie.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabPie.Repository
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(
            AppDbContext appDbContext)

        {
            _appDbContext = appDbContext;
        }
        IEnumerable<Pie> IPieRepository.AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        IEnumerable<Pie> IPieRepository.PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }
        public Pie GetPieById(int pieId)
        {

            return _appDbContext.Pies.FirstOrDefault(f => f.PieId == pieId);
        }
    }
}
