namespace SeminarASPDemo
{
    public interface IProfessorDataBase
    {
        Professor? GetProfessor(string name);
        void Delete(string name);
        void Add(Professor professor);
    }
}
