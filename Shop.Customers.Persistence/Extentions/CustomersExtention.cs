using Shop.CUser.Persistence.Context;
using Shop.CUser.Persistence.Exception;
using Shop.Customers.Application.Dtos.CustomersDtos;



namespace Shop.CUser.Persistence.Extentions
{
    public static class CustomersExtentions
    {




        public static void UpdateFromCustomers(this Modules.Domain.Entities.Customers customers, CustomersUpdateDto model)
        {
            customers.companyname = model.companyname;
            customers.contactname = model.contactname;
            customers.contacttitle = model.contacttitle;
            customers.address = model.address;
            customers.email = model.email;
            customers.city = model.city;
            customers.region = model.region;
            customers.postalcode = model.postalcode;
            customers.country = model.country;
            customers.phone = model.phone;
            customers.fax = model.fax;
        }
  
        

        public static Modules.Domain.Entities.Customers ValidateCustomerExists(this ShopContext context, int custid)
        {
            var customer = context.Customers.Find(custid);
            if (customer == null)
            {
                throw new CustomersDbException("El cliente no está registrado");
            }
            return customer;
        }



    }
}
