using UnityEngine;

public class Person
{
    public string[] lines;
    public string name;
    public int timeAtStart;
}

class Andrew : Person
{
    public Andrew()
    {
        string[] tempLines = {
        "Hello",
        "Can you save my friend?",
        "he jumped from the window, because his hamster died today...",
        "Please... Help him..."};


        this.lines = tempLines;
        this.name = "Andrew";
        this.timeAtStart = 60;
    }
}

class Kate : Person
{
    public Kate()
    {
        string[] tempLines = {
        "AHHHHHHH!!!",
        "MY FOOT!!!",
        "HELP MEEEEE!!! AHHHHHHHHHHHHH!",
        "PLEASE!",
        "TAKE ME TO THE HOSPITAL!",
        "*screaming* AHHHHHHHHHHHHHHHHHHHH!"};


        this.lines = tempLines;
        this.name = "Kate";
        this.timeAtStart = 100;
    }
}

class Matthew : Person
{
    public Matthew()
    {
        string[] tempLines = {
        "Ahhhhh...",
        "My heart...",
        "You...",
        "Yes... you...",
        "Help...",
        "Me..."};


        this.lines = tempLines;
        this.name = "Matthew";
        this.timeAtStart = 180;
    }
}

class Stephen : Person
{
    public Stephen()
    {
        string[] tempLines = {
        "May I ask you something?",
        "My leg turned black...",
        "...",
        "You think that's not good?",
        "...",
        "Well...",
        "Maybe you're right...",
        "Let's go to the hospital..."};


        this.lines = tempLines;
        this.name = "Stephen";
        this.timeAtStart = 240;
    }
}

class Amy : Person
{
    public Amy()
    {
        string[] tempLines = {
        "HE STABBED ME!!!",
        "IT WAS AN ACCIDENT!",
        "PLEASE!!!",
        "SAVE MEEEE!"};


        this.lines = tempLines;
        this.name = "Amy";
        this.timeAtStart = 60;
    }
}

class Mahmed : Person
{
    public Mahmed()
    {
        string[] tempLines = {
        "I drank this thing, and I feel weird...",
        "very weird...",
        "Could you help me?",
        "please?"};


        this.lines = tempLines;
        this.name = "Mahmed";
        this.timeAtStart = 200;
    }
}

class Sofia : Person
{
    public Sofia()
    {
        string[] tempLines = {
        "THAT DOG HAS BITTEN ME!",
        "HELP ME!!!",
        "WHAT IF I GET RABIES?",
        "I DON'T WANNA DIE!!!",
        "I WANT TO VISIT NORWAY, BEFORE I DIE!!!",
        "PLEASE TAKE ME TO THE NORWAY!!!"};


        this.lines = tempLines;
        this.name = "Sofia";
        this.timeAtStart = 300;
    }
}

class Emma : Person
{
    public Emma()
    {
        string[] tempLines = {
        "*blood drips onto the pavement*",
        "Can I get some stitches?",
        "...",
        "Don't ask...",
        "...",
        "Just take me to the hospital..."};


        this.lines = tempLines;
        this.name = "Emma";
        this.timeAtStart = 40;
    }
}

class Michael : Person
{
    public Michael()
    {
        string[] tempLines = {
        "*he hold his right middle finger in his left hand*",
        "Can you put my finger where it should be?",
        "...",
        "Please?"};


        this.lines = tempLines;
        this.name = "Michael";
        this.timeAtStart = 180;
    }
}


class Richard : Person
{
    public Richard()
    {
        string[] tempLines = {
        "PLEASE HELP MY MOTHER!",
        "SHE IS LAYING LIKE THAT FOR FEW HOURS!",
        "TAKE HER TO THE HOSPITAL!",
        "I BEG YOU!!"};


        this.lines = tempLines;
        this.name = "Richard";
        this.timeAtStart = 40;
    }
}
