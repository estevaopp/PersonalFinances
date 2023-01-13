

namespace PersonalFinances.Domain.Entities
{
    public class UserRole : EntityBase
    {
        
        public string Name { get; private set; }

        public string Description { get; private set; }
        

        protected UserRole() { }

        public UserRole(string name, string description) 
        {
            this.Name = name;
            this.Description = description;
        }


        public void Update(string name, string description) 
        {
            this.Name = name;
            this.Description = description;
        }
    }
}