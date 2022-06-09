using ShopBridge.DALFile;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge.Controllers
{
    [RoutePrefix("api/ManageInventoryApi")]
    public class ManageInventoryApiController : ApiController
    {
        [HttpPost]
        [Route("GetProductList")]
        public IHttpActionResult GetProductList()
        {
            try
            {
                List<ProductMdl> result = ManageInventoryDal.GetProductList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("AddNewProduct")]
        public IHttpActionResult AddNewProduct(ProductMdl formData)
        {
            try
            {
                int result = ManageInventoryDal.AddNewProduct(formData);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("DeleteProduct/{productCode}")]
        public IHttpActionResult DeleteProduct(int productCode)
        {
            try
            {
                int result = ManageInventoryDal.DeleteProduct(productCode);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
