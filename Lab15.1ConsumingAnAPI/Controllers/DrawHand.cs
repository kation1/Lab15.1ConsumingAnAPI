using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lab15._1ConsumingAnAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab15._1ConsumingAnAPI.Controllers
{
    public class DrawHand : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");

            var response = await client.GetAsync("/api/deck/new/shuffle/?deck_count=1");
            Deck info = await response.Content.ReadAsAsync<Deck>();



            return View(info);
        }


        public async Task<IActionResult> ShowHand(string deck_id)
        {
           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            int cardCount = 5;

            var response = await client.GetAsync($"/api/deck/{deck_id}/draw/?count=5");
            Hand handCards = await response.Content.ReadAsAsync<Hand>();

            return View(handCards);
    
        }
        }
    }
