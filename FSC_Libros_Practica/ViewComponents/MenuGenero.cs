using FSC_Libros_Practica.Models;
using FSC_Libros_Practica.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FSC_Libros_Practica.ViewComponents
{
    public class MenuGenero : ViewComponent
    {
        private RepositoryLibros repo;

        public MenuGenero(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = await repo.GetListaGenerosAsync();
            return View(generos);
        }
    }

}

