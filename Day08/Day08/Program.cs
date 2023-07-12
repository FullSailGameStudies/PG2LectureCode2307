using Day08CL;

namespace Day08
{
    /*                    DERIVING CLASSESS          
                                                               
                                ╔═════════╗     ╔══════════╗ 
                 public  class  ║SomeClass║  :  ║OtherClass║ 
                                ╚═════════╝     ╚══════════╝
                                     │                │         
                                     └──┐             └──┐             
                                   ┌────▼────┐      ┌────▼────┐      
                                   │ Derived │      │  Base   │    
                                   │  Class  │      │  Class  │     
                                   └─────────┘      └─────────┘     

    
                CONSTRUCTORS: the derived constructor must call a base constructor
                public SomeClass(.....) : base(....)


     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Car batmobile = Factory.MakeCar("WayneTech", "B1000", 2015);
            Truck f150 = new Truck(10000, 100, true, "Ford", "F150", 2023);

            //Weapon pew = new Weapon(100, 100);

            /*
                CHALLENGE 1:

                    In the Day08CL project, add a new class, Pistol, that derives from Weapon.
                    Pistol should have properties for Rounds and MagCapacity.
                    Add a constructor that calls the base constructor
             
            */





            /*  
                ╔═══════════╗ 
                ║ UPCASTING ║ - converting a derived type variable to a base type variable
                ╚═══════════╝ 
                
                This is ALWAYS safe.

                DerivedType A = new DerivedType();
                BaseType B = A;
            



                CHALLENGE 2:
                    Create a List of Weapon. 
                    Create several Pistols and 
                    add them to the list of weapons.
            */
            List<Weapon> dorasBackpack = new List<Weapon>();
            dorasBackpack.Add(new Pistol(50, 100, 6, 1));//upcasting to Weapon
            dorasBackpack.Add(new Pistol(20, 50, 2, 1));
            dorasBackpack.Add(new Knife(3, 10, true));


            int num = 5;//4 bytes
            long bigNum = num;//8 bytes. implicit casting
            num = (int)bigNum;//explicit casting


            //UPCASTING:
            //  from a DERIVED variable to a BASE variable
            Car myRide = f150;//did we lose the truck parts?
            //the Truck parts are inaccessible in the myRide
            //b/c it's just a Car variable
            //Pistol pewpew = (Pistol)f150;





            /*  
                ╔═════════════╗ 
                ║ DOWNCASTING ║ - converting a base type variable to a derived type variable
                ╚═════════════╝ 
                
                This is NOT SAFE!!!!!

            
                BaseType B = new DerivedType(); //upcasting
                DerivedType A = B; !! Build ERROR !!
            

                3 ways to downcast safely...
                1) explicit cast inside of a try-catch
                    try {  DerivedType A = B;  }
                    catch(Exception) { }

                2) use the 'as' keyword
                    NOTE: null will be assigned to A if B cannot be cast to DerivedType
                    DerivedType A = B as DerivedType;
                    if(A != null) { can use A }

                3) use 'is' in pattern matching
                    if(B is DerivedType A) { can use A }



                CHALLENGE 3:
                    Loop over the list of weapons.
                    Call ShowMe on each weapon.
                    Downcast to a Pistol and print the rounds and mag capacity of each pistol
            */

            Weapon currentWeapon = new Pistol(100, 100, 10, 10);//upcasting
            currentWeapon = new Knife(4, 10, true);

            //explicitly cast it inside a try-catch
            try
            {
                Pistol sixShooter = (Pistol)currentWeapon;
            }
            catch (InvalidCastException invalid)
            {

            }
            catch (Exception) //handle the exception
            {
            }

            //use the 'as' keyword to cast
            //if cannot cast, will assign NULL to the variable
            Pistol pewpew = currentWeapon as Pistol;
            if (pewpew != null)
                Console.WriteLine($"Rounds: {pewpew.Rounds}");

            //use the 'is' keyword to pattern match
            if(currentWeapon is Pistol shooter)
                Console.WriteLine($"Rounds: {shooter.Rounds}");






            /*  
                ╔═════════════╗ 
                ║ OVERRIDING  ║ - changing the behavior of a base method
                ╚═════════════╝ 
                
                2 things are required to override a base method:
                1) add 'virtual' to the base method
                2) add a method to the derived class that has the same signature as the base. put 'override' to the derived method


                FULLY OVERRIDING:
                    not calling the base method from the derived method

                EXTENDING:
                    calling the base method from the derived method




                CHALLENGE 4:
                    Override Weapon's ShowMe method in the Pistol method.
                    In Pistol's version, call the base version and print out the rounds and magCapacity
                    Fix the loop to remove the if-elseif.
            */
        }
    }
}