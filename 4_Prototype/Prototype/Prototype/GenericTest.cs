using System;

namespace Prototype
{
    public class GenericTest<T>
    {
        // http://www.dotnetperls.com/generic

        private T _value;

        public GenericTest(T t)
        {
            // field and parameter will be of same type
            _value = t;
        }

        public void Write()
        {
            Console.WriteLine(_value);
        }

    }
}