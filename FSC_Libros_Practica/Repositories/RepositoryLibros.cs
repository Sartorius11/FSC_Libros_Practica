using FSC_Libros_Practica.Data;
using FSC_Libros_Practica.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace FSC_Libros_Practica.Repositories
{
    public class RepositoryLibros
    {
        private LibrosContext context;
        public RepositoryLibros(LibrosContext context)
        {
            this.context = context;
        }

        //QUIERO QUE ME DEVUELVA UNA LISTA CON LOS LIBROS
        public async Task<List<Libro>> GetListaLibrosAsync()
        {
            return await this.context.Libros.ToListAsync();
        }

        //QUIERO QUE PUEDA ENCONTRAR UN LIBRO EN ESPECIFICO CON LA ID
        public async Task<Libro> FindLibroAsync(int idlibro)
        {
            return await this.context.Libros.Where(x => x.Id_libro == idlibro).FirstOrDefaultAsync();
        }


        //QUIERO RECUPERAR UNA LISTA CON TODOS LOS GENEROS PARA DESPUES MOSTRARLA 
        //EN LA VISTA EN FORMA DE DROPDOWNLIST
        public async Task<List<Genero>> GetListaGenerosAsync()
        {
            return await this.context.Generos.ToListAsync();
        }

        public async Task<Genero> GetGenerosAsync(int idGenero)
        {
            return await this.context.Generos.Where(x => x.IdGenero == idGenero).FirstOrDefaultAsync();
        }



        //LOGIN 
        public Usuario LogInUser
       (string email, string password )
        {
            Usuario usuario =
                this.context.Usuarios.FirstOrDefault(z => z.Email == email);
            if (usuario == null)
            {
                return null;
            }
            else
            {
                password = usuario.Pass;

                if (password ==usuario.Pass)
                {
                    //SON IGUALES
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}