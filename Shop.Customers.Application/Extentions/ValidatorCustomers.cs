using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.CustomersDtos;
using Shop.Modules.Domain.Entities;
using System;

namespace Shop.Customers.Application.Extentions
{
    public static class ValidatorCustomers
    {
        public static CustomersDto ConvertCustEntityCustomersModel(this Modules.Domain.Entities.Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers), "El parámetro 'customers' no puede ser nulo.");
            }

            return new CustomersDto
            {
                
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

        public static CustomersDto ConvertCustEntityToCustomersDto(this Modules.Domain.Entities.Customers customers)
        {


            return new CustomersDto
            {
               
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

        public static void UpdateFromModels(this Modules.Domain.Entities.Customers customers, CustomersUpdateDto model)
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

        public static Modules.Domain.Entities.Customers SaveToCustomersEntity(this CustomersSaveDto customersSave)
        {
          

            return new Modules.Domain.Entities.Customers
            {
                
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

        public static Modules.Domain.Entities.Customers ToEntityRemove(this CustomersRemoveDto customerRemove)
        {
            

            return new Modules.Domain.Entities.Customers
            {
                
                companyname = customerRemove.companyname,
                contactname = customerRemove.contactname,
                contacttitle = customerRemove.contacttitle,
                address = customerRemove.address,
                email = customerRemove.email,
                city = customerRemove.city,
                region = customerRemove.region,
                postalcode = customerRemove.postalcode,
                country = customerRemove.country,
                phone = customerRemove.phone,
                fax = customerRemove.fax
            };
        }
    }
}
