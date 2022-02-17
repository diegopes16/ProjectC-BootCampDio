using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSeries.Interfaces;
using ProjectSeries.Classes;

namespace ProjectSeries

{
    public class MidiaRepositorio : IRepositorio<Midia>
    {
        private List<Midia> listaMidia = new List<Midia>();

        public void Atualiza(int id, Midia midia)
        {
            listaMidia[id] = midia;
        }

        public void Exclui(int id)
        {
            listaMidia[id].Excluir();
        }

        public void Insere(Midia midia)
        {
            listaMidia.Add(midia);
        }

        public List<Midia> Lista()
        {
            return listaMidia;
        }

        public int ProximoId()
        {
            return listaMidia.Count;
        }

        public Midia RetornaPorId(int id)
        {
            return listaMidia[id];
        }
    }
}
