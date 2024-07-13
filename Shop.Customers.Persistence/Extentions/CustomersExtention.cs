using Shop.CUser.Persistence.Context;
using Shop.CUser.Persistence.Exception;
using Shop.CUser.Persistence.Model;
using Shop.CUser.Persistence.Models;


namespace Shop.CUser.Persistence.Extentions
{
    public static class CustomersExtentions
    {


        public static CustomersModel ConvertCustEntityCustomersModel(this Modules.Domain.Entities.Customers customers)
        {

            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers), "El parámetro 'customers' no puede ser nulo.");
            }
            CustomersModel customersmodel = new CustomersModel()
            {

                custid = customers.custid,
                companyname = customers.companyname,
                contactname = customers.contactname,
                contacttitle = customers.contacttitle,
                address = customers.address,
                email = customers.email,
                city = customers.city,
                region = customers.region,
                postalcode = customers.postalcode,
                country = customers.country,
                phone = customers.phone,
                fax = customers.fax
            };
            return customersmodel;

        }

        public static CustomersModel ConvertCustEntityToCustomersModel(this Modules.Domain.Entities.Customers customers)
        {
            return new CustomersModel
            {
                custid = customers.custid,
                companyname = customers.companyname,
                contactname = customers.contactname,
                contacttitle = customers.contacttitle,
                address = customers.address,
                email = customers.email,
                city = customers.city,
                region = customers.region,
                postalcode = customers.postalcode,
                country = customers.country,
                phone = customers.phone,
                fax = customers.fax
            };
        }


        public static void UpdateFromModels(this Modules.Domain.Entities.Customers customers, CustomersUpdateModel model)
        {
            customers.custid = model.custid;
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
        public static Modules.Domain.Entities.Customers ConvertCustomersSaveModelToCustomersEntity(this CustomersSaveModel customersSave)
        {
            return new Modules.Domain.Entities.Customers
            {
                custid = customersSave.custid,
                companyname = customersSave.companyname,
                contactname = customersSave.contactname,
                contacttitle = customersSave.contacttitle,
                address = customersSave.address,
                email = customersSave.email,
                city = customersSave.city,
                region = customersSave.region,
                postalcode = customersSave.postalcode,
                country = customersSave.country,
                phone = customersSave.phone,
                fax = customersSave.fax

            };
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
