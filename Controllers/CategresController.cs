using app1.Data;
using app1.Dto;
using app1.Modle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategresController : ControllerBase
    {
        
       ApplicationDbContext context=new ApplicationDbContext();
        [HttpGet]
        public IActionResult getall() { 


        var item=context.Categres.ToList();
            var categredt = new List <getcategredto> ();
            foreach (var categredto in item)
            {
                categredt.Add(new getcategredto
                {
                    Id = categredto.Id,
                    Name = categredto.Name,
                });
            }

            if (item.Count == 0 )
            {
                return NotFound();
            }
            return Ok(item);
        
        }
        [HttpPost]
        public IActionResult Create(Createcategerdto categredto) {
            Categre categre = new Categre() {
           Name = categredto.Name,

            };

         context.Categres.Add(categre);
            context.SaveChanges();
            return Create();
                
        }
        [HttpPatch]
        public IActionResult UPdate(int id, Createcategerdto categredto) { 
            var item=context.Categres.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            item.Name = categredto.Name;
           
            context.SaveChanges();
            return Ok(item);

        }
        [HttpDelete]
        public IActionResult deleC(int id)
        {
            var item = context.Categres.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Categres.Remove(item);
            return Ok();


        }

    }
}