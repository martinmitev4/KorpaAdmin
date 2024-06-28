
using KorpaAdmin.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace KorpaAdmin.Controllers
{
    public class RestaurantsController : Controller
    {

        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5153/api/Admin/GetAllRestaurants";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Restaurants>>().Result;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Image,Location,Id")] Restaurants restaurants)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                //added in next aud
                string URL = "http://localhost:5153/api/Admin/CreateRestaurants";
                var model = restaurants;

                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(URL, content).Result;

                //var result = response.Content.ReadAsAsync<Order>().Result;


                return RedirectToAction(nameof(Index));
            }
            return View(restaurants);
        }


        public IActionResult Edit(string id)
        {
            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/GetDetails";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Restaurants>().Result;


            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Image,Location,Id")] Restaurants restaurants)
        {
            if (id != restaurants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                //added in next aud
                string URL = "http://localhost:5153/api/Admin/EditRestaurant";
                var model = restaurants;

                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(URL, content).Result;

                return RedirectToAction(nameof(Index));
            }
            return View(restaurants);
        }


        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/GetDetails";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Restaurants>().Result;

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/GetDetails";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var restaurant = response.Content.ReadAsAsync<Restaurants>().Result;



            HttpClient client2 = new HttpClient();
            //added in next aud
            string URL2 = "http://localhost:5153/api/Admin/Delete";
            var model2 = restaurant;

            HttpContent content2 = new StringContent(JsonConvert.SerializeObject(model2), Encoding.UTF8, "application/json");

            HttpResponseMessage response2 = client.PostAsync(URL2, content2).Result;

            var result = response2.Content.ReadAsAsync<Restaurants>().Result;

            return RedirectToAction(nameof(Index));
        }



        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/GetDetails";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var restaurant = response.Content.ReadAsAsync<Restaurants>().Result;
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }


        public IActionResult Menu(Guid? id)
        {
            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/GetMenu";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var food_Items = response.Content.ReadAsAsync<List<Food_items>>().Result;
            ViewData["RestaurantId"] = id;
            return View(food_Items);
        }

        public IActionResult CreateFood(string id)
        {
            ViewData["RestaurantId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFood([Bind("Name,Image,Ingredients,Price,RestaurantId")] Food_items food_items)
        {
            if (ModelState.IsValid)
            {
                HttpClient client2 = new HttpClient();
                string URL2 = "http://localhost:5153/api/Admin/CreateFoodItem";
                var model2 = food_items;

                HttpContent content2 = new StringContent(JsonConvert.SerializeObject(model2), Encoding.UTF8, "application/json");

                HttpResponseMessage response2 = client2.PostAsync(URL2, content2).Result;


                return RedirectToAction(nameof(Index));
            }
            return View(food_items);
        }





        public IActionResult EditFood(string id)
        {
            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/GetDetailsFood";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Food_items>().Result;


            return View(result);
        }       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFood(Guid id, [Bind("Name,Image,Ingredients,Price,Id")] Food_items food_items)
        {
            if (id != food_items.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                //added in next aud
                string URL = "http://localhost:5153/api/Admin/EditFood";
                var model = food_items;

                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(URL, content).Result;

                return RedirectToAction(nameof(Index));
            }
            return View(food_items);
        }

        public IActionResult DeleteFood(string id)
        {
            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/GetDetailsFood";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Food_items>().Result;


            return View(result);
        }
        public IActionResult DetailsFood(string id)
        {
            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/GetDetailsFood";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Food_items>().Result;


            return View(result);
        }


        [HttpPost, ActionName("DeleteFoodConf")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFoodConf(Guid id)
        {
            HttpClient client = new HttpClient();
            //added in next aud
            string URL = "http://localhost:5153/api/Admin/DeleteFood";
            var model = new
            {
                Id = id
            };

            HttpContent content2 = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response2 = client.PostAsync(URL, content2).Result;

            var result = response2.Content.ReadAsAsync<Restaurants>().Result;

            return RedirectToAction(nameof(Index));
        }

    }
}
