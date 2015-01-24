// Test for Git
using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
namespace iCathedra
{
    partial class Database
    {
    }

    partial class Post
    {
        public int NameLength
        {
            get { return Name.Length; }
        }

        /// <summary>
        /// Количество часов нагрузки на единицу ставки в заданному учебном году
        /// </summary>
        /// <param name="ASchoolYear"></param>
        /// <returns></returns>
        public int RateInHoursInSchoolYear(SchoolYear ASchoolYear)
        {
            if (ASchoolYear == null) return 0;
            foreach (PostSalary ps in this.PostSalary)
            {
                if (ps.SchoolYearID == ASchoolYear.ID) return Utils.SafeInt(ps.RateInHours);
            }
            return 0;
        }

        /// <summary>
        /// Коэффициент нагрузки в заданном учебном году
        /// </summary>
        /// <param name="ASchoolYear"></param>
        /// <returns></returns>
        public decimal KInSchoolYear(SchoolYear ASchoolYear)
        {
            if (ASchoolYear == null) return 0;
            foreach (PostSalary ps in this.PostSalary)
            {
                if (ps.SchoolYearID == ASchoolYear.ID) return Utils.SafeDecimal(ps.K);
            }
            return 0;
        }

        /// <summary>
        /// Базовый оклад в заданном учебном году
        /// </summary>
        /// <param name="ASchoolYear"></param>
        /// <returns></returns>
        public decimal BaseSalaryInSchoolYear(SchoolYear ASchoolYear)
        {
            if (ASchoolYear == null) return 0;
            foreach (PostSalary ps in this.PostSalary)
            {
                if (ps.SchoolYearID == ASchoolYear.ID) return Utils.SafeDecimal(ps.BaseSalary);
            }
            return 0;
        }

        /// <summary>
        /// Должностной оклад в заданном учебном году
        /// </summary>
        /// <param name="ASchoolYear"></param>
        /// <returns></returns>
        public decimal PostSalaryInSchoolYear(SchoolYear ASchoolYear)
        {
            if (ASchoolYear == null) return 0;
            foreach (PostSalary ps in this.PostSalary)
            {
                if (ps.SchoolYearID == ASchoolYear.ID) return Utils.SafeDecimal(ps.PostSalary1);
            }
            return 0;
        }

        /// <summary>
        /// Доплата за степень в заданном учебном году
        /// </summary>
        /// <param name="ASchoolYear"></param>
        /// <returns></returns>
        public decimal GradeSurchargeInSchoolYear(SchoolYear ASchoolYear)
        {
            if (ASchoolYear == null) return 0;
            foreach (PostSalary ps in this.PostSalary)
            {
                if (ps.SchoolYearID == ASchoolYear.ID) return Utils.SafeDecimal(ps.GradeSurcharge);
            }
            return 0;
        }

