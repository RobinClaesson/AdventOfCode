using AoC.IO;

Input.TestMode = false;
var input = Input.Rows;


var score1 = 0;  
var score2 = 0;  
foreach(var row in input)
{
    score1 += part1Round(row[2], row[0]);
    score2 += part2Round(row[2], row[0]);
}

Output.Answer(score1);
Output.Answer(score2);


int part1Round(char your, char other)
{
    //Chose rock
    if(your == 'X')
    {
        if (other == 'A')
            return 4;
        else if (other == 'B')
            return 1;
        else
            return 7;
    }
    //Chose paper
    else if (your == 'Y')
    {
        if (other == 'A')
            return 8;
        else if (other == 'B')
            return 5;
        else
            return 2;
    } 
    //Chose scissors
    else 
    {
        if (other == 'A')
            return 3;
        else if (other == 'B')
            return 9;
        else
            return 6;
    }
}

int part2Round(char result, char other)
{
    //Lose
    if (result == 'X')
    {
        if (other == 'A')
            return 3;
        else if (other == 'B')
            return 1;
        else
            return 2;
    }
    //Draw
    else if (result == 'Y')
    {
        if (other == 'A')
            return 4;
        else if (other == 'B')
            return 5;
        else
            return 6;
    }
    //Win
    else
    {
        if (other == 'A')
            return 8;
        else if (other == 'B')
            return 9;
        else
            return 7;
    }
}