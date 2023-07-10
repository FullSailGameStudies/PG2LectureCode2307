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

        #region Properties
        //a full property. Property (Year) + backing field (_year)
        public int Year
        {
            //same as...
            //public int GetYear() {return _year;}
            get
            {
                return _year;
            }

            //same as...
            //public void SetYear(int value) {_year = value;}
            private set
            {
                if (value >= 1908 && value <= DateTime.Now.Year + 1)
                    _year = value;
            }
        }

        //an auto property. no backing field and no code for get/set
        public string Make { get; private set; }
        public string Model { get; private set; }
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
