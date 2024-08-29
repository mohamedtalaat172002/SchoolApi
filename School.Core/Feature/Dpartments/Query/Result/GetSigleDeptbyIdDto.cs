using School.Core.Wrapper;

namespace School.Core.Feature.Dpartments.Query.Result
{
    public class GetSigleDeptbyIdDto
    {
        public int DID { get; set; }
        public string? DepartmentName { get; set; }
        public int InsManagerId { get; set; }
        public string? ManagerName { get; set; }


        public PaginatedResult<StudentResponse> StudentsList { get; set; }
        public List<SubjectResponse> SubjectsList { get; set; }
        public List<InstructorResponse> InstructorsList { get; set; }

    }
    public class StudentResponse
    {
        public int id { get; set; }
        public string name { get; set; }

        public StudentResponse(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    public class InstructorResponse
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class SubjectResponse
    {
        public int id { get; set; }
        public string name { get; set; }
    }




}
