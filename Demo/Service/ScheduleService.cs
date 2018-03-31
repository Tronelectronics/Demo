using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Service
{
    public class ScheduleService
    {
        public List<Models.Schedule> Generate(List<string> shiftA, List<string> shiftB, List<string> shiftC, DateTime startDate, DateTime endDate, List<string> shiftNames)
        {
            Queue<string> queueA = new Queue<string>();

            foreach (string s in shiftA)
            {
                queueA.Enqueue(s);
            }

            Queue<string> queueB = new Queue<string>();

            foreach (string s in shiftB)
            {
                queueB.Enqueue(s);
            }

            Queue<string> queueC = new Queue<string>();

            foreach (string s in shiftC)
            {
                queueC.Enqueue(s);
            }

            List<Models.Schedule> schedules = new List<Models.Schedule>();

            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                List<Shift> shifts = new List<Shift>();

                foreach (string shiftName in shiftNames)
                {
                    string employeeName = string.Empty;

                    if (shiftName == "早班")
                    {
                        employeeName = queueA.Dequeue();
                        queueB.Enqueue(employeeName);
                    }
                    else if (shiftName == "中班")
                    {
                        employeeName = queueB.Dequeue();
                        queueC.Enqueue(employeeName);
                    }
                    else if (shiftName == "晚班")
                    {
                        employeeName = queueC.Dequeue();
                        queueA.Enqueue(employeeName);
                    }

                    Employee employee = new Employee();
                    employee.EmployeeName = employeeName;

                    List<Employee> employees = new List<Employee>();

                    employees.Add(employee);

                    Shift shift = new Shift();
                    shift.Employees = employees;
                    shift.ShiftName = shiftName;

                    shifts.Add(shift);
                }

                Models.Schedule schedule = new Models.Schedule();
                schedule.Date = currentDate;
                schedule.Shifts = shifts;

                schedules.Add(schedule);

                currentDate = currentDate.AddDays(1);
            }

            return schedules;
        }
    }
}