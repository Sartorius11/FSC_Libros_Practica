using FSC_Libros_Practica.Models;
using FSC_Libros_Practica.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FSC_Libros_Practica.Controllers
{
    public class LibrosController : Controller
    {
        private RepositoryLibros repo;
        public LibrosController(RepositoryLibros repo)
        {
            this.repo = repo;
        }


        //OBITIENE LA VISTA GENERAL DE PAGINA
        public  async Task <IActionResult> Index()
        {
            List<Libro> libros = await this.repo.GetListaLibrosAsync();
            return View(libros);
        }
        //OBITIENE LOS DETALLES  DE CADA LIBRO
        public async Task<IActionResult>Detalles(int idlibro)
        {
              Libro libros = await this.repo.FindLibroAsync(idlibro);

            return View(libros);
        }

        public async Task<IActionResult> Details(int IdGenero)
        {
            Genero generos = await this.repo.GetGenerosAsync(IdGenero);
            return View(generos);
        }




        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string email, string password)
        {
            Usuario usuario = this.repo.LogInUser(email, password);
            if (usuario == null)
            {
                ViewData["MENSAJE"] = "Credenciales incorrectas";
                return View();
            }
            else
            {
                return View(usuario);
            }
        }




    }
}
