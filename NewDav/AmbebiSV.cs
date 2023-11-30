using Ambebi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewDav;
using NuGet.Packaging.Signing;
using System.Security.Cryptography.X509Certificates;

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


        public Ambebi CreateAmbebi30(DTOAmbebi ambebi0)
        {
            if (_context.Ambebis == null)
            {
                return null;
            }

            if (ambebi0.Title.Length > 30)
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





        public List<Ambebi> GetAmbebiFilterFour(DTOSearch requ)
        {

            var res = Splitter(requ.Search);

            List<Ambebi> AllAmbebi = new List<Ambebi>();

            for (int i = 0; i < res.Length; i++)
            {

                string word = res[i];

                DTOSearch search = new DTOSearch();

                search.Search = word;

                var list0 = GetAmbebiFilterTitle(search);

                AllAmbebi.AddRange(list0);
            }

            List<Ambebi> AllAmbebiDistinct = AllAmbebi.Distinct().ToList();



            return AllAmbebiDistinct;

        }




        public List<Ambebi> GetAmbebiFilterTitle(DTOSearch requ)
        {

            if (_context.Ambebis == null)
            {
                return null;
            }
            return _context.Ambebis.Where(a => a.Title.Contains(requ.Search)).ToList();

                     

        }

        

        public List<Ambebi> GetAmbebiFilterContent(DTOSearch requ)
        {

            if (_context.Ambebis == null)
            {
                return null;
            }
            return _context.Ambebis.Where(a => a.Content.Contains(requ.Search)).ToList();


        }



        public List<Ambebi> GetAmbebiFilterBoth(DTOSearch requ)
        {

            if (_context.Ambebis == null)
            {
                return null;
            }
            return _context.Ambebis.Where(a => a.Title.Contains(requ.Search) || a.Content.Contains(requ.Search)).ToList();


        }



        public List<DTOAmbebiDateOnly> GetAmbebiDateOnly()
        {
            if (_context.Ambebis == null)
            {
                return null;
            }
            return _context.Ambebis.Select(a => new DTOAmbebiDateOnly() { CreatedDateTime = a.CreatedDateTime.Value.Date.ToString("yyyy-MM-dd"), AmbebiId = a.AmbebiId, Content = a.Content, Title = a.Title }).ToList();
        }




        public List<Ambebi> GetAmbebi(DTODateTimeInterval requ)
        {

            if (_context.Ambebis == null)
            {
                return null;
            }
            return _context.Ambebis.Where(a => a.CreatedDateTime.Value.Date >= requ.DateTimeFrom && a.CreatedDateTime.Value.Date <= requ.DateTimeTo).ToList();


        }


        public List<Ambebi> GetAmbebi(DTODateTo requTo, DTODateFrom requFrom)
        {

            if (_context.Ambebis == null)
            {
                return null;
            }
            return _context.Ambebis.Where(a => a.CreatedDateTime.Value.Date <= requTo.DateTo && a.CreatedDateTime.Value.Date >= requFrom.DateFrom).ToList();


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

        public string[] Splitter(string search)
        {
            string cleanedWord1 = search.Replace(',', ' ');
            string cleanedWord2 = cleanedWord1.Replace("  ", " ");
            string cleanedWord3 = cleanedWord2.Trim();

            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;

            var res = cleanedWord3.Split(' ', options);




            return res;
        }
    }
}
