using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Car
    {
        // Access Modifiers:
        //  public: all code can see it
        //  private: (DEFAULT) ONLY this class can see it
        //  protected: this class and all descendent classes
        #region Fields
        private int _year;
        //  class variable: m_iYear  m_Year  mYear  _year  year_
        //  local variable: year
        #endregion

        #region Methods
        public void WhatAmI(int currentYear)
        {
            int year = DateTime.Now.Year;
            Console.WriteLine($"{year}{currentYear}{_year}");
        }
        #endregion
    }
}
