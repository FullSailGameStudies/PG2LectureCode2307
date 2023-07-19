// Day11.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
using namespace std;//is this ok?

enum Powers
{
    Money = 10, 
    Strength, 
    Swimming
};
void PrintPower(Powers myPower);
int main()
{
    Powers myPower = Money;
    PrintPower(myPower);

    //std -- standard namespace
    //:: -- scope resolution operator
    //<< -- insertion operator. inserting something to the output stream

    //c++ way
    cout << "Hello World!\n" << 5 << true << "\n";

    //c way
    printf("Hello %s %d\n", "Gotham", 5);

    std::string best = "Batman";
    char theBest[] = "The Bat";//adds a \0 (null terminator)
    char meh[] = { 'A','q','u','a','m','a','n','\0'}; //does not add \0
    cout << theBest << "\n" << meh << "\n";

    for (int i = 0; i < sizeof(theBest)/sizeof(char); i++)
    {
        cout << theBest[i] << ".";
    }
    cout << "\n";

    //int* nums = new int[5] {1, 2, 3, 4, 5};
    //for (int v : nums)
    //    cout << v << "\n";

    //auto == C# var
    //range-based for loop
    for (auto c : theBest)
    {
        cout << c << " ";
    }
    cout << "\n";

    //seed the random generator
    srand(time(NULL));

    //get a random # 0-RAND_MAX (32767)
    int rando = rand() % 101 ;//0-100 (inclusive)

    //templates
    vector<int> scores;//stack instance of the class
    //vector<int>* highScore = new vector<int>();//heap instance
    scores.push_back(5);//List.Add
    scores.push_back(rand());
    scores.push_back(rand());
    scores.push_back(rand());
    for (size_t i = 0; i < scores.size(); i++)
    {
        cout << scores[i] << "\n";
    }
    return 0;
}
void PrintPower(Powers myPower)
{
    switch (myPower)
    {
    case Money:
        cout << "Money\n";
        break;
    case Strength:
        break;
    case Swimming:
        break;
    default:
        break;
    }
}