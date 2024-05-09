namespace student_management_backend.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; } // if we added this required key then it shouldn't be null
        public string? Address { get; set; } // can be nullable this String
        public int Age { get; set; }

    }
}
