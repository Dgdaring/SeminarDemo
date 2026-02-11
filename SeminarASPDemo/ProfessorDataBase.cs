namespace SeminarASPDemo
{
    public class ProfessorDataBase : IProfessorDataBase 
    {
        private List<Professor> professors =
        [
            new Professor{ Name="Frank McCown", Role="Professor of Computer Science", About="Dr. McCown has taught in the CS department since 1997. Over the years, Dr. McCown has worked as a researcher or software developer at several organizations including Lockheed Martin, Los Alamos National Laboratories, Flatirons Solutions, and Faithlife. He has published dozens of research papers in the areas of digital preservation and web archiving. Most recently, he has authored or co-authored textbooks on Web Programming, Mobile Application Development, and Database Management Systems. Dr. McCown has won the university's Teacher Achievement Award twice.\r\nFrank and his wife Becky have two children. Frank serves as a deacon at the Cloverdale Church of Christ and also volunteers for CASA helping foster children. He enjoys pickleball, basketball and lifting weights in his spare time."},
            new Professor{Name="Gabriel Foust", Role="Associate Professor of Computer Science", About = "Dr. Foust has been teaching CS at Harding since 2004. He has also worked as a software developer for IBM, Servergraph, and the National Cancer Institute. Dr. Foust is interested in Programming Language Design and Implementation, and he teaches courses in Object-Oriented Programming, Functional and Generic Programming, Algorithms, and Parallel Programming. He is also the coach of the Harding University Programming Team, which regularly competes with other schools in programming competitions. Dr. Foust won the university’s Teacher Achievement Award in 2024.\r\n\r\nGabriel and his wife Shannon have four children and are members of the Downtown Church of Christ. He enjoys hiking, biking, and playing board games with his kids, and has been known to appear in plays at the Searcy Summer Dinner Theater."},
            new Professor{Name="Dana Steil", Role="Associate Professor of Computer Science", About="Dr. Steil is the Dean of the College of Arts & Sciences and teaches part-time in the Computer Science department. For more than 20 years, he’s been working in student success, either as an administrator, data analyst, liaison between faculty and the Provost, or a classroom professor. Whether teaching, mentoring students in software development, or leading research grants tied to approximately $1M in the Criminal Justice and Traffic Safety fields, he’s motivated by his love for students and confidence in their impact in society and the Lord’s kingdom. Dr. Steil has won the university’s Teacher Achievement Award twice.\r\n\r\nDana and his wife Mandy have four children and are members of the Downtown Church of Christ. Dana enjoys woodworking, hiking, running, and other outdoor activities. The family serves as foster parents and hosts their church small group."},
            new Professor{Name="Hailey Fields", Role="Instructor of Computer Science", About = "Mrs. Fields, is a graduate of the University of Wisconsin – Madison, where she served as the TA for Discrete Mathematics and Introduction to Algorithms. Her general interests are in computational complexity and pseudorandom number generation. While an undergraduate student at Harding, Mrs. Fields spent much of her time tutoring local high school students. Mrs. Fields has always known she wanted to teach and is excited to be teaching at Harding.\r\n\r\nHailey and her husband Jon-Michael worship at the Cloverdale Church of Christ. In her spare time, Hailey enjoys baking and playing board games."},
            new Professor{Name="Scot Harris", Role="Assistant Professor", About = ""},
        ];
        public ProfessorDataBase() { }
        public Professor? GetProfessor(string name) {

            Professor SpecificProfessor = professors.FirstOrDefault(x => x.Name == name);
            return SpecificProfessor;
        }
        public void Delete(string name) {
            Professor SpecificProfessor = professors.FirstOrDefault(x => x.Name == name);
            if (SpecificProfessor != null)
                professors.Remove(SpecificProfessor);
        }
        public void Add(Professor professor)
        {
            professors.Add(professor);
        }
    }
}
