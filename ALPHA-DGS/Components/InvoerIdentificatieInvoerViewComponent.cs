using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ALPHA_DGS.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ALPHA_DGS.Components
{

    public class InvoerIdentificatieInvoerViewComponent : ViewComponent
    {

        private readonly AlphaDbContext _context;

        public InvoerIdentificatieInvoerViewComponent(AlphaDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)

        {
            var vakitem = await _context.VakItem
                .Include(vs => vs.Invoer)
                .Where(V => V.Id == id)
                .ToListAsync();

            return View(vakitem);





        }



    }

}
