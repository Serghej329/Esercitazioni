using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class Prodotto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome è obbligatorio.")]
    public string Nome { get; set; } = string.Empty; // Non nullable

    public string? Immagine { get; set; }
    [BindProperty]
    [Required(ErrorMessage = "Il dettaglio è obbligatorio.")]
    public string Dettaglio { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di zero.")]
    public decimal Prezzo { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "La quantità è obbligatoria.")]
    [Range(0, int.MaxValue, ErrorMessage = "La quantità deve essere zero o superiore.")]
    public int Quantita { get; set; }

    [BindProperty]
    // Proprietà per la categoria principale
    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public string Categoria { get; set; } = string.Empty; // Non nullable

    // Lista di categorie collegate
    public List<string> Categorie { get; set; } = new List<string>(); // Inizializzata per evitare null

    // Lista di categorie esistenti
    public List<string> CategorieEsistenti { get; set; } = new List<string>(); // Inizializzata per evitare null
}