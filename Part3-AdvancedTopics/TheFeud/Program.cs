using IField;
using McDroid;

Sheep sheep = new Sheep();
Cow cow = new Cow();

IField.Pig pig = new IField.Pig();
McDroid.Pig pig2 = new McDroid.Pig();

namespace IField
{
    public class Sheep { }
    public class Pig { }
}

namespace McDroid
{
    public class Cow { }
    public class Pig { }
}