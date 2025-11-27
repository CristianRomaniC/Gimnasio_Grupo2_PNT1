using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GimnasioGrupo2.Data;

namespace GimnasioGrupo2.Models
{
 public class ObjetosPerdidosViewModel
 {
 public ObjetoPerdido Objeto { get; set; } = new ObjetoPerdido { FechaEncontrado = System.DateTime.Today };
 public List<SelectListItem> ClientesLista { get; set; } = new List<SelectListItem>();
 public string? StatusMessage { get; set; }

 public async Task LoadClientesAsync(GimnasioContext context)
 {
 var clientes = await context.Clientes.AsNoTracking().OrderBy(c => c.Nombre).ThenBy(c => c.Apellido).ToListAsync();
 ClientesLista = clientes.Select(c => new SelectListItem { Value = c.Dni.ToString(), Text = $"{c.Nombre} {c.Apellido} ({c.Dni})" }).ToList();
 ClientesLista.Insert(0, new SelectListItem { Value = "", Text = "-- Sin asignar --" });
 }
 }
}