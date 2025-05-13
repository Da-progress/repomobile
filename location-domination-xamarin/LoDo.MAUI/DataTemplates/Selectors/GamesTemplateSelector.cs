using LoDo.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.DataTemplates.Selectors
{
    public class GamesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PlayedGame { get; set; }  = null!;
        public DataTemplate OpenGame { get; set; } = null!;
        public DataTemplate PlannedGame { get; set; } = null!;
        public DataTemplate ConfirmedGame { get; set; } = null!;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var game = item as Game;
            switch (game.GameState) 
            {
                case "OPEN": 
                    return OpenGame; 
                case "PLANNED":
                    return PlannedGame;
                case "PLAYED":
                    return PlayedGame;
                case "CONFIRMED":
                    return ConfirmedGame;
                default:
                    throw new Exception("No such state!");
            }
        }
    }
}
