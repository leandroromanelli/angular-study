using ChatService.Contexts;
using ChatService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ChatService.Controllers
{

    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class DummyDataController : Controller
    {
        private readonly TestContext _context;
        public DummyDataController(TestContext context)
        {
            _context = context;

            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath1",
                EmailId = "Bharath1@gmail.com",
                PhoneNumber = "8792339764",
                UpdatedDateTime = DateTime.Parse("2021-5-14 1:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath2",
                EmailId = "Bharath2@gmail.com",
                PhoneNumber = "918797339762",
                UpdatedDateTime = DateTime.Parse("2021-5-14 1:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath3",
                EmailId = "Bharath3@gmail.com",
                PhoneNumber = "2323142134",
                UpdatedDateTime = DateTime.Parse("2021-5-14 2:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath4",
                EmailId = "Bharath4@gmail.com",
                PhoneNumber = "2142134",
                UpdatedDateTime = DateTime.Parse("2021-5-14 2:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath5",
                EmailId = "Bharath5@gmail.com",
                PhoneNumber = "2314231",
                UpdatedDateTime = DateTime.Parse("2021-5-14 3:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath6",
                EmailId = "Bharath6@gmail.com",
                PhoneNumber = "1234312421342310",
                UpdatedDateTime = DateTime.Parse("2021-5-14 3:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath7",
                EmailId = "Bharath7@gmail.com",
                PhoneNumber = "21412421342134200000",
                UpdatedDateTime = DateTime.Parse("2021-5-14 4:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath8",
                EmailId = "Bharath8@gmail.com",
                PhoneNumber = "23142134213421300000",
                UpdatedDateTime = DateTime.Parse("2021-5-14 4:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath9",
                EmailId = "Bharath9@gmail.com",
                PhoneNumber = "23421342134213400",
                UpdatedDateTime = DateTime.Parse("2021-5-14 5:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath10",
                EmailId = "Bharath10@gmail.com",
                PhoneNumber = "432",
                UpdatedDateTime = DateTime.Parse("2021-5-14 5:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath11",
                EmailId = "Bharath11@gmail.com",
                PhoneNumber = "2314",
                UpdatedDateTime = DateTime.Parse("2021-5-14 6:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath12",
                EmailId = "Bharath12@gmail.com",
                PhoneNumber = "1234",
                UpdatedDateTime = DateTime.Parse("2021-5-14 6:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath13",
                EmailId = "Bharath13@gmail.com",
                PhoneNumber = "2314",
                UpdatedDateTime = DateTime.Parse("2021-5-14 7:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath14",
                EmailId = "Bharath14@gmail.com",
                PhoneNumber = "123",
                UpdatedDateTime = DateTime.Parse("2021-5-14 7:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath15",
                EmailId = "Bharath15@gmail.com",
                PhoneNumber = "421",
                UpdatedDateTime = DateTime.Parse("2021-5-14 8:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath16",
                EmailId = "Bharath16@gmail.com",
                PhoneNumber = "34",
                UpdatedDateTime = DateTime.Parse("2021-5-14 8:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath17",
                EmailId = "Bharath17@gmail.com",
                PhoneNumber = "2134",
                UpdatedDateTime = DateTime.Parse("2021-5-14 9:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath18",
                EmailId = "Bharath18@gmail.com",
                PhoneNumber = "2134",
                UpdatedDateTime = DateTime.Parse("2021-5-14 9:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath19",
                EmailId = "Bharath19@gmail.com",
                PhoneNumber = "213",
                UpdatedDateTime = DateTime.Parse("2021-5-14 10:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath20",
                EmailId = "Bharath20@gmail.com",
                PhoneNumber = "4231",
                UpdatedDateTime = DateTime.Parse("2021-5-14 10:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath21",
                EmailId = "Bharath21@gmail.com",
                PhoneNumber = "4",
                UpdatedDateTime = DateTime.Parse("2021-5-14 11:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath22",
                EmailId = "Bharath22@gmail.com",
                PhoneNumber = "1234",
                UpdatedDateTime = DateTime.Parse("2021-5-14 11:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath23",
                EmailId = "Bharath23@gmail.com",
                PhoneNumber = "12",
                UpdatedDateTime = DateTime.Parse("2021-5-14 12:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath24",
                EmailId = "Bharath24@gmail.com",
                PhoneNumber = "421",
                UpdatedDateTime = DateTime.Parse("2021-5-14 12:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath25",
                EmailId = "Bharath25@gmail.com",
                PhoneNumber = "34",
                UpdatedDateTime = DateTime.Parse("2021-5-14 13:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath26",
                EmailId = "Bharath26@gmail.com",
                PhoneNumber = "2134",
                UpdatedDateTime = DateTime.Parse("2021-5-14 13:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath27",
                EmailId = "Bharath27@gmail.com",
                PhoneNumber = "213",
                UpdatedDateTime = DateTime.Parse("2021-5-14 14:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath28",
                EmailId = "Bharath28@gmail.com",
                PhoneNumber = "42",
                UpdatedDateTime = DateTime.Parse("2021-5-14 21:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath29",
                EmailId = "Bharath29@gmail.com",
                PhoneNumber = "134",
                UpdatedDateTime = DateTime.Parse("2021-5-14 22:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath30",
                EmailId = "Bharath30@gmail.com",
                PhoneNumber = "23",
                UpdatedDateTime = DateTime.Parse("2021-5-14 22:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath31",
                EmailId = "Bharath31@gmail.com",
                PhoneNumber = "4213",
                UpdatedDateTime = DateTime.Parse("2021-5-14 23:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath32",
                EmailId = "Bharath32@gmail.com",
                PhoneNumber = "421",
                UpdatedDateTime = DateTime.Parse("2021-5-14 23:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath33",
                EmailId = "Bharath33@gmail.com",
                PhoneNumber = "34",
                UpdatedDateTime = DateTime.Parse("2021-5-15 0:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath34",
                EmailId = "Bharath93@gmail.com",
                PhoneNumber = "2134",
                UpdatedDateTime = DateTime.Parse("2021-5-15 0:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath35",
                EmailId = "Bharath94@gmail.com",
                PhoneNumber = "231",
                UpdatedDateTime = DateTime.Parse("2021-5-15 1:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath36",
                EmailId = "Bharath95@gmail.com",
                PhoneNumber = "4213",
                UpdatedDateTime = DateTime.Parse("2021-5-15 1:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath37",
                EmailId = "Bharath96@gmail.com",
                PhoneNumber = "231",
                UpdatedDateTime = DateTime.Parse("2021-5-15 2:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath38",
                EmailId = "Bharath97@gmail.com",
                PhoneNumber = "4231",
                UpdatedDateTime = DateTime.Parse("2021-5-15 2:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath39",
                EmailId = "Bharath3@gmail.com",
                PhoneNumber = "42",
                UpdatedDateTime = DateTime.Parse("2021-5-14 20:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath40",
                EmailId = "Bharath4@gmail.com",
                PhoneNumber = "14",
                UpdatedDateTime = DateTime.Parse("2021-5-14 20:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath41",
                EmailId = "Bharath5@gmail.com",
                PhoneNumber = "12",
                UpdatedDateTime = DateTime.Parse("2021-5-14 21:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath42",
                EmailId = "Bharath6@gmail.com",
                PhoneNumber = "421",
                UpdatedDateTime = DateTime.Parse("2021-5-14 21:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath43",
                EmailId = "Bharath7@gmail.com",
                PhoneNumber = "4",
                UpdatedDateTime = DateTime.Parse("2021-5-14 22:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath44",
                EmailId = "Bharath8@gmail.com",
                PhoneNumber = "2134",
                UpdatedDateTime = DateTime.Parse("2021-5-14 22:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath45",
                EmailId = "Bharath9@gmail.com",
                PhoneNumber = "231",
                UpdatedDateTime = DateTime.Parse("2021-5-14 23:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath46",
                EmailId = "Bharath10@gmail.com",
                PhoneNumber = "4",
                UpdatedDateTime = DateTime.Parse("2021-5-14 23:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath47",
                EmailId = "Bharath11@gmail.com",
                PhoneNumber = "214",
                UpdatedDateTime = DateTime.Parse("2021-5-15 0:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath48",
                EmailId = "Bharath12@gmail.com",
                PhoneNumber = "12",
                UpdatedDateTime = DateTime.Parse("2021-5-15 0:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath49",
                EmailId = "Bharath13@gmail.com",
                PhoneNumber = "4213",
                UpdatedDateTime = DateTime.Parse("2021-5-15 1:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath50",
                EmailId = "Bharath14@gmail.com",
                PhoneNumber = "213",
                UpdatedDateTime = DateTime.Parse("2021-5-15 1:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath51",
                EmailId = "Bharath15@gmail.com",
                PhoneNumber = "423",
                UpdatedDateTime = DateTime.Parse("2021-5-15 2:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath52",
                EmailId = "Bharath52@gmail.com",
                PhoneNumber = "1421",
                UpdatedDateTime = DateTime.Parse("2021-5-15 2:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath53",
                EmailId = "Bharath53@gmail.com",
                PhoneNumber = "34",
                UpdatedDateTime = DateTime.Parse("2021-5-15 3:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath54",
                EmailId = "Bharath54@gmail.com",
                PhoneNumber = "2143",
                UpdatedDateTime = DateTime.Parse("2021-5-15 3:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath55",
                EmailId = "Bharath55@gmail.com",
                PhoneNumber = "23",
                UpdatedDateTime = DateTime.Parse("2021-5-15 4:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath56",
                EmailId = "Bharath30@gmail.com",
                PhoneNumber = "1423",
                UpdatedDateTime = DateTime.Parse("2021-5-15 4:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath57",
                EmailId = "Bharath31@gmail.com",
                PhoneNumber = "14",
                UpdatedDateTime = DateTime.Parse("2021-5-15 5:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath58",
                EmailId = "Bharath32@gmail.com",
                PhoneNumber = "124",
                UpdatedDateTime = DateTime.Parse("2021-5-15 5:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath59",
                EmailId = "Bharath33@gmail.com",
                PhoneNumber = "123",
                UpdatedDateTime = DateTime.Parse("2021-5-15 6:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath60",
                EmailId = "Bharath34@gmail.com",
                PhoneNumber = "42",
                UpdatedDateTime = DateTime.Parse("2021-5-15 6:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath61",
                EmailId = "Bharath35@gmail.com",
                PhoneNumber = "134",
                UpdatedDateTime = DateTime.Parse("2021-5-15 7:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath62",
                EmailId = "Bharath36@gmail.com",
                PhoneNumber = "2134",
                UpdatedDateTime = DateTime.Parse("2021-5-15 7:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath63",
                EmailId = "Bharath63@gmail.com",
                PhoneNumber = "213",
                UpdatedDateTime = DateTime.Parse("2021-5-15 8:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath64",
                EmailId = "Bharath64@gmail.com",
                PhoneNumber = "44325342",
                UpdatedDateTime = DateTime.Parse("2021-5-15 4:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath65",
                EmailId = "Bharath65@gmail.com",
                PhoneNumber = "534",
                UpdatedDateTime = DateTime.Parse("2021-5-15 5:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath66",
                EmailId = "Bharath66@gmail.com",
                PhoneNumber = "54",
                UpdatedDateTime = DateTime.Parse("2021-5-15 14:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath67",
                EmailId = "Bharath67@gmail.com",
                PhoneNumber = "56",
                UpdatedDateTime = DateTime.Parse("2021-5-15 15:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath68",
                EmailId = "Bharath68@gmail.com",
                PhoneNumber = "3464",
                UpdatedDateTime = DateTime.Parse("2021-5-15 15:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath69",
                EmailId = "Bharath69@gmail.com",
                PhoneNumber = "356",
                UpdatedDateTime = DateTime.Parse("2021-5-15 16:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath70",
                EmailId = "Bharath70@gmail.com",
                PhoneNumber = "232",
                UpdatedDateTime = DateTime.Parse("2021-5-15 16:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath71",
                EmailId = "Bharath64@gmail.com",
                PhoneNumber = "345",
                UpdatedDateTime = DateTime.Parse("2021-5-15 12:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath72",
                EmailId = "Bharath82@gmail.com",
                PhoneNumber = "3425",
                UpdatedDateTime = DateTime.Parse("2021-5-15 12:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath73",
                EmailId = "Bharath83@gmail.com",
                PhoneNumber = "324",
                UpdatedDateTime = DateTime.Parse("2021-5-15 13:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath74",
                EmailId = "Bharath84@gmail.com",
                PhoneNumber = "5342",
                UpdatedDateTime = DateTime.Parse("2021-5-15 13:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath75",
                EmailId = "Bharath85@gmail.com",
                PhoneNumber = "532",
                UpdatedDateTime = DateTime.Parse("2021-5-15 14:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath76",
                EmailId = "Bharath86@gmail.com",
                PhoneNumber = "45324",
                UpdatedDateTime = DateTime.Parse("2021-5-15 14:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath77",
                EmailId = "Bharath87@gmail.com",
                PhoneNumber = "532",
                UpdatedDateTime = DateTime.Parse("2021-5-15 15:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath78",
                EmailId = "Bharath88@gmail.com",
                PhoneNumber = "4532",
                UpdatedDateTime = DateTime.Parse("2021-5-15 15:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath79",
                EmailId = "Bharath89@gmail.com",
                PhoneNumber = "5",
                UpdatedDateTime = DateTime.Parse("2021-5-15 16:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath80",
                EmailId = "Bharath90@gmail.com",
                PhoneNumber = "325",
                UpdatedDateTime = DateTime.Parse("2021-5-15 16:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath81",
                EmailId = "Bharath91@gmail.com",
                PhoneNumber = "23452345342",
                UpdatedDateTime = DateTime.Parse("2021-5-15 17:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath82",
                EmailId = "Bharath92@gmail.com",
                PhoneNumber = "5",
                UpdatedDateTime = DateTime.Parse("2021-5-15 17:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath83",
                EmailId = "Bharath83@gmail.com",
                PhoneNumber = "23",
                UpdatedDateTime = DateTime.Parse("2021-5-15 18:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath84",
                EmailId = "Bharath84@gmail.com",
                PhoneNumber = "532",
                UpdatedDateTime = DateTime.Parse("2021-5-15 18:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath85",
                EmailId = "Bharath85@gmail.com",
                PhoneNumber = "234",
                UpdatedDateTime = DateTime.Parse("2021-5-15 19:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath86",
                EmailId = "Bharath86@gmail.com",
                PhoneNumber = "324",
                UpdatedDateTime = DateTime.Parse("2021-5-15 19:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath87",
                EmailId = "Bharath87@gmail.com",
                PhoneNumber = "5",
                UpdatedDateTime = DateTime.Parse("2021-5-15 20:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath88",
                EmailId = "Bharath88@gmail.com",
                PhoneNumber = "2345",
                UpdatedDateTime = DateTime.Parse("2021-5-15 20:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath89",
                EmailId = "Bharath89@gmail.com",
                PhoneNumber = "324",
                UpdatedDateTime = DateTime.Parse("2021-5-15 21:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath90",
                EmailId = "Bharath90@gmail.com",
                PhoneNumber = "5",
                UpdatedDateTime = DateTime.Parse("2021-5-15 21:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath91",
                EmailId = "Bharath91@gmail.com",
                PhoneNumber = "325",
                UpdatedDateTime = DateTime.Parse("2021-5-15 22:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath92",
                EmailId = "Bharath92@gmail.com",
                PhoneNumber = "342",
                UpdatedDateTime = DateTime.Parse("2021-5-15 22:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath93",
                EmailId = "Bharath93@gmail.com",
                PhoneNumber = "5",
                UpdatedDateTime = DateTime.Parse("2021-5-15 14:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath94",
                EmailId = "Bharath94@gmail.com",
                PhoneNumber = "332",
                UpdatedDateTime = DateTime.Parse("2021-5-15 15:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath95",
                EmailId = "Bharath95@gmail.com",
                PhoneNumber = "5",
                UpdatedDateTime = DateTime.Parse("2021-5-15 15:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath96",
                EmailId = "Bharath96@gmail.com",
                PhoneNumber = "324",
                UpdatedDateTime = DateTime.Parse("2021-5-15 16:0:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath97",
                EmailId = "Bharath97@gmail.com",
                PhoneNumber = "12412341234",
                UpdatedDateTime = DateTime.Parse("2021-5-15 16:30:0")
            });
            _context.DummyData.Add(new DummyData()
            {
                Name = "Bharath98",
                EmailId = "Bharath98@gmail.com",
                PhoneNumber = "1324",
                UpdatedDateTime = DateTime.Parse("2021-5-16 1:30:0")
            });
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<List<DummyData>>> List(CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(await _context.DummyData.ToListAsync(cancellationToken)), "application/json");
        }
    }
}
