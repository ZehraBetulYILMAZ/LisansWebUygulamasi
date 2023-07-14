using Microsoft.AspNetCore.Mvc;
using TWYLisans.Application.Repositories;
using TWYLisans.Application.ViewModels.Customers;
using TWYLisans.Application.ViewModels.Products;
using TWYLisans.Domain.Entities;
using TWYLisans.Infrastructure;

namespace TWYLisans.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductReadRepository _readProductRepository;
        private readonly IProductWriteRepository _writeProductRepository;
        private readonly IReadCustomerRepository _readCustomerRepository;
        private readonly IWriteCustomerRepository _writeCustomerRepository;
        private readonly ILicenceReadRepository _readLicenceRepository;
        private readonly ILicenceWriteRepository _writeLicenceRepository;
        bool isOk = false;
        public ProductController(IProductReadRepository productReadRepository , IProductWriteRepository productWriteRepository,IReadCustomerRepository readCustomerRepository , IWriteCustomerRepository writeCustomerRepository,
         ILicenceReadRepository licenceReadRepository, ILicenceWriteRepository licenceWriteRepository)
        {
            _readProductRepository = productReadRepository;
            _writeProductRepository = productWriteRepository;
            _readCustomerRepository = readCustomerRepository;
            _writeCustomerRepository = writeCustomerRepository;
            _readLicenceRepository = licenceReadRepository;
            _writeLicenceRepository = licenceWriteRepository;
        }
        public IActionResult Index()
        { 
            //Random random = new Random();
            //int index = (int)random.Next(1, 19);
            //Customer customer1 = await _readCustomerRepository.GetByIdAsync(index);
            //Product product = new Product
            //{
            //    createdDate = DateTime.Now,
            //    name = FakeData.NameData.GetCompanyName() + " Ürünü",
            //    description = FakeData.TextData.GetSentences(5),
            //    customer = customer1,

            //};
            //await _writeProductRepository.AddAsync(product);
            //await _writeProductRepository.SaveAsync();
            return View();
        }
        public IActionResult CreateProduct(int id)
        {
            VM_ProductsLicence model = new();
         
                model.customerId = id;
            
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(VM_ProductsLicence model)
        {
                 Customer customer = await _readCustomerRepository.GetByIdAsync(model.customerId);
            Product mproduct = TypeConversion.Conversion<VM_Create_Product, Product>(model.products);
            //Licence licence = TypeConversion.Conversion<VM_Create_Licence,Licence>(model.licences);
           
            var b = Guid.Parse(model.licences.licenceKey);
            Licence mlicence = new Licence
            {
                createdDate = DateTime.Now,
                expiryDate = model.licences.expiryDate,
                licenceKey = b,
                product = mproduct
            };
          //  mproduct.licences.Add(mlicence);
            
            mproduct.customer = customer;
        
            isOk =  await  _writeProductRepository.AddAsync(mproduct);
       
            await _writeProductRepository
                .SaveAsync();
            await _writeLicenceRepository.AddAsync(mlicence);
            await _writeLicenceRepository.SaveAsync();
            return View();
        }
        public async Task<IActionResult> ListProduct()
        {

            var products = _readProductRepository.GetAll().ToList();
            List<VM_List_Product> models = new();
            if(products != null && products.Count > 0)
            {
               foreach(var product in products)
                {
                    VM_List_Product model = new VM_List_Product();
                    Customer customer = await _readCustomerRepository.GetByIdAsync(product.customerID);
                    VM_List_Customer mCustomer = new VM_List_Customer();
                    model.ID =  product.ID;
                    model.name= product.name;
                    model.description= product.description;
                   
                    if(customer != null)
                    {
                       mCustomer.ID = customer.ID;
                        mCustomer.lastName = customer.lastName;
                        mCustomer.firstName = customer.firstName;
                        model.customer = mCustomer;
                    }
                    Licence licence = await _readLicenceRepository.GetSingleAsync(l => l.productID == product.ID);
                    VM_List_Licence mLicence = new();
                    if(licence != null)
                    {
                        mLicence.ID= licence.ID;
                        mLicence.licenceKey = licence.licenceKey;
                        model.licence = mLicence;
                    }
                    models.Add(model);
                }

            }
            return View(models);
        }
        public async Task<IActionResult> ProductDetails(int id)
        {
            Product product  = await _readProductRepository.GetByIdAsync(id);
            VM_List_Product model = new();
            VM_List_Customer mCustomer = new();
            VM_List_Licence mLicence = new();
            if(product != null)
            {
                Customer customer = await _readCustomerRepository.GetByIdAsync(product.customerID);
                Licence licence =await _readLicenceRepository.GetSingleAsync(l => l.productID == product.ID);
                if(licence != null)
                {
                    mLicence.licenceKey = licence.licenceKey;
                    mLicence.ID = licence.ID;
                    mLicence.expiryDate = licence.expiryDate;
                    mLicence.createdDate = licence.createdDate;

                }
                mCustomer.ID = customer.ID;
                mCustomer.lastName = customer.lastName;
                mCustomer.firstName = customer.firstName;
                model.ID = product.ID;
                model.name = product.name;
                model.description = product.description;
                model.createdDate = product.createdDate;
                model.licence = mLicence;
                model.customer = mCustomer;
                
            }  
            return View(model);
        }
        public IActionResult ProductUpdate()
        {
            return RedirectToAction("ProductDetails");
        }
        public IActionResult ProductDelete()
        {
            return RedirectToAction("ProductDetails");
        }
        public IActionResult LicenceDetails()
        {
            return View();
        }
        public IActionResult CreateLicence()
        {
            return View();
        }
    }
}
