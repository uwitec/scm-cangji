using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;

namespace SCM_CangJi.BLL.Services
{
    public class DeliverAddressService : BaseService<DeliverAddressService>
    {
        public object GetAddresses(int companyId)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var company = db.Companies.SingleOrDefault(o => o.Id == companyId);
                reslut = (from a in company.DeliverAddresses
                          select new
                          {
                              a.Address,
                              a.AddressCode,
                              a.AddressName,
                              a.DeliverDays,
                              a.Id
                          }).ToList();
            });
            return reslut;
        }

        public bool Delete(int addressId)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var address = db.DeliverAddresses.SingleOrDefault(o => o.Id == addressId);
                db.DeliverAddresses.DeleteOnSubmit(address);
                db.SubmitChanges();
            });
            return true;
        }

        public DeliverAddress GetAddress(int addressId)
        {
            DeliverAddress address = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                address = db.DeliverAddresses.SingleOrDefault(o => o.Id == addressId);
            });
            return address;
        }

        public void Update(DeliverAddress deliverAddress)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var address = db.DeliverAddresses.SingleOrDefault(o => o.Id == deliverAddress.Id);
                address.Address = deliverAddress.Address;
                address.AddressCode = deliverAddress.AddressCode;
                address.AddressName = deliverAddress.AddressName;
                address.DeliverDays = deliverAddress.DeliverDays;
                db.SubmitChanges();
            });
        }

        public void Create(DeliverAddress deliverAddress)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                db.DeliverAddresses.InsertOnSubmit(deliverAddress);
                db.SubmitChanges();
            });
        }
    }
}
