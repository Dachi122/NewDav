using Ambebi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewDav;

namespace Ambebi
{
    public class AmbebiSV : IAmbebi
    {
        private readonly dbaContext _context;

        public AmbebiSV(dbaContext context)
        {
            _context = context;
        }

        public Ambebi CreateAmbebi(DTOAmbebi ambebi0)
        {
            if (_context.Ambebis == null)
            {
                return null;
            }

            Ambebi ambebi = new Ambebi();
            ambebi.Title = ambebi0.Title;
            ambebi.Content = ambebi0.Content;
            ambebi.CreatedDateTime = DateTime.Now;

            _context.Ambebis.Add(ambebi);

            _context.SaveChanges();


            return ambebi;
        }

        public bool DeleteAmbebi(int id)
        {
            if (_context.Ambebis == null)
            {
                return false;
            }
            var ambebi = _context.Ambebis.Find(id);

            if (ambebi == null)
            {
                return false;
            }


            _context.Ambebis.Remove(ambebi);
            _context.SaveChanges();

            return true;

        }

        public Ambebi GetAmbebi(int id)
        {
            if (_context.Ambebis == null)
            {
                return null;
            }
            var ambebi = _context.Ambebis.Find(id);

            if (ambebi == null)
            {
                return null;
            }

            return ambebi;
        }

        public List<Ambebi> GetAmbebi()
        {
            if (_context.Ambebis == null)
            {
                return null;
            }
            return _context.Ambebis.ToList();
        }


        public List<Ambebi> GetAmbebi(DTODateTimeInterval requ)
        {

            if (_context.Ambebis == null)
            {
                return null;
            }
            return _context.Ambebis.Where(a => a.CreatedDateTime.Value.Date >= requ.DateTimeFrom && a.CreatedDateTime.Value.Date <= requ.DateTimeTo).ToList();
        }


        
        public Ambebi UpdateAmbebi(int id, DTOAmbebiUpdate ambebi)
        {
            if (id != ambebi.AmbebiId)
            {
                return null;
            }

            var ambebiDedani = _context.Ambebis.Find(id);
            ambebiDedani.Title = ambebi.Title;
            ambebiDedani.Content = ambebi.Content;
            _context.Update(ambebiDedani);

            //_context.Entry(ambebi).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmbebiExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return ambebiDedani;
        }

        private bool AmbebiExists(int id)
        {
            return (_context.Ambebis?.Any(e => e.AmbebiId == id)).GetValueOrDefault();
        }

    }
}
