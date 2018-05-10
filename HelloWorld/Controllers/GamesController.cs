using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class GamesController:Controller
    {
        Deck model = new Deck();

        public ActionResult Solitaire()
        {
            model = new Deck();
            return View(model);
        }

        [HttpGet]
        public ActionResult GetCard()
        {
            CardModel newCard = model.getCard();
            return Json(new { value = newCard.value, suit = newCard.suit});
        }
    }
}