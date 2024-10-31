using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using YLPDotNetCore.PizzaApi.Db;
using YLPDotNetCore.PizzaApi.Queries;
using YLPDotNetCore.Shared;


namespace YLPDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly DapperService _dapperService;
        public PizzaController()
        {
            _context = new AppDbContext();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _context.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extra")]
        public async Task<IActionResult> GetExtrasAsync()
        {
            var lst = await _context.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        //[HttpGet("Order/{invoiceNo}")]
        //public async Task<IActionResult> GetOrder(string invoiceNo)
        //{
        //    var item = await _context.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
        //    var lst = await _context.PizzaOrdersDetail.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
        //    return Ok(new
        //    {
        //        Order = item,
        //        OderDetail = lst
        //    });
        //}

        //With Dapper
        [HttpGet("Order/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
                (
                    PizzaQuery.PizzaOrderQuery, 
                    new {PizzaOrderInvoiceNo = invoiceNo}
                );
            var lst = _dapperService.Query<PizzaOrderInvoiceHeadDetailModel>
            (
                PizzaQuery.PizzaOrderDetailQuery,
                new {PizzaOrderInvoiceNo = invoiceNo}
            );
            var model = new PizzaOrderInvoiceResponse
            {
                Order = item,
                OrderDetail = lst
            };

            return Ok(model);
        }

        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var item = await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = item.Price;

            if(orderRequest.Extras.Length > 0)
            {
                var lstExtra = await _context.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total,
            };

            List<PizzaOrderDetailModel> pizzaExtraModels = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel
            {
                PizzaExtraId = extraId,
                PizzaOrderInvoiceNo = invoiceNo,
            }).ToList();

            OrderResponse response = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                Message = "Thanks for your order.",
                TotalAmount = total,
            };

            await _context.PizzaOrders.AddAsync(pizzaOrderModel);
            await _context.PizzaOrdersDetail.AddRangeAsync(pizzaExtraModels);
            await _context.SaveChangesAsync();

            return Ok(response);
        }
    }
}
