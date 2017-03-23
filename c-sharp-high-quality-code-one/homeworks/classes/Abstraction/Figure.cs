using System;

namespace Abstraction
{
    abstract class Figure : IFigure
    {
        public abstract double CalcPerimeter();
        public abstract double CalcSurface();
    }
}
