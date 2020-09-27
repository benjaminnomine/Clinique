using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Clinique.Domain.Enums
{
    public static class Couleur
    {
        public static void PopulateDictionnary(Dictionary<string, string> keyValuePairs)
        {
            keyValuePairs.Add("Rouge", "#ff7851");
            keyValuePairs.Add("Bleu", "#007bff");
            keyValuePairs.Add("Vert", "#56cc9d");
            keyValuePairs.Add("Jaune", "#ffce67");
            keyValuePairs.Add("Rose", "#e83e8c");
            keyValuePairs.Add("Orange", "#fd7e14");
            keyValuePairs.Add("Violet", "#6f42c1");
            keyValuePairs.Add("Indigo", "#6610f2");
            keyValuePairs.Add("Turquoise", "#20c997");
            keyValuePairs.Add("Cyan", "#6cc3d5");
        }

        public static SelectList CreerSelectList()
        {
            Dictionary<string, string> couleurs = new Dictionary<string, string>();
            Couleur.PopulateDictionnary(couleurs);
            return new SelectList(couleurs, "Value", "Key", "Value");
        }

    }
}
