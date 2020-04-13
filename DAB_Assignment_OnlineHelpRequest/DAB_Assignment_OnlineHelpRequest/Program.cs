using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using DAB_Assignment_OnlineHelpRequest.Data;
using DAB_Assignment_OnlineHelpRequest.Models;
using Microsoft.EntityFrameworkCore;

namespace DAB_Assignment_OnlineHelpRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello DAB Assignment");

            //Kan vi flytte dummy data til en ny fil/mappe?

            //Dummy data for Students
            IList<Student> newStudents = new List<Student>()
            {
                new Student() {StudentName = "Karl", StudentAUid = "au123456"},
                new Student() {StudentName = "Frans", StudentAUid = "au666666"},
                new Student() {StudentName = "Hans", StudentAUid = "au676767"},
                new Student() {StudentName = "Bubber", StudentAUid = "au678678"},
                new Student() {StudentName = "Tobias", StudentAUid = "au696969"},
                new Student() {StudentName = "Hank", StudentAUid = "au890890"},
                new Student() {StudentName = "Frank", StudentAUid = "au999999"}
            };

            //Dummy data for Courses
            IList<Course> newCourses = new List<Course>()
            {
                new Course() {CourseName = "DAB", courseId = "101"},
                new Course() {CourseName = "NGK", courseId = "102"},
                new Course() {CourseName = "SWD", courseId = "103"}
            };

            //Dummy data for which Courses Students Attends
            IList<Attends> newAttendses = new List<Attends>()
            {
                new Attends() {Semester = "4. Semester", Student = newStudents[0], Course = newCourses[0]},     //Karl attends DAB
                new Attends() {Semester = "4. Semester", Student = newStudents[1], Course = newCourses[0]},     //Frans attends DAB
                new Attends() {Semester = "4. Semester", Student = newStudents[0], Course = newCourses[1]},     //Karl attends NGK
                new Attends() {Semester = "4. Semester", Student = newStudents[1], Course = newCourses[2]},     //Frans attends SWD
                new Attends() {Semester = "4. Semester", Student = newStudents[2], Course = newCourses[2]},     //Hans attends SWD
                new Attends() {Semester = "4. Semester", Student = newStudents[0], Course = newCourses[2]},     //Karl attends SWD
                new Attends() {Semester = "4. Semester", Student = newStudents[3], Course = newCourses[0]}      //Bubber attends DAB
            };

            //Dummy data for Teachers
            IList<Teacher> newTeachers = new List<Teacher>()
            {
                new Teacher() {TeacherName = "Henrik Kirk", TeacherAUid = "au700001", Course = newCourses[0]},      //Henrik teaches DAB
                new Teacher() {TeacherName = "Michael Alrøe", TeacherAUid = "au700002", Course = newCourses[1]},    //Alrøe teachers NGK
                new Teacher() {TeacherName = "Michael Loft", TeacherAUid = "au700003", Course = newCourses[2]}      //Loft teaches SWD
            };

            IList<Exercise> newExercises = new List<Exercise>()
            {
                new Exercise() {number = "1", lecture = "EfCore Advanced", helpwhere = "Shannon 03B", Course = newCourses[0], Teacher = newTeachers[0], student = newStudents[0]},  //Karl skal have hjælp til opgave 1 i DAB
                new Exercise() {number = "2", lecture = "EfCore Intro", helpwhere = "Shannon 03B", Course = newCourses[0], Teacher = newTeachers[0], student = newStudents[0]},     //Karl skal have hjælp til opgave 2 i DAB
                new Exercise() {number = "1", lecture = "UDP", helpwhere = "Edison 114", Course = newCourses[1], Teacher = newTeachers[1], student = newStudents[0]},               //Karl skal have hjælp til opgave 1 i NGK
                new Exercise() {number = "2", lecture = "TCP", helpwhere = "Shannon 03B", Course = newCourses[1], Teacher = newTeachers[1], student = newStudents[2]},              //Hans skal have hjælp til opgave 2 i NGK
                new Exercise() {number = "3", lecture = "TCP", helpwhere = "Edison 114", Course = newCourses[1], Teacher = newTeachers[1], student = newStudents[0]},               //Karl skal have hjælp til opgave 3 i NGK
                new Exercise() {number = "1", lecture = "SOLID", helpwhere = "Shannon 03B", Course = newCourses[2], Teacher = newTeachers[2], student = newStudents[1]}             //Frans skal have hjælp til opgave 1 i SWD
            };

            //Dummy data for Assignments
            IList<Assignment> newAssignments = new List<Assignment>()
            {
                new Assignment() {number = "1", lecture = "EfCore Advanced", helpwhere = "Shannon 03B", Teacher = newTeachers[0], Course = newCourses[0]},      // Aflevering 1 til DAB 
                new Assignment() {number = "1", lecture = "TCP", helpwhere = "Shannon 03B", Teacher = newTeachers[1], Course = newCourses[1]},                  // Aflevering 1 til NGK
                new Assignment() {number = "1", lecture = "SOLID", helpwhere = "Edison 114", Teacher = newTeachers[2], Course = newCourses[2]},                 // Aflevering 1 til SWD
            };

            IList<RequestHelpAssignments> newHelpAssignmentses = new List<RequestHelpAssignments>()
            {
                new RequestHelpAssignments() {Student = newStudents[0], Assignment = newAssignments[0], Isactive = true}, // Karl arbejeder på Aflevering 1 til DAB
                new RequestHelpAssignments() {Student = newStudents[1], Assignment = newAssignments[0], Isactive = true}, // Frans arbejeder på Aflevering 1 til DAB
                new RequestHelpAssignments() {Student = newStudents[2], Assignment = newAssignments[0], Isactive = true}, // Hans arbejeder på Aflevering 1 til DAB
                new RequestHelpAssignments() {Student = newStudents[1], Assignment = newAssignments[1], Isactive = true}, // Frans arbejeder på Aflevering 1 til NGK
                new RequestHelpAssignments() {Student = newStudents[2], Assignment = newAssignments[1], Isactive = true}, // Hans arbejeder på Aflevering 1 til NGK
                new RequestHelpAssignments() {Student = newStudents[3], Assignment = newAssignments[1], Isactive = true}, // Bubber arbejeder på Aflevering 1 til NGK
                new RequestHelpAssignments() {Student = newStudents[1], Assignment = newAssignments[2], Isactive = false}, // Frans arbejeder på Aflevering 1 til SWD
                new RequestHelpAssignments() {Student = newStudents[2], Assignment = newAssignments[2], Isactive = true}, // Hans arbejeder på Aflevering 1 til SWD
                new RequestHelpAssignments() {Student = newStudents[3], Assignment = newAssignments[2], Isactive = true}, // Bubber arbejeder på Aflevering 1 til SWD
            };

            //Main program
            using (var context = new myDbContext())
            {
                Console.WriteLine("");
                Console.WriteLine("Press: a(Adds all dummy data), b(add courses)");
                Console.WriteLine("Press: s(Delete all dummy data)");
                Console.WriteLine("Press: l(list of StudentNames), k(list of courses), j(List of all teachers), g(see which course a student attends)");
                Console.WriteLine("Press: p(To search a specific student), o(To search open help requests for assignments for a student");
                Console.WriteLine("Press: i(To search either which open help request is connected to a teacher or a course)");
                Console.WriteLine("Press: u(To see statistics for a specific course)");
                Console.WriteLine("Creation: m(Student), n(Course), v(Teacher), c(Assignment), q(Exercise) & y(Help request)");
                Console.WriteLine("Press: h(See the help list again)");
                Console.WriteLine("Exit: x");

                while (true)
                {
                    Console.Write("Type Command:");
                    string line = Console.ReadLine();

                    switch (line)
                    {
                        case "a": //Case a will implement all the dummy data.
                            context.Students.AddRange(newStudents);
                            context.Teachers.AddRange(newTeachers);
                            context.Attends.AddRange(newAttendses);
                            context.Exercises.AddRange(newExercises);
                            context.Assignments.AddRange(newAssignments);
                            context.Courses.AddRange(newCourses);
                            context.RequestHelpAssignments.AddRange(newHelpAssignmentses);
                            context.SaveChanges();
                            break;

                        case "b": //What are you?
                            break;

                        case "s": //Case s will delete all the dummy data
                            context.Courses.RemoveRange(newCourses);
                            context.Students.RemoveRange(newStudents);
                            context.Teachers.RemoveRange(newTeachers);
                            context.Exercises.RemoveRange(newExercises);
                            context.Assignments.RemoveRange(newAssignments);
                            context.Attends.RemoveRange(newAttendses);
                            context.RequestHelpAssignments.RemoveRange(newHelpAssignmentses);
                            context.SaveChanges();
                            break;

                        case "l": //All students
                            foreach (var student in context.Students)
                            {
                                Console.WriteLine(student.StudentName + " " + student.StudentAUid);
                            }
                            break;

                        case "k": //All Courses
                            foreach (var course in context.Courses)
                            {
                                Console.WriteLine(course.CourseName + " " + course.courseId);
                            }
                            break;

                        case "j": //All Teachers
                            foreach (var teacher in context.Teachers)
                            {
                                Console.WriteLine(teacher.TeacherName + " " + teacher.TeacherAUid + " " + teacher.courseId);
                            }
                            break;

                        case "g": //Which course a student attends
                            foreach (var attends in context.Attends)
                            {
                                Console.WriteLine(attends.StudentId + " attends " + attends.CourseId + " during " + attends.Semester);
                            }
                            break;

                        case "p": //Specific student by AUID
                            Console.WriteLine("Enter the auID of the specific student: "); 
                            string IDinput = Console.ReadLine();

                            var user = context.Students.Find(IDinput);
                            Console.WriteLine(user.StudentName + " " + user.StudentAUid + " " + user.StudentExercises);

                            break;

                        case "o": //Specific help request for a student by AUID
                            Console.WriteLine("Enter the auID of the specific student: ");
                            string IDinput1 = Console.ReadLine();

                            List<RequestHelpAssignments> user1 = context.RequestHelpAssignments
                                .Where(a => a.StudentId == IDinput1 && a.Isactive == true)
                                .Include(b => b.Student)
                                .Include(c => c.Assignment)
                                .ToList();

                            foreach (var s in user1)
                            {
                                Console.WriteLine("Student " + s.Student.StudentName + " needs help with assignment " + s.Assignment.lecture + " in building " + s.Assignment.helpwhere);
                            }
                            break;

                        case "i": //See all help request for a given Teacher or Course
                            Console.WriteLine("Enter teacherID or courseID: ");
                            string NewInput = Console.ReadLine();

                            List<RequestHelpAssignments> user2 = context.RequestHelpAssignments
                                .Where(a => a.Assignment.Teacher.TeacherAUid == NewInput && a.Isactive == true ||
                                            a.Assignment.Course.courseId == NewInput && a.Isactive == true)
                                .Include(a => a.Assignment)
                                .ThenInclude(b => b.Teacher)
                                .Include(a => a.Assignment)
                                .ThenInclude(b => b.Course)
                                .Include(a => a.Student)
                                .ToList();

                            foreach (var b in user2)
                            {
                                Console.WriteLine("Student " + b.Student.StudentName + " needs help with assignment " + b.Assignment.lecture + " in building " + b.Assignment.helpwhere);
                            }
                            break;

                        case "u": //Statistics
                            Console.WriteLine("Enter courseID: ");
                            string CourseStats = Console.ReadLine();

                            List<RequestHelpAssignments> OpenReq = context.RequestHelpAssignments
                                .Where(a => a.Assignment.Course.courseId == CourseStats && a.Isactive == true)
                                .Include(a => a.Assignment)
                                .ThenInclude(b => b.Course)
                                .ToList();

                            List<RequestHelpAssignments> ClosedReq = context.RequestHelpAssignments
                                .Where(a => a.Assignment.Course.courseId == CourseStats && a.Isactive == false)
                                .Include(a => a.Assignment)
                                .ThenInclude(b => b.Course)
                                .ToList();

                            var CourseName = context.Courses.Find(CourseStats);

                            Console.WriteLine("For the course: " + CourseName.CourseName);
                            Console.WriteLine("The amount of open request: " + OpenReq.Count + " and closed request: " + ClosedReq.Count);
                            int Total = OpenReq.Count + ClosedReq.Count;
                            Console.WriteLine("Total amount request: " + Total);
                            break;

                        case "m":
                            Student newstudent = InputStudent();
                            context.Students.Add(newstudent);
                            context.SaveChanges();
                            break;

                        case "n":
                            Course newCourse = InputCourse();
                            context.Courses.Add(newCourse);
                            context.SaveChanges();
                            break;

                        case "v":
                            Teacher newTeacher = InputTeacher(context);
                            context.Teachers.Add(newTeacher);
                            context.SaveChanges();
                            break;

                        case "c":
                            Assignment newAssignment = InputAssignment(context);
                            context.Assignments.Add(newAssignment);
                            context.SaveChanges();
                            break;

                        case "q":
                            Exercise newExercise = InputExercise(context);
                            context.Exercises.Add(newExercise);
                            context.SaveChanges();
                            break;

                        case "y":
                            RequestHelpAssignments newreRequestHelpAssignments = InputRequestHelpAssignments(context);
                            context.RequestHelpAssignments.Add(newreRequestHelpAssignments);
                            context.SaveChanges();
                            break;

                        case "h":
                            Console.WriteLine("");
                            Console.WriteLine("Press: a(Adds all dummy data), b(add courses)");
                            Console.WriteLine("Press: s(Delete all dummy data)");
                            Console.WriteLine("Press: l(list of StudentNames), k(list of courses), j(List of all teachers), g(see which course a student attends)");
                            Console.WriteLine("Press: p(To search a specific student), o(To search open help requests for assignments for a student");
                            Console.WriteLine("Press: i(To search either which open help request is connected to a teacher or a course)");
                            Console.WriteLine("Press: u(To see statistics for a specific course)");
                            Console.WriteLine("Creation: m(Student), n(Course), v(Teacher), c(Assignment), q(Exercise) & y(Help request)");
                            Console.WriteLine("Press: h(See the help list again)");
                            Console.WriteLine("Exit: x");
                            break;

                        case "x": //Case x will exit the while loop and close the program
                            Console.WriteLine("Exiting..");
                            return;

                        default: //In case a case which is not implemented is used
                            Console.WriteLine("Unknown command");
                            break;

                    }
                }
            }
        }


        //Creating new objects!
        public static Student InputStudent()
        {
            Console.Write("Name: ");
            string studentname = Console.ReadLine();

            Console.Write("AuID: ");
            string AUid = Console.ReadLine();

            return new Student()
            {
                StudentName = studentname,
                StudentAUid = AUid
            };
        }

        public static Course InputCourse()
        {
            Console.Write("Course Name: ");
            string CName = Console.ReadLine();

            Console.Write("Course ID: ");
            string Courseid = Console.ReadLine();

            return new Course()
            {
                CourseName = CName,
                courseId = Courseid
            };
        }

        public static Teacher InputTeacher(myDbContext context)
        {
            Console.Write("CourseID teaching: ");
            string courseid = Console.ReadLine();

            Course course = context.Courses.Where(b => b.courseId == courseid).Single();

            Console.Write("Name: ");
            string TName = Console.ReadLine();

            Console.Write("AuID: ");
            string AUid = Console.ReadLine();

            Teacher Teacher = new Teacher()
            {
                TeacherName = TName,
                TeacherAUid = AUid,
            };

            if (course != null)
            {
                Teacher.Course = course;
            }
            else
            {
                Console.WriteLine("Course does not exist, create a course first");
                return null;
            }

            return Teacher;
        }

        public static Assignment InputAssignment(myDbContext context)
        {
            Console.Write("Assignment to CourseID: ");
            string courseid = Console.ReadLine();

            Course course = context.Courses.Where(b => b.courseId == courseid).Single();

            Console.Write("Assignment to TeacherID: ");
            string teachID = Console.ReadLine();

            Teacher teacher = context.Teachers.Where(a => a.TeacherAUid == teachID).Single();

            Console.Write("Number: ");
            string Anum = Console.ReadLine();

            Console.Write("Lecture: ");
            string ALec = Console.ReadLine();

            Console.Write("Help where: ");
            string Awhere = Console.ReadLine();

            Assignment assignment = new Assignment()
            {
                number = Anum,
                lecture = ALec,
                helpwhere = Awhere,
            };

            if (courseid != null && teachID != null)
            {
                assignment.Course = course;
                assignment.Teacher = teacher;
            }
            else
            {
                Console.WriteLine("Course or teacher does not exist");
                return null;
            }

            return assignment;
        }

        public static Exercise InputExercise(myDbContext context)
        {
            Console.Write("Assignment to CourseID: ");
            string courseid = Console.ReadLine();

            Course course = context.Courses.Where(b => b.courseId == courseid).Single();

            Console.Write("Assignment to TeacherID: ");
            string teachID = Console.ReadLine();

            Teacher teacher = context.Teachers.Where(a => a.TeacherAUid == teachID).Single();

            Console.Write("Assignment to StudentID: ");
            string StudID = Console.ReadLine();

            Student student = context.Students.Where(a => a.StudentAUid == StudID).Single();

            Console.Write("Number: ");
            string Enum = Console.ReadLine();

            Console.Write("Lecture: ");
            string ELec = Console.ReadLine();

            Console.Write("Help where: ");
            string Ewhere = Console.ReadLine();

            Exercise exercise = new Exercise()
            {
                number = Enum,
                lecture = ELec,
                helpwhere = Ewhere
            };

            if (courseid != null && teachID != null && StudID != null)
            {
                exercise.Course = course;
                exercise.Teacher = teacher;
                exercise.student = student;
            }
            else
            {
                Console.WriteLine("Course, teacher or student does not exist");
                return null;
            }

            return exercise;
        }

        public static RequestHelpAssignments InputRequestHelpAssignments(myDbContext context)
        {
            Console.Write("Assignment to StudentID: ");
            string StudID = Console.ReadLine();

            Student student = context.Students.Where(a => a.StudentAUid == StudID).Single();

            Console.Write("Assignment number: ");
            string Anum = Console.ReadLine();

            Console.Write("Assignment lecture: ");
            string Alec = Console.ReadLine();

            Assignment assignment = context.Assignments.Where(b => b.number == Anum && b.lecture == Alec).Single();

            RequestHelpAssignments requestHelpAssignments = new RequestHelpAssignments()
            {
                Isactive = true
            };

            if (student != null && assignment != null)
            {
                requestHelpAssignments.Assignment = assignment;
                requestHelpAssignments.Student = student;
            }
            else
            {
                Console.WriteLine("Student or Assignment number/lecture does not exist");
                return null;
            }

            return requestHelpAssignments;
        }

    }
}