        /// <summary>
        /// Доплата за должность в заданном учебном году
        /// </summary>
        /// <param name="ASchoolYear"></param>
        /// <returns></returns>
        public decimal PostSurchargeInSchoolYear(SchoolYear ASchoolYear)
        {
            if (ASchoolYear == null) return 0;
            foreach (PostSalary ps in this.PostSalary)
            {
                if (ps.SchoolYearID == ASchoolYear.ID) return Utils.SafeDecimal(ps.PostSurcharge);
            }
            return 0;
        }

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}", this.Name);
        }
    }

    partial class Employee
    {
        public string ShortName
        {
            get { return this.ToString(); }
        }

        public override string ToString()
        {
            string[] _fio = this.Fio.Split(' ');
            string _f = "", _i = "", _o = "";
            if (_fio.Length >= 1) _f = _fio[0];
            if (_fio.Length >= 2) _i = _fio[1][0] + ".";
            if (_fio.Length >= 3) _o = _fio[2][0] + ".";

            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} {1} {2}{3}", 
                this.Post.ShortName,
                _f, _i, _o);
        }
    }

    partial class SchoolYear
    {
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}", this.Years);
        }
    }

    partial class Course
    {
        public decimal WorkloadFact
        {
            get
            {
                decimal workloadFact = 0;
                int currentSchoolYearId = iCathedra_Settings.SchoolYearId;
                if (this.CourseInWork != null)
                {
                    foreach (CourseInWork ACourseInWork in this.CourseInWork)
                    {
                        if ((ACourseInWork.Fact == (short)WorkloadType.Фактическая || ACourseInWork.Fact == (short)WorkloadType.Фактическая_и_формальная) &&
                            ACourseInWork.SchoolYearID == currentSchoolYearId)
                        {
                            workloadFact += (decimal)ACourseInWork.AllHours;
                        }
                    }
                }
                return workloadFact;
            }
        }

        public decimal WorkloadNorm
        {
            get
            {
                decimal workloadNorm = 0;
                int currentSchoolYearId = iCathedra_Settings.SchoolYearId;
                if (this.CourseInWork != null)
                {
                    foreach (CourseInWork ACourseInWork in this.CourseInWork)
                    {
                        if ((ACourseInWork.Fact == (short)WorkloadType.Формальная || ACourseInWork.Fact == (short)WorkloadType.Фактическая_и_формальная) &&
                            ACourseInWork.SchoolYearID == currentSchoolYearId)
                        {
                            workloadNorm += (decimal)ACourseInWork.AllHours;
                        }
                    }
                }
                return workloadNorm;
            }
        }

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}", this.Name);
        }

        /// <summary>
        /// Получает статистику по указанному курсу
        /// </summary>
        /// <returns></returns>
        public string GetStatistic()
        {
            var q = from ciw in this.CourseInWork
                    group ciw by new { SchoolYear = ciw.SchoolYear, Semestr = ciw.Semestr, Group1 = ciw.Group, Group2 = ciw.Group2, Group3 = ciw.Group3, Group4 = ciw.Group4 };

            string returnString = this.Name;
            foreach (var group in q)
            {
                if (returnString != "") returnString += "\n";
                returnString += String.Format("{0}, {1}, {2}", group.Key.SchoolYear.Years,
                    ((Semestr)group.Key.Semestr).ToString(),
                    group.Key.Group1);
                if (group.Key.Group2 != null) returnString += "," + group.Key.Group2.Group1;
                if (group.Key.Group3 != null) returnString += "," + group.Key.Group3.Group1;
                if (group.Key.Group4 != null) returnString += "," + group.Key.Group4.Group1;

                decimal totalWorkloadFact = 0;
                decimal totalWorkloadForm = 0;
                foreach (CourseInWork ciw in group)
                {
                    if (ciw.Fact == (short)WorkloadType.Фактическая || ciw.Fact == (short)WorkloadType.Фактическая_и_формальная)
                    {
                        totalWorkloadFact += ciw.AllHours;
                    }
                    if (ciw.Fact == (short)WorkloadType.Формальная || ciw.Fact == (short)WorkloadType.Фактическая_и_формальная)
                    {
                        totalWorkloadForm += ciw.AllHours;
                    }
                }
                returnString += String.Format(" - фактическая: {0}, формальная: {1}", totalWorkloadFact, totalWorkloadForm);
            }
            return returnString;
        }
    }

    /// <summary>
    /// Класс-контейнер для хранения данных о работе сотрудника
    /// в конкретном учебном году
    /// </summary>
    public class EmployeeInSchoolYear
    {
        private Employee _Employee;
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }

        private SchoolYear _SchoolYear;
        /// <summary>
        /// Учебный год
        /// </summary>
        public SchoolYear SchoolYear
        {
            get { return _SchoolYear; }
            set { _SchoolYear = value; }
        }

        public int ID
        {
            get { return Employee.Id; }
        }

        public string Fio
        {
            get { return Employee.Fio; }
        }

        public Post Post
        {
            get { return Employee.Post; }
        }

        public EmployeeInSchoolYear(Employee AEmployee, SchoolYear ASchoolYear)
        {
            this.Employee = AEmployee;
            this.SchoolYear = ASchoolYear;
        }

        /// <summary>
        /// Фактическая нагрузка в часах
        /// </summary>
        public decimal WorkloadFact
        {
            get
            {
                decimal workloadFact = 0;
                foreach (CourseInWork ACourseInWork in this.Employee.CourseInWork)
                {
                    if (ACourseInWork.Fact != null && ACourseInWork.SchoolYear.ID == this.SchoolYear.ID)
                    {
                        if (ACourseInWork.Fact == (short)WorkloadType.Фактическая ||
                            ACourseInWork.Fact == (short)WorkloadType.Фактическая_и_формальная)
                        {
                            workloadFact += (decimal)ACourseInWork.AllHours;
                        }
                    }
                }
                return workloadFact;
            }
        }

        /// <summary>
        /// Фактическая нагрузка в часах, на других преподавателях
        /// </summary>
        public decimal WorkloadFactTutor
        {
            get
            {
                decimal workloadFact = 0;
                foreach (CourseInWork ACourseInWork in this.Employee.CourseInWork)
                {
                    if (ACourseInWork.Fact != null && ACourseInWork.SchoolYear.ID == this.SchoolYear.ID)
                    {
                        if (ACourseInWork.Fact == (short)WorkloadType.Фактическая)
                        {
                            var q = from ciw in this.SchoolYear.CourseInWork
                                    where ciw.Semestr == ACourseInWork.Semestr &&
                                        ciw.CourseID == ACourseInWork.CourseID
                                    select ciw;
                            List<CourseInWork> coursesToFind = q.ToList<CourseInWork>();
                            // CourseInWork ciwTwin = ACourseInWork.GetTwin(coursesToFind);
                            CourseInWork ciwTwin = ACourseInWork.GetTwin();
                            if (ciwTwin != null && iCathedra_Settings.PochFondKod != ciwTwin.EmployeeID)
                            {
                                workloadFact += (decimal)ACourseInWork.AllHours;
                            }
                        }
                    }
                }
                return workloadFact;
            }
        }

        public decimal WorkloadFactPochFond
        {
            get
            {
                decimal workloadFact = 0;
                foreach (CourseInWork ACourseInWork in this.Employee.CourseInWork)
                {
                    if (ACourseInWork.Fact != null && ACourseInWork.SchoolYear.ID == this.SchoolYear.ID)
                    {
                        if (ACourseInWork.Fact == (short)WorkloadType.Фактическая)
                        {
                            var q = from ciw in this.SchoolYear.CourseInWork
                                    where ciw.Semestr == ACourseInWork.Semestr &&
                                        ciw.CourseID == ACourseInWork.CourseID
                                    select ciw;
                            List<CourseInWork> coursesToFind = q.ToList<CourseInWork>();
                            // CourseInWork ciwTwin = ACourseInWork.GetTwin(coursesToFind);
                            CourseInWork ciwTwin = ACourseInWork.GetTwin();
                            if (ciwTwin != null &&  ciwTwin.EmployeeID == iCathedra_Settings.PochFondKod)
                            {
                                workloadFact += (decimal)ACourseInWork.AllHours;
                            }
                        }
                    }
                }
                return workloadFact;
            }
        }

        /// <summary>
        /// Формальная нагрузка в часах
        /// </summary>
        public decimal WorkloadForm
        {
            get
            {
                decimal workloadForm = 0;
                foreach (CourseInWork ACourseInWork in this.Employee.CourseInWork)
                {
                    if (ACourseInWork.Fact != null && ACourseInWork.SchoolYear.ID == this.SchoolYear.ID)
                    {
                        if (ACourseInWork.Fact == (short)WorkloadType.Формальная ||
                            ACourseInWork.Fact == (short)WorkloadType.Фактическая_и_формальная)
                        {
                            workloadForm += (decimal)ACourseInWork.AllHours;
                        }
                    }
                }
                return workloadForm;
            }
        }

        /// <summary>
        /// Ставка по фактической нагрузке
        /// </summary>
        public decimal? RateFact
        {
            get
            {
                if (this.Post.RateInHoursInSchoolYear(this.SchoolYear) == null)
                    return null;
                else if (this.Post.RateInHoursInSchoolYear(this.SchoolYear) == 0)
                    return null;
                else
                    return Math.Round(WorkloadFact / (decimal)this.Post.RateInHoursInSchoolYear(this.SchoolYear), 3);
            }
        }

        /// <summary>
        /// Ставка по формальной нагрузке
        /// </summary>
        public decimal RateForm
        {
            get
            {
                decimal rateForm = 0;
                foreach (Rate r in this.Employee.Rate)
                {
                    if (r.SchoolYear.ID == this.SchoolYear.ID) 
                    {
                        rateForm += r.Rate1 == null ? 0 : (decimal)r.Rate1;
                    }
                }
                return rateForm;
            }
        }

        /// <summary>
        /// Лимит почасового фонда
        /// </summary>
        public int PochFondLimit
        {
            get
            {
                int limit = 0;
                foreach (Rate r in this.Employee.Rate)
                {
                    if (r.SchoolYear.ID == this.SchoolYear.ID)
                    {
                        limit = r.PochFondLimit;
                        break;
                    }
                }
                return limit;
            }
        }

        public decimal? RateFormByHours
        {
            get
            {
                if (this.Post.RateInHoursInSchoolYear(this.SchoolYear) == null)
                    return null;
                else if (this.Post.RateInHoursInSchoolYear(this.SchoolYear) == 0)
                    return null;
                else
                    return Math.Round(this.WorkloadForm / (decimal)this.Post.RateInHoursInSchoolYear(this.SchoolYear), 3);
            }
        }

        /// <summary>
        /// Количество часов по ставке
        /// </summary>
        public decimal RateInHours
        {
            get
            {
                decimal? rateInHours = this.Post.RateInHoursInSchoolYear(this.SchoolYear);
                if (rateInHours == null) rateInHours = 0;
                return Math.Round(this.RateForm * (decimal)rateInHours, 3);
            }
        }

        public bool IsOverload
        {
            get
            {
                decimal rateFormByHours = this.RateFormByHours == null ? 0 : (decimal)this.RateFormByHours;
                decimal highBound = RateForm + RateForm * iCathedra_Settings.LoadPercent / (decimal)100;
                if (rateFormByHours > highBound)
                    return true;
                else
                    return false;
            }
        }

        public bool IsUnderload
        {
            get
            {
                decimal rateFormByHours = this.RateFormByHours == null ? 0 : (decimal)this.RateFormByHours;
                decimal lowBound = RateForm - RateForm * iCathedra_Settings.LoadPercent / (decimal)100;
                if (rateFormByHours < lowBound)
                    return true;
                else
                    return false;

            }
        }

        /// <summary>
        /// Признак перегрузки по почасовому фонду 
        /// </summary>
        public bool IsPochFondOverload
        {
            get
            {
                return this.WorkloadFactPochFond > this.PochFondLimit;
            }
        }

        public decimal Overload
        {
            get
            {
                decimal overload = this.WorkloadForm - this.Post.RateInHoursInSchoolYear(this.SchoolYear) * this.RateForm;
                if (overload > 0)
                    return overload;
                else
                    return 0;
            }
        }

        public decimal Underload
        {
            get
            {
                decimal underload = this.Post.RateInHoursInSchoolYear(this.SchoolYear) * this.RateForm - this.WorkloadForm;
                if (underload > 0)
                    return underload;
                else
                    return 0;
            }
        }

        private string getHoursRow(decimal? AValue, string ADesc, CourseInWork ATwin)
        {
            if (Utils.SafeDecimal(AValue) != 0)
            {
                string _rs = "";
                _rs += ("                    " + ADesc + " - ").PadRight(40) + Utils.SafeDecimal(AValue).ToString();
                if (ATwin != null)
                {
                    if (ATwin.Fact == (short)WorkloadType.Формальная)
                        _rs += " (формально " + ATwin.Employee.ShortName.Trim() + ")";
                    else if (ATwin.Fact == (short)WorkloadType.Фактическая)
                        _rs += " (фактически " + ATwin.Employee.ShortName.Trim() + ")";
                }
                _rs += "\n";
                return _rs;
            }
            else
                return "";
        }
        
        public string GetEmployeeInfo(List<CourseInWork> CoursesToFind)
        {
            string returnString = "";

            returnString += "=======================================================================\n";
            returnString += ("ФИО: ").PadRight(40) + this.Fio + "\n";
            returnString += ("Должность: ").PadRight(40) + this.Employee.Post.Name + "\n";
            returnString += ("Учебный год: ").PadRight(40) + this.SchoolYear.Years + "\n";
            returnString += ("Ставка по коммерческому набору: ").PadRight(40) + this.RateForm.ToString() + "\n";
            returnString += ("Часов нагрузки согласно ставке:").PadRight(40) + this.RateInHours + "\n";
            returnString += "\n";

            #region Формальная нагрузка
            returnString += "============================================================\n";
            returnString += "Формальная нагрузка:\n";
            var q = from ciw in this.Employee.CourseInWork
                    where ciw.SchoolYear.ID == this.SchoolYear.ID &&
                        (ciw.Fact == (short?)WorkloadType.Формальная || ciw.Fact == (short?)WorkloadType.Фактическая_и_формальная)
                    orderby ciw.Semestr, ciw.Course.ID, ciw.Group.Group1
                    group ciw by new { Semestr = ciw.Semestr, Course = ciw.Course, Group1 = ciw.Group, Group2 = ciw.Group2, Group3 = ciw.Group3, Group4 = ciw.Group4 };

            short semestr = 0;
            decimal itogoSemestr = 0;
            decimal itogo = 0;
            foreach (var course in q)
            {
                if (semestr != course.Key.Semestr)
                {
                    if (semestr == (short)Semestr.Осенний)
                    {
                        returnString += ("Итого по семестру:").PadRight(40) + itogoSemestr.ToString() + "\n";
                        itogoSemestr = 0;
                    }
                    semestr = (short)course.Key.Semestr;
                    returnString += "\n"+ ((Semestr)semestr).ToString() + " семестр\n";
                }
                string group = "";
                if (course.Key.Group1 != null) group += course.Key.Group1.Group1;
                if (course.Key.Group2 != null) group += ","+ course.Key.Group2.Group1;
                if (course.Key.Group3 != null) group += "," + course.Key.Group3.Group1;
                if (course.Key.Group4 != null) group += "," + course.Key.Group4.Group1;
                returnString += course.Key.Course.Name + ", гр."+ group + "\n";
                foreach (CourseInWork ciw in course)
                {
                    returnString += getHoursRow(ciw.LectHours, "лекции", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.KonsHours, "консультации", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.ZachHours, "зачет", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.EkzHours, "экзамен", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.IzHours, "ИЗ", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.UprHours, "упражнения", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.LabHours, "лаб.раб.", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.KontrRabHours, "контр.раб.", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.KrHours, "КР", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.KpHours, "КП", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.ProchHours, "", ciw.GetTwin(CoursesToFind));

                    itogo += ciw.AllHours;
                    itogoSemestr += ciw.AllHours;
                }
            }
            returnString += ("Итого по семестру:").PadRight(40) + itogoSemestr.ToString() + "\n";
            returnString += ("ИТОГО:").PadRight(40) + itogo.ToString() + "\n\n";
            #endregion

            #region Фактическая нагрузка
            returnString += "============================================================\n";
            returnString += "Фактическая нагрузка:\n";
            q = from ciw in this.Employee.CourseInWork
                    where ciw.SchoolYear.ID == this.SchoolYear.ID &&
                        (ciw.Fact == (short?)WorkloadType.Фактическая || ciw.Fact == (short?)WorkloadType.Фактическая_и_формальная)
                orderby ciw.Semestr, ciw.Course.ID, ciw.Group.Group1
                group ciw by new { Semestr = ciw.Semestr, Course = ciw.Course, Group1 = ciw.Group, Group2 = ciw.Group2, Group3 = ciw.Group3, Group4 = ciw.Group4 };

            semestr = 0;
            itogoSemestr = 0;
            itogo = 0;
            foreach (var course in q)
            {
                if (semestr != course.Key.Semestr)
                {
                    if (semestr == (short)Semestr.Осенний)
                    {
                        returnString += ("Итого по семестру:").PadRight(40) + itogoSemestr.ToString() + "\n";
                        itogoSemestr = 0;
                    }
                    semestr = (short)course.Key.Semestr;
                    returnString += "\n" + ((Semestr)semestr).ToString() + " семестр\n";
                }
                string group = "";
                if (course.Key.Group1 != null) group += course.Key.Group1.Group1;
                if (course.Key.Group2 != null) group += "," + course.Key.Group2.Group1;
                returnString += course.Key.Course.Name + ", гр." + group + "\n";
                foreach (CourseInWork ciw in course)
                {
                    returnString += getHoursRow(ciw.LectHours, "лекции", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.KonsHours, "консультации", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.ZachHours, "зачет", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.EkzHours, "экзамен", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.IzHours, "ИЗ", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.UprHours, "упражнения", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.LabHours, "лаб.раб.", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.KontrRabHours, "контр.раб.", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.KrHours, "КР", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.KpHours, "КП", ciw.GetTwin(CoursesToFind));
                    returnString += getHoursRow(ciw.ProchHours, "", ciw.GetTwin(CoursesToFind));

                    itogo += ciw.AllHours;
                    itogoSemestr += ciw.AllHours;
                }
            }
            returnString += ("Итого по семестру:").PadRight(40) + itogoSemestr.ToString() + "\n";
            returnString += ("ИТОГО:").PadRight(40) + itogo.ToString() + "\n\n";
            #endregion

            #region Фактическая нагрузка, оплата из фондов
            //returnString += "============================================================\n";
            //returnString += "Фактическая нагрузка с оплатой из фондов:\n";
            //q = from ciw in this.Employee.CourseInWork
            //    where ciw.SchoolYear.ID == this.SchoolYear.ID &&
            //        (ciw.Fact == (short?)WorkloadType.Фактическая)
            //    orderby ciw.Semestr, ciw.Course.ID, ciw.Group.Group1
            //    group ciw by new { Semestr = ciw.Semestr, Course = ciw.Course, Group1 = ciw.Group, Group2 = ciw.Group2, Group3 = ciw.Group3, Group4 = ciw.Group4 };

            ////  select ciw).ToList<CourseInWork>();

            //foreach (var course in q)
            //{
            //    if (semestr != course.Key.Semestr)
            //    {
            //        if (semestr == (short)Semestr.Осенний)
            //        {
            //            returnString += ("Итого по семестру:").PadRight(40) + itogoSemestr.ToString() + "\n";
            //            itogoSemestr = 0;
            //        }
            //        semestr = (short)course.Key.Semestr;
            //        returnString += "\n" + ((Semestr)semestr).ToString() + " семестр\n";
            //    }
            //    string group = "";
            //    if (course.Key.Group1 != null) group += course.Key.Group1.Group1;
            //    if (course.Key.Group2 != null) group += "," + course.Key.Group2.Group1;
            //    returnString += course.Key.Course.Name + ", гр." + group + "\n";
            //    foreach (CourseInWork ciw in course)
            //    {
            //        returnString += getHoursRow(ciw.LectHours, "лекции");
            //        returnString += getHoursRow(ciw.KonsHours, "консультации");
            //        returnString += getHoursRow(ciw.ZachHours, "зачет");
            //        returnString += getHoursRow(ciw.EkzHours, "экзамен");
            //        returnString += getHoursRow(ciw.IzHours, "ИЗ");
            //        returnString += getHoursRow(ciw.UprHours, "упражнения");
            //        returnString += getHoursRow(ciw.LabHours, "лаб.раб.");
            //        returnString += getHoursRow(ciw.KontrRabHours, "контр.раб.");
            //        returnString += getHoursRow(ciw.KrHours, "КР");
            //        returnString += getHoursRow(ciw.KpHours, "КП");
            //        returnString += getHoursRow(ciw.ProchHours, "");

            //        itogo += ciw.AllHours;
            //        itogoSemestr += ciw.AllHours;
            //    }
            //}
            //returnString += ("Итого по семестру:").PadRight(40) + itogoSemestr.ToString() + "\n";
            //returnString += ("ИТОГО:").PadRight(40) + itogo.ToString() + "\n\n";
            #endregion

            return returnString;
        }

        public Dictionary<Employee, decimal> SplitByFormalEmployee(List<CourseInWork> CoursesToFind)
        {
            Dictionary<Employee, decimal> d = new Dictionary<Employee, decimal>();
            foreach (CourseInWork ciw in this.Employee.CourseInWork)
            {
                if (ciw.Fact != null && ciw.SchoolYear.ID == this.SchoolYear.ID)
                {
                    if (ciw.Fact == (short)WorkloadType.Фактическая)
                    {
                        CourseInWork twinCiw;
                        if (this.SchoolYear.ID < 4)
                            twinCiw = ciw.GetTwin(CoursesToFind);
                        else
                            twinCiw = ciw.GetTwin();
                        if (twinCiw.EmployeeID != ciw.EmployeeID && twinCiw.Employee.PostID != 5)
                        {
                            if (d.ContainsKey(twinCiw.Employee))
                                d[twinCiw.Employee] += ciw.AllHours;
                            else
                                d.Add(twinCiw.Employee, ciw.AllHours);
                        }
                    }
                }
            }
            return d;
        }

        public decimal Salary
        {
            get
            {
                decimal salary = 0;
                salary += this.Post.BaseSalaryInSchoolYear(this.SchoolYear) +
                    this.Post.PostSalaryInSchoolYear(this.SchoolYear) +
                    this.Post.GradeSurchargeInSchoolYear(this.SchoolYear) +
                    this.Post.PostSurchargeInSchoolYear(this.SchoolYear);
                // Ставка
                salary = salary * this.RateForm;
                // Налог
                salary = Math.Round(salary*0.86m);
                return salary;
            }
        }
    }

    public partial class CourseInWork
    {
        public CourseInWork Clone(WorkloadHourType wht)
        {
            CourseInWork ciw = new CourseInWork();
            Clone(ref ciw, wht);
            return ciw;
        }

        public void Clone(ref CourseInWork ACourseInWork, WorkloadHourType wht)
        {
            ACourseInWork.Course = this.Course;
            // ACourseInWork.Group1ID = this.Group1ID;
            ACourseInWork.Group = this.Group;
            // ACourseInWork.Group2ID = this.Group2ID;
            ACourseInWork.Group2 = this.Group2;
            ACourseInWork.Group3 = this.Group3;
            ACourseInWork.Group4 = this.Group4;
            ACourseInWork.SchoolYear = this.SchoolYear;
            // ACourseInWork.SchoolYearID = this.SchoolYearID;
            ACourseInWork.Semestr = this.Semestr;
            ACourseInWork.Employee = this.Employee;
            // ACourseInWork.EmployeeID = this.EmployeeID;
            if ((wht & WorkloadHourType.Лекции) != 0) ACourseInWork.LectHours = this.LectHours;
            if ((wht & WorkloadHourType.Консультации) != 0) ACourseInWork.KonsHours = this.KonsHours;
            if ((wht & WorkloadHourType.Зачет) != 0) ACourseInWork.ZachHours = this.ZachHours;
            if ((wht & WorkloadHourType.Экзамен) != 0) ACourseInWork.EkzHours = this.EkzHours;
            if ((wht & WorkloadHourType.Индивидуальные_занятия) != 0) ACourseInWork.IzHours = this.IzHours;
            if ((wht & WorkloadHourType.Упражнения) != 0) ACourseInWork.UprHours = this.UprHours;
            if ((wht & WorkloadHourType.Лабораторные) != 0) ACourseInWork.LabHours = this.LabHours;
            if ((wht & WorkloadHourType.Контрольная_работа) != 0) ACourseInWork.KontrRabHours = this.KontrRabHours;
            if ((wht & WorkloadHourType.Курсовой_проект) != 0) ACourseInWork.KpHours = this.KpHours;
            if ((wht & WorkloadHourType.Курсовая_работа) != 0) ACourseInWork.KrHours = this.KrHours;
            if ((wht & WorkloadHourType.Прочее) != 0) ACourseInWork.ProchHours = this.ProchHours;
            // ACourseInWork.AllHours = this.AllHours;
            ACourseInWork.Fact = this.Fact;
            ACourseInWork.Room = this.Room;
        }

        /// <summary>
        /// Универсальный метод разбиения текущей нагрузки на две записи.
        /// Важно - если AWorkloadHourTypeToSplit == None, то нагрузка дублируется (переписываются все часы)
        /// </summary>
        /// <returns></returns>
        public CourseInWork Split(WorkloadType ASourceFactType, WorkloadType ADestFactType, 
            Employee ASourceEmployee, Employee ADestEmployee,
            WorkloadHourType AWorkloadHourTypeToSplit,
            WorkloadMoveType AWorkloadMoveType)
        {
            CourseInWork ciw = this.Clone(AWorkloadHourTypeToSplit);
            this.Fact = (short)ASourceFactType;
            ciw.Fact = (short)ADestFactType;
            this.Employee = ASourceEmployee;
            ciw.Employee = ADestEmployee;

            if (AWorkloadMoveType == WorkloadMoveType.Переносится)
            {
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Лекции) != 0) this.LectHours = 0;
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Консультации) != 0) this.KonsHours = 0; 
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Зачет) != 0) this.ZachHours = 0;
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Экзамен) != 0) this.EkzHours = 0;
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Индивидуальные_занятия) != 0) this.IzHours = 0;
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Упражнения) != 0) this.UprHours = 0;
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Лабораторные) != 0) this.LabHours = 0; 
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Контрольная_работа) != 0) this.KontrRabHours = 0;
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Курсовая_работа) != 0) this.KrHours = 0;
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Курсовой_проект) != 0) this.KpHours = 0;
                if ((AWorkloadHourTypeToSplit & WorkloadHourType.Прочее) != 0) this.ProchHours = 0;
            }

            return ciw;
        }

        /// <summary>
        /// Универсальный метод переброски нагрузки на нового преподавателя
        /// </summary>
        //public void Move(Employee ANewEmployee)
        //{
        //    this.Employee = ANewEmployee;
        //}

        /// <summary>
        /// Универсальный метод слияния нагрузки. После слияния CourseInWork, передаваемый в параметрах следует удалить.
        /// Сливаются только часы.
        /// </summary>
        /// <param name="JoinedCourseInWork"></param>
        public void Join(CourseInWork jciw, WorkloadHourType wht)
        {
            if ((wht & WorkloadHourType.Лекции) != 0 && jciw.LectHours != null) this.LectHours += jciw.LectHours;
            if ((wht & WorkloadHourType.Консультации) != 0 && jciw.KonsHours != null) this.KonsHours += jciw.KonsHours;
            if ((wht & WorkloadHourType.Зачет) != 0 && jciw.ZachHours != null) this.ZachHours += jciw.ZachHours;
            if ((wht & WorkloadHourType.Экзамен) != 0 && jciw.EkzHours != null) this.EkzHours += jciw.EkzHours;
            if ((wht & WorkloadHourType.Индивидуальные_занятия) != 0 && jciw.IzHours != null) this.IzHours += jciw.IzHours;
            if ((wht & WorkloadHourType.Упражнения) != 0 && jciw.UprHours != null) this.UprHours += jciw.UprHours;
            if ((wht & WorkloadHourType.Лабораторные) != 0 && jciw.LabHours != null) this.LabHours += jciw.LabHours;
            if ((wht & WorkloadHourType.Контрольная_работа) != 0 && jciw.KontrRabHours != null) this.KontrRabHours += jciw.KontrRabHours;
            if ((wht & WorkloadHourType.Курсовой_проект) != 0 && jciw.KpHours != null) this.KpHours += jciw.KpHours;
            if ((wht & WorkloadHourType.Курсовая_работа) != 0 && jciw.KrHours != null) this.KrHours += jciw.KrHours;
            if ((wht & WorkloadHourType.Прочее) != 0 && jciw.ProchHours != null) this.ProchHours += jciw.ProchHours;
        }

        public decimal AllHours
        {
            get
            {
                decimal allHours = 0;
                allHours += this.LectHours == null ? 0 : (decimal)this.LectHours;
                allHours += this.KonsHours == null ? 0 : (decimal)this.KonsHours;
                allHours += this.ZachHours == null ? 0 : (decimal)this.ZachHours;
                allHours += this.EkzHours == null ? 0 : (decimal)this.EkzHours;
                allHours += this.IzHours == null ? 0 : (decimal)this.IzHours;
                allHours += this.UprHours == null ? 0 : (decimal)this.UprHours;
                allHours += this.LabHours == null ? 0 : (decimal)this.LabHours;
                allHours += this.KontrRabHours == null ? 0 : (decimal)this.KontrRabHours;
                allHours += this.KrHours == null ? 0 : (decimal)this.KrHours;
                allHours += this.KpHours == null ? 0 : (decimal)this.KpHours;
                allHours += this.ProchHours == null ? 0 : (decimal)this.ProchHours;
                return allHours;
            }
        }

        public decimal GetHours(WorkloadHourType wht)
        {
            decimal hours = 0;
            if (this.LectHours != null && (wht & WorkloadHourType.Лекции) != 0) hours += this.LectHours.Value;
            if (this.KonsHours != null && (wht & WorkloadHourType.Консультации ) != 0) hours += this.KonsHours.Value;
            if (this.ZachHours != null && (wht & WorkloadHourType.Зачет) != 0) hours += this.ZachHours.Value;
            if (this.EkzHours != null && (wht & WorkloadHourType.Экзамен) != 0) hours += this.EkzHours.Value;
            if (this.IzHours != null && (wht & WorkloadHourType.Индивидуальные_занятия) != 0) hours += this.IzHours.Value;
            if (this.UprHours != null && (wht & WorkloadHourType.Упражнения) != 0) hours += this.UprHours.Value;
            if (this.LabHours != null && (wht & WorkloadHourType.Лабораторные) != 0) hours += this.LabHours.Value;
            if (this.KontrRabHours != null && (wht & WorkloadHourType.Контрольная_работа) != 0) hours += this.KontrRabHours.Value;
            if (this.KrHours != null && (wht & WorkloadHourType.Курсовая_работа) != 0) hours += this.KrHours.Value;
            if (this.KpHours != null && (wht & WorkloadHourType.Курсовой_проект) != 0) hours += this.KpHours.Value;
            if (this.ProchHours != null && (wht & WorkloadHourType.Прочее) != 0) hours += this.ProchHours.Value;
            return hours;
        }

        private void addDecimalToDictionary(string paramName, decimal? workload, ref Dictionary<string, decimal> dic)
        {
            if (workload != null) if (workload != 0) dic.Add(paramName, (decimal)workload);
        }

        public Dictionary<string, decimal> GetHours(bool Trimestr1, bool Trimestr2, bool Trimestr3)
        {
            Dictionary<string, decimal> rd = new Dictionary<string, decimal>();
            if (Trimestr1 && this.Semestr == (short)iCathedra.Semestr.Осенний)
            {
                addDecimalToDictionary("лекц", this.LectHours, ref rd);
                addDecimalToDictionary("ИЗ", this.IzHours, ref rd);
                addDecimalToDictionary("упр", this.UprHours, ref rd);
                addDecimalToDictionary("лаб", this.LabHours, ref rd);
            }
            if (Trimestr2 && this.Semestr == (short)iCathedra.Semestr.Осенний)
            {
                addDecimalToDictionary("конс", this.KonsHours, ref rd);
                addDecimalToDictionary("зач", this.ZachHours, ref rd);
                addDecimalToDictionary("экз", this.EkzHours, ref rd);
                addDecimalToDictionary("к.р.", this.KontrRabHours, ref rd);
                addDecimalToDictionary("КР", this.KrHours, ref rd);
                addDecimalToDictionary("КП", this.KpHours, ref rd);
                addDecimalToDictionary("проч", this.ProchHours, ref rd);
            }
            if (Trimestr2 && this.Semestr == (short)iCathedra.Semestr.Весенний)
            {
                addDecimalToDictionary("лекц", this.LectHours, ref rd);
                addDecimalToDictionary("ИЗ", this.IzHours, ref rd);
                addDecimalToDictionary("упр", this.UprHours, ref rd);
                addDecimalToDictionary("лаб", this.LabHours, ref rd);
            }
            if (Trimestr3 && this.Semestr == (short)iCathedra.Semestr.Весенний)
            {
                addDecimalToDictionary("конс", this.KonsHours, ref rd);
                addDecimalToDictionary("зач", this.ZachHours, ref rd);
                addDecimalToDictionary("экз", this.EkzHours, ref rd);
                addDecimalToDictionary("к.р.", this.KontrRabHours, ref rd);
                addDecimalToDictionary("КР", this.KrHours, ref rd);
                addDecimalToDictionary("КП", this.KpHours, ref rd);
                addDecimalToDictionary("проч", this.ProchHours, ref rd);
            }
            return rd;
        }

        /// <summary>
        /// Группы одной строкой
        /// </summary>
        public string Groups
        {
            get
            {
                string returnString = "";
                if (this.Group != null) returnString += this.Group.Group1;
                if (this.Group2 != null) returnString += "," + this.Group2.Group1;
                if (this.Group3 != null) returnString += "," + this.Group3.Group1;
                if (this.Group4 != null) returnString += "," + this.Group4.Group1;
                return returnString;
            }
        }

        public string SemestrString
        {
            get
            {
                if (this.Semestr == null) return "";
                iCathedra.Semestr SemestrEnum = (iCathedra.Semestr)Utils.SafeInt(this.Semestr);
                return SemestrEnum.ToString();
            }
        }

        /// <summary>
        /// Полное наименование курса
        /// </summary>
        public string FullName
        {
            get
            {
                string returnString = String.Format("{0}, преподаватель {1}, гр. {2}, " +
                    "учебный год {3}, семестр {4}",
                    this.Course.Name,
                    this.Employee.ShortName,
                    this.Groups,
                    this.SchoolYear.Years,
                    this.SemestrString);
                return returnString;
            }
        }

        /// <summary>
        /// Нагрузка в часах
        /// </summary>
        public string Workload
        {
            get
            {
                string returnString = "";
                if (this.LectHours != null) if (this.LectHours != 0) 
                    returnString += "лекц " + this.LectHours.ToString();
                if (this.KonsHours != null) if (this.KonsHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "конс " + this.KonsHours.ToString();
                    }
                if (this.EkzHours != null) if (this.EkzHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "экз " + this.EkzHours.ToString();
                    }
                if (this.ZachHours != null) if (this.ZachHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "зач " + this.ZachHours.ToString();
                    }
                if (this.IzHours != null) if (this.IzHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "ИЗ " + this.IzHours.ToString();
                    }
                if (this.UprHours != null) if (this.UprHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "упр " + this.UprHours.ToString();
                    }
                if (this.LabHours != null) if (this.LabHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "лаб " + this.LabHours.ToString();
                    }
                if (this.KontrRabHours != null) if (this.KontrRabHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "к.р. " + this.KontrRabHours.ToString();
                    }
                if (this.KrHours != null) if (this.KrHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "КР " + this.KrHours.ToString();
                    }
                if (this.KpHours != null) if (this.KpHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "КП " + this.KpHours.ToString();
                    }
                if (this.AllHours != 0)
                    {
                        if (returnString != "") returnString += ", ";
                        returnString += "всего " + this.AllHours.ToString();
                    }

                return returnString;
            }
        }

        /// <summary>
        /// Сокращенное наименование курса
        /// </summary>
        public string ShortName
        {
            get
            {
                string returnString = String.Format("{0}, нагрузка {1}, {2}",
                    this.Employee.ShortName,
                    ((WorkloadType)this.Fact).ToString().Replace('_',' '),
                    this.Workload);
                return returnString;
            }
        }

        public string WorkloadTypeString
        {
            get
            {
                return ((WorkloadType)this.Fact).ToString().Replace('_', ' ');
            }
        }

        /// <summary>
        /// Для данного курса с типом нагрузки "фактический" находит его "близнеца" - курс с формальной нагрузкой
        /// </summary>
        /// <param name="CoursesToFind"></param>
        /// <returns></returns>
        public CourseInWork GetTwin(List<CourseInWork> CoursesToFind)
        {
            CourseInWork _twin;
            if (this.SchoolYearID < 4)
            {
                WorkloadType _wtToFind;
                if (this.Fact == (short)WorkloadType.Фактическая)
                    _wtToFind = WorkloadType.Формальная;
                else if (this.Fact == (short)WorkloadType.Формальная)
                    _wtToFind = WorkloadType.Фактическая;
                else
                    return null;

                _twin = CoursesToFind.FirstOrDefault(c =>
                    c.Course.ID == this.Course.ID &&
                    c.SchoolYear.ID == this.SchoolYear.ID &&
                    c.Semestr == this.Semestr &&
                    c.Group.Group1 == this.Group.Group1 &&
                    c.Fact == (short)_wtToFind &&
                    (c.LectHours == null ? 0 : c.LectHours) == (this.LectHours == null ? 0 : this.LectHours) &&
                    (c.KonsHours == null ? 0 : c.KonsHours) == (this.KonsHours == null ? 0 : this.KonsHours) &&
                    (c.ZachHours == null ? 0 : c.ZachHours) == (this.ZachHours == null ? 0 : this.ZachHours) &&
                    (c.EkzHours == null ? 0 : c.EkzHours) == (this.EkzHours == null ? 0 : this.EkzHours) &&
                    (c.IzHours == null ? 0 : c.IzHours) == (this.IzHours == null ? 0 : this.IzHours) &&
                    (c.UprHours == null ? 0 : c.UprHours) == (this.UprHours == null ? 0 : this.UprHours) &&
                    (c.LabHours == null ? 0 : c.LabHours) == (this.LabHours == null ? 0 : this.LabHours) &&
                    (c.KontrRabHours == null ? 0 : c.KontrRabHours) == (this.KontrRabHours == null ? 0 : this.KontrRabHours) &&
                    (c.KrHours == null ? 0 : c.KrHours) == (this.KrHours == null ? 0 : this.KrHours) &&
                    (c.KpHours == null ? 0 : c.KpHours) == (this.KpHours == null ? 0 : this.KpHours) &&
                    (c.ProchHours == null ? 0 : c.ProchHours) == (this.ProchHours == null ? 0 : this.ProchHours));
            }
            else
                _twin = this.GetTwin();

            return _twin;
        }

        public CourseInWork GetTwin()
        {
            return this.Twin;
        }

        public static void MakeTwins(ref CourseInWork ciw1, ref CourseInWork ciw2)
        {
            ciw1.Twin = ciw2;
            ciw2.Twin = ciw1;
        }

        public string TwinEmployeeShortName
        {
            get
            {
                if (Twin != null)
                    return Twin.Employee.ShortName;
                else
                    return "";
            }
        }

    }

    partial class Rate
    {
        private const decimal NDFL = 13;

        /// <summary>
        /// Ставка, скорректированная с учетом занимаемой должности
        /// </summary>
        public decimal CorrectedRate
        {
            get
            {
                decimal correctedRate = 0;
                if (this.Post == null) return 0;
                correctedRate =  Utils.SafeDecimal(this.Rate1) * 
                    this.Post.KInSchoolYear(this.SchoolYear);
                return Math.Round(correctedRate, 4);
            }
        }

        /// <summary>
        /// Налог (в процентах)
        /// </summary>
        private decimal nalog
        {
            get
            {
                decimal nalog = NDFL;
                if (this.IsTradeUnionMember != null) if ((bool)this.IsTradeUnionMember) nalog = nalog + 1;
                return nalog;
            }
        }

        /// <summary>
        /// Базовый оклад
        /// </summary>
        public decimal BaseSalary
        {
            get
            {
                if (this.Post == null) return 0;
                decimal baseSalary = Utils.SafeDecimal(this.Rate1) * 
                    this.Post.BaseSalaryInSchoolYear(SchoolYear) *
                    (1 - nalog / 100);
                return Math.Round(baseSalary, 2);
            }
        }

        /// <summary>
        /// Должностной оклад
        /// </summary>
        public decimal PostSalary
        {
            get
            {
                if (this.Post == null) return 0;
                decimal postSalary = Utils.SafeDecimal(this.Rate1) *
                    this.Post.PostSalaryInSchoolYear(SchoolYear) *
                    (1 - nalog / 100);
                return Math.Round(postSalary, 2);
            }
        }

        /// <summary>
        /// Доплата за степень
        /// </summary>
        public decimal GradeSurcharge
        {
            get
            {
                if (this.Post == null) return 0;
                decimal gradeSurcharge = Utils.SafeDecimal(this.Rate1) *
                    this.Post.GradeSurchargeInSchoolYear(SchoolYear) *
                    (1 - nalog / 100);
                return Math.Round(gradeSurcharge, 2);
            }
        }

        /// <summary>
        /// Доплата за должность
        /// </summary>
        public decimal PostSurcharge
        {
            get
            {
                if (this.Post == null) return 0;
                decimal postSurcharge = Utils.SafeDecimal(this.Rate1) *
                    this.Post.PostSurchargeInSchoolYear(SchoolYear) *
                    (1 - nalog / 100);
                return Math.Round(postSurcharge, 2);
            }
        }
    }

    partial class Group
    {
        public override string ToString()
        {
            return this.Group1;
        }
    }
}

