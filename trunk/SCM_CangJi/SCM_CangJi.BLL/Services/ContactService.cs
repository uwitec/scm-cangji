using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;

namespace SCM_CangJi.BLL.Services
{
    public class ContactService:BaseService<ContactService>
    {
        public object GetContacts(int companyId)
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                var company = context.Companies.SingleOrDefault(o => o.Id == companyId);
                result = company.Contacts.ToList();
                        
            });
            return result;
        }

        public bool Delete(int contactId)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                var contact = context.Contacts.SingleOrDefault(o => o.Id == contactId);
                context.Contacts.DeleteOnSubmit(contact);

                context.SubmitChanges();
            });
            return true;
        }

        public Contact GetContact(int contactId)
        {
            Contact contact = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                contact = context.Contacts.SingleOrDefault(o => o.Id == contactId);
            });
            return contact;
        }

        public void Update(Contact contact)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                var c = context.Contacts.SingleOrDefault(o => o.Id == contact.Id);
                c.Email = contact.Email;
                c.Name = contact.Name;
                c.Gender = contact.Gender;
                c.IsActived = contact.IsActived;
                c.Phone1 = contact.Phone1;
                c.Phone2 = contact.Phone2;
                c.Phone3 = contact.Phone3;
                context.SubmitChanges();
            });
        }

        public void Insert(Contact contact)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                context.Contacts.InsertOnSubmit(contact);
                context.SubmitChanges();
            });
        }
    }
}
