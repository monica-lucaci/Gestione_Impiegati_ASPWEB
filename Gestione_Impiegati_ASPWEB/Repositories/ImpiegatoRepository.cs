using Gestione_Impiegati_ASPWEB.Models;

namespace Gestione_Impiegati_ASPWEB.Repositories
{
    public class ImpiegatoRepository : IRepository<Impiegato>
    {

        private readonly GestioneImpiegatiContext _context;

        public ImpiegatoRepository(GestioneImpiegatiContext context)
        {
            _context = context;
        }


        public bool Delete(int id)
        {
            try
            {
                Impiegato tmp = _context.Impiegatos.Single(i => i.ImpiegatoId == id);
                _context.Impiegatos.Remove(tmp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public List<Impiegato> GetAll()
        {
            return _context.Impiegatos.ToList();
        }

        public Impiegato? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Impiegato? GetByMatricola(string varMatr)
        {
            Impiegato? tmp = null;
            try
            {
                tmp = _context.Impiegatos.FirstOrDefault(i => i.Matricola == varMatr);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tmp;
        }

        public bool Insert(Impiegato t)
        {
            try
            {
                _context.Impiegatos.Add(t);
                _context.SaveChanges();
                return true;
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool Update(Impiegato t)
        {
            try
            {
                _context.Update(t);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
